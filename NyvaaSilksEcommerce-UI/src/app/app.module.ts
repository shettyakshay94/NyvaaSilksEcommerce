import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // Import FormsModule

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {  HttpClientModule } from '@angular/common/http'; // Make sure this is imported
import { AdminLibraryService } from '../admin-library.service';
import { CommonHeaderComponent } from './common-header/common-header.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AccountPopupComponent } from './account-popup/account-popup.component';
import { HomePageComponent } from './home-page/home-page.component';
import { AccountService } from './account.service';
import { ImageSliderComponent } from './image-slider/image-slider.component';
import { NgSelectModule } from '@ng-select/ng-select';
@NgModule({
  declarations: [
    AppComponent,
    CommonHeaderComponent,
    AccountPopupComponent,
    HomePageComponent,
    ImageSliderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    FontAwesomeModule,
    HttpClientModule,
    NgSelectModule
  ],
  providers: [AdminLibraryService,AccountService],
  bootstrap: [AppComponent]
})
export class AppModule { }
