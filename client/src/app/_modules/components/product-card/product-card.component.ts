import { Component, Input, OnInit } from '@angular/core';
import { Product } from '../../product';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'product-card',
  templateUrl: './product-card.component.html',
  providers: []
})
export class ProductCardComponent implements OnInit{
  @Input({required: true}) item!: Product;
  
  constructor(
    private toastr: ToastrService
  ) {

    }
  ngOnInit() {
  }

  like = () => this.toastr.error('Aún no ha sido implementado')

}
