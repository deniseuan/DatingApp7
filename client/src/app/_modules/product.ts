import { HttpParams } from "@angular/common/http";
import { Brand } from "./brand";

export class Product {
    id: number;
    name: string;
    price: number;
    photoUrl: string;
    brand: Brand;

    constructor(
        id: number,
        name: string,
        price: number,
        photoUrl: string,
        brand: Brand,
    ) {
        this.id = id;
        this.name = name;
        this.price = price;
        this.photoUrl = photoUrl;
        this.brand = brand;
    }
}

export class ProductParams {
    pageNumber = 1;
    pageSize = 5;
    orderBy = 'lastActive';

    static toHttpParams(param: ProductParams): HttpParams {
        let params = new HttpParams();

        params = params.append('pageNumber', param.pageNumber);
        params = params.append('pageSize', param.pageSize);
        params = params.append('orderBy', param.orderBy);

        return params;
    }
}
