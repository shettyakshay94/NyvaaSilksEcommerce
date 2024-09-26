import { Component, OnInit } from '@angular/core';
import { AdminLibraryService } from '../../../admin-library.service';

interface Product {
  productId: number;
  productName: string;
}

interface ProductCategory {
  productCategoryId: number;
  productCategoryName: string;
}

@Component({
  selector: 'app-upload-content',
  templateUrl: './upload-content.component.html',
  styleUrls: ['./upload-content.component.scss']
})
export class UploadContentComponent implements OnInit {
  productTypes: string[] = [];
  products: Product[] = [];
  productCategoryDetails: ProductCategory[] = [];
  productCategories: string[] = [];
  productType: string = "";
  productCategory: string = "";
  productName: string = "";
  description: string = "";
  productAmount: string = "";
  imageFiles: File[] = []; // To hold the actual image files
  imagePreviews: string[] = []; // To display preview of images
  maxImages: number = 5; // Maximum number of images allowed

  constructor(private adminLibraryService: AdminLibraryService) {}

  ngOnInit() {
    this.loadProductTypes();
  }

  onPublish() {
    const selectedProduct = this.products.find(b => b.productName === this.productType);
    const selectedCategory = this.productCategoryDetails.find(a => a.productCategoryName === this.productCategory);

    if (!selectedProduct || !selectedCategory) {
      console.error('Product or category not found');
      return;
    }

    const productDetails = {
      ProductId: selectedProduct.productId,
      ProductCategoryId: selectedCategory.productCategoryId,
      ProductName: this.productName,
      ProductDescription: this.description,
      ProductAmount: this.productAmount
    };

    this.uploadProductWithImages(productDetails);
  }

  uploadProductWithImages(productDetails: any) {
    const formData = new FormData();

    // Append product details
    formData.append('ProductId', productDetails.ProductId.toString());
    formData.append('ProductCategoryId', productDetails.ProductCategoryId.toString());
    formData.append('ProductName', productDetails.ProductName);
    formData.append('ProductDescription', productDetails.ProductDescription);
    formData.append('ProductAmount', productDetails.ProductAmount);

    // Append each image file
    for (let i = 0; i < this.imageFiles.length; i++) {
      formData.append('files', this.imageFiles[i]);
    }

    this.adminLibraryService.uploadProductWithImage(formData).subscribe(
      (response) => {
        console.log('Product and images uploaded successfully:', response);
      },
      (error) => {
        console.error('Error uploading product and images:', error);
      }
    );
  }

  loadProductTypes() {
    this.adminLibraryService.getProductTypes().subscribe(
      (data) => {
        this.products = data;
        this.productTypes = data.map(item => item.productName);
        if (this.productTypes.length > 0) {
          this.productType = this.productTypes[0];
          const selectedProductId = data.find(item => item.productName === this.productType).productId;
          this.loadProductCategories(selectedProductId);
        }
      },
      (error) => {
        console.error('Error fetching product types:', error);
      }
    );
  }

  loadProductCategories(productId: number) {
    this.adminLibraryService.getProductCategory(productId).subscribe(
      (data) => {
        this.productCategoryDetails = data;
        this.productCategories = data.map(item => item.productCategoryName);
        if (this.productCategories.length > 0) {
          this.productCategory = this.productCategories[0];
        }
      },
      (error) => {
        console.error('Error fetching product categories:', error);
      }
    );
  }

  onFileChange(event: any) {
    if (event.target.files) {
      const selectedFiles: File[] = Array.from(event.target.files); // Explicitly type as File[]
  
      if (selectedFiles.length + this.imageFiles.length > this.maxImages) {
        alert(`You can only upload up to ${this.maxImages} images.`);
        return;
      }
  
      this.imagePreviews = [];
      for (const file of selectedFiles) {
        this.imageFiles.push(file); // Save the actual file object
  
        const reader = new FileReader();
        reader.onload = (e: any) => {
          this.imagePreviews.push(e.target.result); // Save the preview
        };
        reader.readAsDataURL(file);
      }
    }
  }
  
  onPreview() {
    console.log({
      productType: this.productType,
      productCategory: this.productCategory,
      productName: this.productName,
      description: this.description,
      images: this.imagePreviews
    });
  }

  onSubmit() {
    console.log({
      productType: this.productType,
      productCategory: this.productCategory,
      productName: this.productName,
      description: this.description,
      images: this.imagePreviews
    });
  }
}
