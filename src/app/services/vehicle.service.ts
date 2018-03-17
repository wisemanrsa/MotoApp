import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class VehicleService {

  constructor(private http: HttpClient) { }

  getMakes() {
    return this.http.get('/api/makes');
  }

  getModels(makeId) {
    return this.http.get('/api/models/' + makeId);
  }

  getFeatures() {
    return this.http.get('/api/features');
  }

  create(vehicle) {
    return this.http.post('/api/vehicles', vehicle);
  }

  delete(id) {
    return this.http.delete('/api/vehicles/' + id);
  }

  getVehicle(id: any) {
    return this.http.get('/api/vehicles/' + id);
  }

  getVehicles() {
    return this.http.get('/api/vehicles');
  }

}
