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
  vehicle: any;
  makes: any;

  constructor(private vehicleService: VehicleService, private notifier: ToastrService, private router: Router) { }

  ngOnInit() {
    this.populateVehicles();
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

  viewVehicle(id) {
    this.router.navigate(['/vehicle/view/' + id]);
  }

  populateVehicles() {
    this.vehicleService.getVehicles(this.filter).subscribe(v => this.vehicles = v);
  }

  onFilterChange() {
    this.populateVehicles();
  }

  sortBy(columnName) {
    if (this.filter.sortBy == columnName) {
      this.filter.isSortAscending = !this.filter.isSortAscending;
    } else {
      this.filter.sortBy = columnName;
      this.filter.isSortAscending = true;
    }
    this.populateVehicles();
  }
}
