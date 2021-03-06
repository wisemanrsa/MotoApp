import { AppService } from './app.service';
import { Component, OnInit } from '@angular/core';
import swal from 'sweetalert2';
import $ from 'jquery';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  items: any = [];

  constructor(private appService: AppService) {

  }
  sayHi() {
    swal(
      'Good day',
      'Thank you',
      'success'
    );

    $('#hi').hide();
  }

}
