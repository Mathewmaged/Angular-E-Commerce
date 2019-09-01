import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Product } from './Product.model';
import { Category } from './Category.model';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ShopService {
  readonly rootUrl = 'http://localhost:50572';

  constructor(private http: HttpClient) { }

  getAllProductss(): Observable<Product[]> {
    return this.http
      .get<Product[]> (this.rootUrl + '/api/Shop');
  }
  getAllCategory(): Observable<Category[]> {
    return this.http
      .get<Category[]> (this.rootUrl + '/api/Cate');
  }

  getProductByID(id:number):Observable<Product> {
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http.get<Product>(this.rootUrl+"/api/Product/"+id,{headers:reqHeader})
  }
//   prod:Product;

//   find(id: number): Product {
//     this.getProductByID(id).subscribe((data:Product)=>{this.prod=data; });
//     console.log(this.prod);
//     return  this.prod;
    
// }
}
