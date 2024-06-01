import { Injectable } from '@angular/core';
import { Brand, BrandParams } from '../_modules/brand';
import { PaginationResult } from '../_modules/pagination';
import { HttpClient } from '@angular/common/http';
import { of, map, Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { getPaginatedResult } from './paginationHelper';

@Injectable({
  providedIn: 'root'
})
export class BrandsService {
  baseUrl = environment.apiUrl + 'brands/';
  data: Brand[] = [];
  cache = new Map();
  item?: Brand; 
  params: BrandParams;
  pagedList: PaginationResult<Brand[]> = new PaginationResult<Brand[]>();

  constructor(private http: HttpClient) {
    this.params = new BrandParams();
  }

  getParams = (): BrandParams => this.params;
  setParams = (params: BrandParams) => this.params = params;
  resetParams = (): BrandParams => {
    this.params = new BrandParams();
    return this.params;
  }

  getPagedList(params: BrandParams) {
    const response = this.cache.get(Object.values(params).join('-'));

    if (response) return of(response);

    const param = BrandParams.toHttpParams(params);
    
    return getPaginatedResult<Brand[]>(this.baseUrl, param, this.http).pipe(
      map(response => {
        this.cache.set(Object.values(params).join('-'), response);
        return response;
      })
    )
  }

  getItemById(id: number): Observable<Brand> {
    const item: Brand = [...this.cache.values()]
      .reduce((arr, elem) => arr.concat(elem.result), [])
      .find((item: Brand) => item.id === id);

    if (item) return of(item);
    return this.http.get<Brand>(`${this.baseUrl}${id}`);
  }

  update(item: Brand): Observable<Brand> {
    return this.http.put<Brand>(this.baseUrl, item).pipe(
      tap(response => {
        const index = this.data.indexOf(item);
        this.data[index] = { ...this.data[index] }
        return response;
      })
    )
  }

}
