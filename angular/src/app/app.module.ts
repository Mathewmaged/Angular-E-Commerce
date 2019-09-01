import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignUpComponent } from './user/sign-up/sign-up.component';
import { FormsModule} from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { UserService } from './shared/user.service';
import { HttpClientModule } from '@angular/common/http';
import { AccountComponent } from './account/account.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { AuthGuard } from '../auth/auth.guard';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { ShopComponent } from './shop/shop.component';
import { CartComponent } from './cart/cart.component';
import {StorageServiceModule} from 'ngx-webstorage-service'
import { LocalStorageService } from './config.service';


@NgModule({
  declarations: [
    AppComponent,
    SignUpComponent,
    AccountComponent,
    SignInComponent,
    AdminPanelComponent,
    ForbiddenComponent,
    HeaderComponent,
    FooterComponent,
    ShopComponent,
    CartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    HttpClientModule,
    StorageServiceModule
  ],
  providers: [UserService,AuthGuard,LocalStorageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
