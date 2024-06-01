import { Component, OnInit } from '@angular/core';
import { Product, ProductParams } from '../_modules/product';
import { ProductsService } from '../_services/products.service';
import { Pagination } from '../_modules/pagination';

@Component({
  selector: 'product-catalog-route',
  templateUrl: './product-catalog.component.html',
})
export class ProductCatalogComponent implements OnInit {
  params: ProductParams;
  data: Product[] = []; 
  pagination?: Pagination;
  
  constructor(
    private dataService: ProductsService
  ) {
    this.params = this.dataService.getParams();
  }
  
  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.dataService.getPagedList(this.params).subscribe({
      next: response => {
        if (response) {
          this.data = response.result;
          this.pagination = response.pagination;
        }
      }
    })
  }

  pageChanged(event: any) {
    if (this.params && this.params?.pageNumber !== event.page) {
      this.params.pageNumber = event.page;
      this.dataService.setParams(this.params);
      this.loadData();
    }
  }

  resetFilters() {
    this.params = this.dataService.resetParams();
    this.loadData();
  }
  
}
