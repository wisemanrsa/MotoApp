import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class PhotoService {

  constructor(private http: HttpClient) { }

  upload(vid, photo) {
    var formData = new FormData();
    formData.append('file', photo);
    return this.http.post(`/api/vehicles/${vid}/photos`, formData);
  }

  getPhotos(id) {
    return this.http.get(`/api/vehicles/${id}/photos`);
  }

}
