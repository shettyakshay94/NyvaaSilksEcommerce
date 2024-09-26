import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-account-popup',
  templateUrl: './account-popup.component.html',
  styleUrl: './account-popup.component.scss'
})
export class AccountPopupComponent {
   // isOpen = true; // Open modal state
    activeTab = 'login'; // Default to 'login'
    @Input() isOpen: boolean = false; // Make isOpen an input property

    mobileNumber = '';
  
    selectTab(tab: string) {
      this.activeTab = tab;
    }
  
    onLogin() {
      // Handle login form submission
    }
  
    onRegister() {
      // Handle registration form submission
    }
  
    close() {
      this.isOpen = false;
    }
  }
  

