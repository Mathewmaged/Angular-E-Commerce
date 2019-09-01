import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanActivate, Router } from '@angular/router';
import { Observable, from } from 'rxjs';
import {UserService} from 'src/app/shared/user.service';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements  CanActivate {
  constructor(private UserService:UserService,private router : Router){}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot):  boolean {
      if (localStorage.getItem('userToken') != null)
      {
        let roles = next.data["roles"] as Array<string>;
        if (roles) {
          var match = this.UserService.roleMatch(roles);
          if (match) return true;
          else {
            this.router.navigate(['/forbidden']);
            return false;
          }
        }
        else
          return true;
      }
      this.router.navigate(['/login']);
      return false;
  }
  
}
