import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { AppComponent } from './app.component';

import { AdminsModule } from './admins/admins.module';
import { DriversModule } from './drivers/drivers.module';
import { UsersModule } from './users/users.module';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    AdminsModule,
    DriversModule,
    UsersModule,
    ToastrModule.forRoot(),
    MDBBootstrapModule.forRoot(),
  ],
  providers: [],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
