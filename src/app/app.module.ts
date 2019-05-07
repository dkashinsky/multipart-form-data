import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { MultipartFormComponent } from './multipart-form/multipart-form.component';
import { FileInputComponent } from './file-input/file-input.component';

@NgModule({
  declarations: [
    AppComponent,
    MultipartFormComponent,
    FileInputComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
