import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import $ from 'jquery';
import { ToastrService } from 'ngx-toastr';

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

  constructor(private vehicleService: VehicleService, private notifier: ToastrService) { }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe(makes => this.makes = makes);
    this.vehicleService.getFeatures().subscribe(f => this.features = f);
  }

  getModels() {
    if (this.vehicle.makeId == null) {
      this.models = [];
      return;
    }
    this.vehicleService.getModels(this.vehicle.makeId)
      .subscribe(models => {
        this.models = models;
        this.notifier.success('Models loaded', 'Awesome');
      });
    delete this.vehicle.modelId;
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
