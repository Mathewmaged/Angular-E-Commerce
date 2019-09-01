import { Component, OnInit } from '@angular/core';
import { User } from '../../shared/user.modal';
import { NgForm } from '../../../../node_modules/@angular/forms';
import { UserService } from '../../shared/user.service';
import { ToastrService } from '../../../../node_modules/ngx-toastr';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  user: User;
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  roles :any;
  x:string;

  constructor(private userService:UserService,private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
    this.userService.getAllRoles().subscribe(
      (data : any)=>{
        data.forEach(obj => obj.selected = false);
        this.roles = data;
      }
    );
    this.isError=false;

  }
  message:string;
  isError:boolean;
  resetForm(form?: NgForm) {
    if (form != null)
    {
      form.reset();
      this.isError=false;

    }
    this.user = {
      UserName: '',
      Password: '',
      Email: '',
      FirstName: '',
      LastName: '',
      Roles:''
        }


  }
  OnSubmit(form: NgForm) {
    if(this.user.UserName=='admin'){
      this.x='admin';
    }
    else{
      this.x='customer'
    }
    console.log(this.x);
    this.userService.registerUser(form.value,this.x)
      .subscribe((data: any) => {
        if (data.Succeeded == true) {
          this.resetForm(form);
          this.message='User registration successful';
          this.isError=true;
        }
        else{
          this.toastr.error(data.Errors);
          this.message=data.Errors;
          this.isError=true;

        }
      });
  }

}
