import { HttpParams } from "@angular/common/http";
import { User } from "./user";
import { getPaginationHeaders } from "../_services/paginationHelper";

export class UserParams{
    static toHttpParams(params: UserParams): HttpParams {
        let param = new HttpParams();

        param = getPaginationHeaders(params.pageNumber, params.pageSize);

        param = param.append('minAge', params.minAge);
        param = param.append('maxAge', params.maxAge);
        param = param.append('gender', params.gender);
        param = param.append('orderBy', params.orderBy);
    
        return param;
    }
    
    gender: string;
    minAge = 18;
    maxAge = 99;
    pageNumber = 1;
    pageSize = 5;
    orderBy = 'lastActive';

    constructor(user: User){
        this.gender = user.gender === 'female' ? 'male' : 'female'    
    }
}