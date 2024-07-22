import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; // Imports HttpClientModule for making HTTP requests.
import { FormsModule } from '@angular/forms'; // Imports FormsModule for template-driven forms.

import { AppComponent } from './app.component'; // Imports the root component of the application.

@NgModule({
  declarations: [
    AppComponent // Declares the AppComponent as a part of this module.
  ],
  imports: [
    BrowserModule, // Imports BrowserModule for running Angular in a browser.
    HttpClientModule, // Imports HttpClientModule to enable HTTP communication.
    FormsModule // Imports FormsModule to work with Angular forms.
  ],
  providers: [], // No services provided at the module level (can be left empty if not used).
  bootstrap: [AppComponent] // Specifies the root component to bootstrap the application.
})
export class AppModule { } // Defines the root module of the Angular application.
