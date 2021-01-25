import { Component, OnInit, Input  } from '@angular/core';
import { NgForm } from '@angular/forms';

import { Warehouse } from "../../../models/warehouse";
import { WarehouseService } from "../../../services/warehouse.service";
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'create-form',
  templateUrl: './create-form.component.html',
  styleUrls: ['./create-form.component.scss']
})
export class CreateFormComponent implements OnInit {
	warehouse: Warehouse = new Warehouse();
	@Input() warehouses: Warehouse[];

  constructor(private warehouseService: WarehouseService, private toaster: ToastrService) { }

  ngOnInit() {
  }

  createWarehouse(warehouse: Warehouse): void {
  	this.warehouseService.createWarehouse(warehouse).subscribe(resp => this.warehouses.push({...warehouse}));
    this.toaster.success(`New warehouse was created successfully`);
  }
}