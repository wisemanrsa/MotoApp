import { PhotoService } from './services/photo.service';
// import { AppErrorHandler } from './app.error-handler';
import { AppService } from './app.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';


import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { VehicleComponent } from './components/vehicle/vehicle.component';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { MenuComponent } from './components/menu/menu.component';
import { HomeComponent } from './components/home/home.component';
import { VehicleService } from './services/vehicle.service';
import { ToastrModule } from 'ngx-toastr';
import { VehicleListComponent } from './components/vehicle-list/vehicle-list.component';
import { ViewVehicleComponent } from './components/view-vehicle/view-vehicle.component';
import { MaterialModule } from './material.module';



@NgModule({
  declarations: [
    AppComponent,
    VehicleComponent,
    MenuComponent,
    HomeComponent,
    VehicleListComponent,
    ViewVehicleComponent
  ],
  imports: [
    BrowserAnimationsModule,
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    MaterialModule,
    ToastrModule.forRoot()
  ],
  providers: [/*{provide: ErrorHandler, useClass: AppErrorHandler}*/ AppService, VehicleService, PhotoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
