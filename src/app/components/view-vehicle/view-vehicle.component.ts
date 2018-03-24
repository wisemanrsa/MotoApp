import { PhotoService } from './../../services/photo.service';
import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { Route, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-view-vehicle',
  templateUrl: './view-vehicle.component.html',
  styleUrls: ['./view-vehicle.component.css']
})
export class ViewVehicleComponent implements OnInit {

  @ViewChild('fileInput') fileInput: ElementRef;
  vehicle: any = {};
  showVehicle = true;
  photos: any = [];

  constructor(private vehicleService: VehicleService, private route: ActivatedRoute, private photoService: PhotoService) {
    this.route.params.subscribe(p => this.vehicle.id = +p['id']);
  }

  ngOnInit() {
    this.vehicleService.getVehicle(this.vehicle.id).subscribe(v => this.setVehicle(v));
    this.getPhotos();
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

  uploadPhoto() {
    var nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    this.photoService.upload(this.vehicle.id, nativeElement.files[0]).subscribe(x => this.photos.push(x));
  }

  getPhotos() {
    this.photoService.getPhotos(this.vehicle.id).subscribe(photos => this.photos = photos);
  }

}
