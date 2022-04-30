import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { TruckComponent } from './component/truck/truck.component';
import { TruckFormComponent } from './component/truck/truck-form/truck-form.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ToastrModule } from "ngx-toastr";
import { SplashScreenComponent } from './component/splash-screen/splash-screen.component';

@NgModule({
  declarations: [
    AppComponent,
    TruckComponent,
    TruckFormComponent,
    SplashScreenComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
