import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from './product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  url = 'https://localhost:7281/api/product/';
  constructor(private http: HttpClient) { }
  getAllProduct(): Observable<Product[]> {
    return this.http.get<Product[]>(this.url );
  }
 
  createProduct(product: Product): Observable<Product> {    
   
    return this.http.post<Product>(this.url 
      ,
    product);
  }
  getProducBytId(Id: string): Observable<Product> {
   
    return this.http.get<Product>(this.url  + Id);
  }
  updateProduct(product: Product): Observable<Product> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
  
    return this.http.put<Product>(this.url ,
    product, httpOptions);

   
  }
  deleteProductById(productid: string): Observable<number> {
   
  
    return this.http.delete<number>(this.url + productid);
  }

 

  deleteData(user: Product[]): Observable<string> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<string>(this.url + '/DeleteRecord/', user, httpOptions);
  }  
}
