import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { AccountService } from '../account.service';

interface Category {
  categoryName: string;
  ProductCategoryId: number;
}

interface Product {
  productName: string;
  productCategory: Category[]; // Array of categories associated with the product
}

@Component({
  selector: 'app-common-header',
  templateUrl: './common-header.component.html',
  styleUrls: ['./common-header.component.scss']
})

export class CommonHeaderComponent implements OnInit {
  accountPopupOpen = false;
  category:any[]=[];
  subcategory:any[]=[];
  products: any[] = []; // To store fetched products
   productAndCategory: any[]=[];
  constructor(private accountService: AccountService,changeDetector:ChangeDetectorRef) {}

  ngOnInit(): void {
    this.fetchProducts();
  }

  fetchProducts(): void {
    this.accountService.getCategories().subscribe((data: Product[]) => {
      this.productAndCategory = data; // Now productAndCategory is typed correctly
      this.products = this.productAndCategory.map(product => ({
        productName: product.productName,
        subcategories: [
          'All ' + product.productName, 
          ...product.productCategory
            .filter((category: Category) => category.categoryName) // Type-safe filtering
            .map((category: Category) => category.categoryName)    // Type-safe mapping to category names
        ]
      }));
    });
  }
  
  
}
