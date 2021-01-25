import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

import { ListComponent } from './components/warehouse/list/list.component';
import { CreateFormComponent } from './components/warehouse/create-form/create-form.component';
import { EditFormComponent } from './components/warehouse/edit-form/edit-form.component';

@NgModule({
  declarations: [
  	ListComponent,
  	CreateFormComponent,
  	EditFormComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    MDBBootstrapModule.forRoot(),
  ]
})
export class AdminsModule { }
