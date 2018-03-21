import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { Route, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-view-vehicle',
  templateUrl: './view-vehicle.component.html',
  styleUrls: ['./view-vehicle.component.css']
})
export class ViewVehicleComponent implements OnInit {

  vehicle: any = {};
  showVehicle = true;

  constructor(private vehicleService: VehicleService, private route: ActivatedRoute) {
    this.route.params.subscribe(p => this.vehicle.id = +p['id']);
  }

  ngOnInit() {
    this.vehicleService.getVehicle(this.vehicle.id).subscribe(v => this.setVehicle(v));
  }

  setVehicle(moto: any) {
    this.vehicle.id = moto.id;
    this.vehicle.features = moto.features;
    this.vehicle.model = moto.model;
    this.vehicle.make = moto.make;
    this.vehicle.features = moto.features;
    this.vehicle.contact = moto.contact;
  }

  boolShowVehicle() {
    this.showVehicle = true;
  }
  boolShowPhotos() {
    this.showVehicle = false;
  }

}
