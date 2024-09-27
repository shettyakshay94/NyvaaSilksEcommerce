import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AdminLibraryService {
  private apigetProductUrl = 'https://localhost:44312/api/Admin/getProducts'; // Replace with your actual API URL
  private apigetProductCategoryUrl='https://localhost:44312/api/Admin/getProductsCategory/'
  private apiUrl='https://localhost:44312/api/Admin'
  constructor(private http: HttpClient) {}

  getProductTypes(): Observable<any[]> {
    return this.http.get<any[]>(this.apigetProductUrl);
  }
  getSearchDetails(productName: string, productCategoryName: string) {
    let params = new HttpParams()
      .set('ProductName', encodeURIComponent(productName))
      .set('ProductCategoryName', encodeURIComponent(productCategoryName));

    return this.http.get<any[]>(`${this.apiUrl}/search`, { params })
      .pipe(
        catchError(error => {
          console.error('Error occurred:', error);
          return throwError(error);
        })
      );
}
  
  
  getProductCategory(id:any): Observable<any[]> {
    return this.http.get<any[]>(this.apigetProductCategoryUrl+id)
  }
  uploadProduct(data: any) {
    return this.http.post(`${this.apiUrl}/uploadproduct`, data);
  }
  uploadProductWithImage(data: any) {
    return this.http.post(`${this.apiUrl}/uploadproductimages`, data);

  }
}
