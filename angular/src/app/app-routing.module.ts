import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignUpComponent } from './user/sign-up/sign-up.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { AuthGuard } from '../auth/auth.guard';
import { AccountComponent } from './account/account.component';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { ShopComponent } from './shop/shop.component';
import { CartComponent } from './cart/cart.component';

const routes: Routes = [
  { path: 'Account', component: AccountComponent,canActivate:[AuthGuard] },
  { path: 'adminPanel', component: AdminPanelComponent, canActivate: [AuthGuard] , data: { roles: ['admin'] }},
  { path: 'forbidden', component: ForbiddenComponent, canActivate: [AuthGuard] },
  { path: 'cart', component: CartComponent },

  {
    path: 'signup', component: SignUpComponent
},
{
  path: 'shop', component: ShopComponent
},
{
    path: 'login', component: SignInComponent
}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
