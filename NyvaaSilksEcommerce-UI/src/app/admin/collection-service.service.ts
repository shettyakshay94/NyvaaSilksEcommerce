import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CollectionServiceService {

    private baseUrl = 'http://localhost:5000/api/collection'; // Replace with your actual API URL
  
    constructor(private http: HttpClient) {}
  
    // Fetch product types and categories
    getDropdownData(): Observable<any> {
      return this.http.get(`${this.baseUrl}/dropdowns`);
    }
  
    // Fetch vendor names
    getVendors(): Observable<string[]> {
      return this.http.get<string[]>(`${this.baseUrl}/vendors`);
    }
  
    // Search products by query
    searchProducts(query: string): Observable<any> {
      return this.http.get(`${this.baseUrl}/search?query=${query}`);
    }
  
    // Create a collection
    createCollection(collection: any): Observable<any> {
      return this.http.post(`${this.baseUrl}/create`, collection);
    }
  }
  
