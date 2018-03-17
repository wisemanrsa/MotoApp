import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import $ from 'jquery';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css']
})
export class VehicleComponent implements OnInit {

  features: any = [];
  makes: any = [];
  models: any = [];
  vehicle: any = {
    features: [],
    contact: {}
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService,
    private notifier: ToastrService
  ) {
     this.route.params.subscribe(p => {
       this.vehicle.id = +p['id'];
     },
    err => {
      this.router.navigate(['/home']);
    });
   }

  ngOnInit() {
    if (this.vehicle.id) {
      this.vehicleService.getVehicle(this.vehicle.id).subscribe(v => {
        this.vehicle = v;
        this.setVehicle(v);
        console.log(this.vehicle);
      });
    }
    this.vehicleService.getMakes().subscribe(makes => this.makes = makes);
    this.vehicleService.getFeatures().subscribe(f => this.features = f);
  }

  setVehicle(moto: any) {
    this.vehicle.id = moto.id;
    this.vehicle.makeId = moto.make.id;
    this.vehicleService.getModels(this.vehicle.makeId).subscribe(models => {
      this.models = models;
  });
    this.vehicle.modelId = moto.model.id;
    this.vehicle.Contact = moto.contact;
    this.vehicle.features = moto.features;
  }

  getModels() {
    delete this.vehicle.modelId;
    if (this.vehicle.makeId == null) {
      this.models = [];
      return;
    }
    this.vehicleService.getModels(this.vehicle.makeId).subscribe(models => {
        this.models = models;
    });
  }

  onFeatureToggle(featureId, $event) {
    if ($event.target.checked) {
      this.vehicle.features.push(featureId);
    } else {
      const index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit() {
    $('.ui.basic.modal').show();
    delete this.vehicle.makeId;
    this.vehicleService.create(this.vehicle).subscribe(x => console.log(x));
  }

}
