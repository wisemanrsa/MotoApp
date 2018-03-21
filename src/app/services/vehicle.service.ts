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

  getVehicles(filter) {
    if (this.haveFilters(filter)) {
      return this.http.get('/api/vehicles' + '?' + this.toQueryString(filter));
    }
    return this.http.get('/api/vehicles');
  }

  toQueryString(obj) {
    var parts = [];
    for (let prop in obj) {
      var value = obj[prop];
      if (value != null && value != undefined) {
        parts.push(encodeURIComponent(prop) + '=' + encodeURIComponent(value));
      }
    }
    return parts.join('&');
  }

  haveFilters(obj) {
    for (let prop in obj) {
      var value = obj[prop];
      if (value != null && value != undefined) {
       return true;
      }
    }
    return false;
  }

}
