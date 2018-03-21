import { ViewVehicleComponent } from './components/view-vehicle/view-vehicle.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { VehicleComponent } from './components/vehicle/vehicle.component';
import { VehicleListComponent } from './components/vehicle-list/vehicle-list.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'vehicle/new',
    component: VehicleComponent
  },
  {
    path: 'vehicle/:id',
    component: VehicleComponent
  },
  {
    path: 'vehicle/view/:id',
    component: ViewVehicleComponent
  },
  {
    path: 'vehicles',
    component: VehicleListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
