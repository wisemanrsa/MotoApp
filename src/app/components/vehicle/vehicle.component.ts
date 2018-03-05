import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css']
})
export class VehicleComponent implements OnInit {

  features: any = [];
  makes: any = [];
  models: any = [];
  vehicleId: any;
  vehicle: any = {
    features: [],
    contact: {}
  };

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe(makes => this.makes = makes);
    this.vehicleService.getFeatures().subscribe(f => this.features = f);
  }

  getModels() {
    if (this.vehicleId == '') {
      this.models = [];
      return;
    }
    this.vehicleService.getModels(this.vehicleId).subscribe(models => this.models = models);
  }

}
