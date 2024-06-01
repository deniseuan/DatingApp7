import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Product, ProductParams } from '../_modules/product';
import { PaginationResult } from '../_modules/pagination';
import { HttpClient } from '@angular/common/http';
import { Observable, map, of, take, tap } from 'rxjs';
import { getPaginatedResult } from './paginationHelper';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  baseUrl = environment.apiUrl + 'products/';
  data: Product[] = [];
  cache = new Map();
  item?: Product; 
  params: ProductParams;
  pagedList: PaginationResult<Product[]> = new PaginationResult<Product[]>();

  constructor(private http: HttpClient) {
    this.params = new ProductParams();
  }

  getParams = (): ProductParams => this.params;
  setParams = (params: ProductParams) => this.params = params;
  resetParams = (): ProductParams => {
    this.params = new ProductParams();
    return this.params;
  }

  getPagedList(params: ProductParams) {
    const response = this.cache.get(Object.values(params).join('-'));

    if (response) return of(response);

    const param = ProductParams.toHttpParams(params);
    
    return getPaginatedResult<Product[]>(this.baseUrl, param, this.http).pipe(
      map(response => {
        this.cache.set(Object.values(params).join('-'), response);
        return response;
      })
    )
  }

  getItemById(id: number): Observable<Product> {
    const item: Product = [...this.cache.values()]
      .reduce((arr, elem) => arr.concat(elem.result), [])
      .find((item: Product) => item.id === id);

    if (item) return of(item);
    return this.http.get<Product>(`${this.baseUrl}${id}`);
  }

  update(item: Product, id: number): Observable<Product> {
    return this.http.put<Product>(`${this.baseUrl}${id}`, item).pipe(
      tap(response => {
        const index = this.data.indexOf(item);
        this.data[index] = { ...this.data[index] }
        return response;
      })
    )
  }

  create(item: any): Observable<Product> {
    return this.http.post<Product>(this.baseUrl, item).pipe(
      tap(response => {
        this.data.push(response);
        return response;
      })
    )
  }

}
