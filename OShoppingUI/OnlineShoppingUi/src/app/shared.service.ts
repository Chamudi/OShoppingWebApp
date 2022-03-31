import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl="https://localhost:44304/api";

  constructor(private http:HttpClient) { }

  getProductList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/product');
  }

  addProduct(val:any){
    return this.http.post(this.APIUrl+'/Product',val);
  }

  updateProduct(val:any){
    return this.http.put(this.APIUrl+'/Product',val);
  }

  deleteProduct(val:any){
    return this.http.delete(this.APIUrl+'/Product/'+val);
  }


}
