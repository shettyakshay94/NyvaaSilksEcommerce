import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { UploadContentComponent } from './upload-content/upload-content.component';
import { CreateCollectionComponent } from './create-collection/create-collection.component';

const routes: Routes = [{ path: '', component: AdminComponent },
  { path: 'upload', component: UploadContentComponent },
  { path: 'create-collection',component: CreateCollectionComponent}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
