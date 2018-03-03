import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class AppService {

  constructor(private http: HttpClient) { }

  getItems() {
    return this.http.get('/api/values');
  }

}
