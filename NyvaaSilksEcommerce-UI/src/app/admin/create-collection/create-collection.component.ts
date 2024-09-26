import { Component, OnInit } from '@angular/core';
import { CollectionServiceService } from '../collection-service.service';

interface Product {
  name: string;
  description: string;
  imageUrl: string;
  selected?: boolean; // Optional flag to track selection
}

interface Collection {
  productType: string;
  categories: string[];  // Now it's an array for multiple category selection
  vendorName: string;
  description: string;
  selectedProducts: Product[];
}

@Component({
  selector: 'app-create-collection',
  templateUrl: './create-collection.component.html',
  styleUrl: './create-collection.component.scss'
})
// Define types for product and collection data


export class CollectionComponent implements OnInit {
  // Initialize necessary variables
  productTypes: string[] = [];
  categories: string[] = [];
  vendors: string[] = [];
  products: Product[] = [];
  collection: Collection = {
    productType: '',
    categories: [],  // Multiple categories supported
    vendorName: '',
    description: '',
    selectedProducts: []
  };
  
  toggleStep: boolean = true; // true for Step A, false for Step B

  constructor(private collectionService: CollectionServiceService) {}

  ngOnInit() {
    this.getDropdownData();
    this.getVendors();
  }

  // Fetch product types and categories
  getDropdownData() {
    this.collectionService.getDropdownData().subscribe((data:any) => {
      this.productTypes = data.productTypes;
      this.categories = data.categories;
    });
  }

  // Fetch vendors
  getVendors() {
    this.collectionService.getVendors().subscribe(vendors => {
      this.vendors = vendors;
    });
  }

  // Search for products based on query
  searchProducts(query: string) {
    this.collectionService.searchProducts(query).subscribe((products: Product[]) => {
      this.products = products;
    });
  }

  // Select or deselect a product
  toggleProductSelection(product: Product) {
    product.selected = !product.selected;

    if (product.selected) {
      this.collection.selectedProducts.push(product);
    } else {
      this.collection.selectedProducts = this.collection.selectedProducts.filter(p => p.name !== product.name);
    }
  }

  // Submit the collection
  submitCollection() {
    this.collectionService.createCollection(this.collection).subscribe((response:any) => {
      console.log(response.message);
    });
  }
}
