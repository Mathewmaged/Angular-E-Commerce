import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {


  constructor(private router: Router) { }
  ngOnInit() {
     
  }
  Logout() {
    localStorage.removeItem('userToken');
    localStorage.removeItem('userRoles');

    this.router.navigate(['/login']);

  }
}
