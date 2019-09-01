import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  constructor(private userService:UserService,private router : Router) { }
  isLoginError : boolean = false;

  ngOnInit() {
  }
  OnSubmit(username,password) {
    this.userService.userAuthentication(username,password)
      .subscribe((data: any) => {
          localStorage.setItem('userToken',data.access_token);
          localStorage.setItem('userRoles',data.role);
console.log(data);
          this.router.navigate(['/Account']);
    
      },(err : HttpErrorResponse)=>{
        this.isLoginError = true;
      });
  }

}
