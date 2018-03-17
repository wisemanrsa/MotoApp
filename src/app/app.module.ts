// import { AppErrorHandler } from './app.error-handler';
import { AppService } from './app.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';


import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { VehicleComponent } from './components/vehicle/vehicle.component';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { MenuComponent } from './components/menu/menu.component';
import { HomeComponent } from './components/home/home.component';
import { VehicleService } from './services/vehicle.service';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    AppComponent,
    VehicleComponent,
    MenuComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ToastrModule.forRoot()
  ],
  providers: [/*{provide: ErrorHandler, useClass: AppErrorHandler}*/ AppService, VehicleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
