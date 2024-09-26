
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private categoriesUrl = 'https://localhost:44312/api/Category/category';
  private newProductsUrl = 'https://api.example.com/new-products'; // Replace with actual API

  constructor(private http: HttpClient) {}

  getCategories(): Observable<any> {
    return this.http.post<any>(this.categoriesUrl,null);
  }

  getNewProducts(): Observable<any> {
    return this.http.get<any>(this.newProductsUrl);
  }
}
