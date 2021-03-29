import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormComponent } from './form/form.component';
import { MultiplyComponent } from './multiply/multiply.component';
import { StringComponent } from './string/string.component';
import { ElementComponent } from './element/element.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdditionComponent } from './addition/addition.component';
import { DivisonComponent } from './divison/divison.component';
import { SubtractionComponent } from './subtraction/subtraction.component';

@NgModule({
  declarations: [
    AppComponent,
    FormComponent,
    MultiplyComponent,
    StringComponent,
    ElementComponent,
    AdditionComponent,
    DivisonComponent,
    SubtractionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
