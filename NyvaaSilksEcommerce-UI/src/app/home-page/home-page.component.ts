import { Component, OnInit } from '@angular/core';
import { AccountService } from '../account.service'; // Replace with actual service location

// Interface for Subcategories
interface Subcategory {
  name: string;
}

// Interface for Categories
interface Category {
  name: string;
  imageUrl: string;
  subcategories: Subcategory[];
}

// Interface for Products
interface Product {
  name: string;
  imageUrl: string;
}

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss'] // Updated 'styleUrls' typo
})
export class HomePageComponent implements OnInit {
  categories: Category[] = []; // Categories list
  newProducts: Product[] = []; // New products list
  hoveredCategory: Category | null = null; // For showing subcategories

  constructor(private apiService: AccountService) {} // Injecting the AccountService

  // OnInit Lifecycle Hook
  ngOnInit(): void {
    this.fetchCategories(); // Fetch categories on component load
    this.fetchNewProducts(); // Fetch new products on component load
  }

  // Fetch categories data from API
  fetchCategories(): void {
    this.apiService.getCategories().subscribe((data: Category[]) => {
      this.categories = data;
    });
  }

  // Fetch new products data from API
  fetchNewProducts(): void {
    this.apiService.getNewProducts().subscribe((data: Product[]) => {
      this.newProducts = data;
    });
  }

  // Show subcategories on hover
  showSubcategories(category: Category): void {
    this.hoveredCategory = category;
  }

  // Hide subcategories on mouse leave
  hideSubcategories(): void {
    this.hoveredCategory = null;
  }
}
