import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // Import FormsModule
import { HttpClientModule } from '@angular/common/http';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { UploadContentComponent } from './upload-content/upload-content.component';
import { AdminLibraryService } from '../../admin-library.service';
import { CreateCollectionComponent } from './create-collection/create-collection.component';

@NgModule({
  declarations: [
    AdminComponent,
    UploadContentComponent,
    CreateCollectionComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    AdminRoutingModule
    ,HttpClientModule
  ],
  providers: [HttpClientModule]
})
export class AdminModule { }
