import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../../services/vehicle.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {

  filter: any = {};
  vehicles: any;
  allVehicles: any;
  vehicle: any;
  makes: any;

  constructor(private vehicleService: VehicleService, private notifier: ToastrService, private router: Router) { }

  ngOnInit() {
    this.vehicleService.getVehicles().subscribe(v => this.vehicles = this.allVehicles = v);
    this.vehicleService.getMakes().subscribe(m => this.makes = m);
  }

  delete(id) {
    if (confirm('Are you sure you want to delete this vehicle')) {
      console.log(id);
    }
  }

  edit(id) {
    this.router.navigate(['/vehicle/' + id]);
  }

  newVehicle() {
    this.router.navigate(['/vehicle/new']);
  }

  onFilterChange() {
    let vehicles = this.allVehicles;

    if (this.filter.makeId) {
      vehicles = vehicles.filter(v => v.make.id == this.filter.makeId);
    }

    this.vehicles = vehicles;
  }

}
