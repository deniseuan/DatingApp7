import { HttpParams } from "@angular/common/http";

export class Brand {
    id: number;
    name: string;

    constructor(
        id: number,
        name: string,
    ) {
        this.id = id;
        this.name = name;
    }
}

export class BrandParams {
    pageNumber = 1;
    pageSize = 5;
    orderBy = 'lastActive';

    static toHttpParams(param: BrandParams): HttpParams {
        let params = new HttpParams();

        params = params.append('pageNumber', param.pageNumber);
        params = params.append('pageSize', param.pageSize);
        params = params.append('orderBy', param.orderBy);

        return params;
    }
}
