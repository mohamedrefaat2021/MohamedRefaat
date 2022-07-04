import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from './order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  url = 'https://localhost:7281/api/order/';
  constructor(private http: HttpClient) { }
  getAllOrder(): Observable<Order[]> {
    return this.http.get<Order[]>(this.url );
  }
 
}
