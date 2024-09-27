import { Component, OnInit } from '@angular/core';
import { AdminLibraryService } from '../../../admin-library.service';

@Component({
  selector: 'app-create-collection',
  templateUrl: './create-collection.component.html',
  styleUrls: ['./create-collection.component.scss']
})
export class CreateCollectionComponent implements OnInit {
  currentStep = 'A';
  vendors:any[]=[];
  productTypes = ['Saree', 'Dupatta', 'Blouse', 'Dress'];
  categories = ['Kanjeevaram', 'Banarasi', 'Chanderi', 'Cotton'];
  productCategories:any[]=[];
  productType:any='';
  products : any[] = [];
  category:any;
  productName: any[]=[];
  collectionData = {
    productType: '',
    category: '',
    description: '',
    vendorName:''
  };
  constructor(private adminLibraryService: AdminLibraryService)
  {

  }
  ngOnInit(): void {
    this.fetchdefaultValues();
  }

  fetchdefaultValues()
  {
   this.adminLibraryService.getProductTypes().subscribe(
(data)=> {
  this.products=data;
  this.productName=data.map(item => item.productName)
  if (this.products.length > 0) {
    debugger;
    const selectedProductId = data.find(item => item.productName === this.productType).productId;

  }
}
    )
  }
submitCollection() {}
  toggleStep(step: string) {
    this.currentStep = step;
  }

  onSearch() {
    this.adminLibraryService.getSearchDetails(this.productType,this.category).subscribe((data:any)=>{
      this.products = [
        { imageName: 'product1.jpg', name: 'Product 1', description: 'Description of Product 1', selected: false },
        { imageName: 'product2.jpg', name: 'Product 2', description: 'Description of Product 2', selected: false }
        // Add more products as necessary
      ];
    });
    // Simulate fetching products from API
   
  }

  getProductImageUrl(imageName: string) {
    return `C:/Users/DELL/source/repos/Images/Products/${imageName}`;  // Modify this as per your directory structure
  }

  onSubmit() {
    // Submit collection data to API
    console.log(this.collectionData);
  }
searchProducts()
{

}
  onProductTypeChange(selected: string) {
    const selectedProductId = this.products.find(item => item.productName === selected).productId;
    this.loadProductCategories(selectedProductId);

    if (!this.productTypes.includes(selected)) {
      this.productTypes.push(selected);
    }
  }
  loadProductCategories(productId: number) {
    this.adminLibraryService.getProductCategory(productId).subscribe(
      (data) => {
        this.productCategories = data;
        this.categories = data.map(item => item.productCategoryName);
        if (this.categories.length > 0) {
          this.category = this.category[0];
        }
      },
      (error) => {
        console.error('Error fetching product categories:', error);
      }
    );
  }
  onCategoryChange(selected: string) {
    if (!this.categories.includes(selected)) {
      this.categories.push(selected);
    }
  }
  getImagePath(image: string){

  }
}

