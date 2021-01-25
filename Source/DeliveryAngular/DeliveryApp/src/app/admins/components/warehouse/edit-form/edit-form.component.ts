import { Component, OnInit, Input, ViewChild } from '@angular/core';

import { Warehouse } from "../../../models/warehouse";
import { WarehouseService } from "../../../services/warehouse.service";
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'edit-form',
  templateUrl: './edit-form.component.html',
  styleUrls: ['./edit-form.component.scss']
})
export class EditFormComponent implements OnInit {
	@Input() warehouses: Warehouse[];
	@Input() selectedId: number;
  @Input() selectedRow: number;

	selectedWarehouse: Warehouse = new Warehouse();

  constructor(private warehouseService: WarehouseService, private toaster: ToastrService) { }

  ngOnInit() {
  }

  getWarehouse(id: number) {
  	this.warehouseService.getWarehouse(id).subscribe(warehouse => this.selectedWarehouse = warehouse);
  }

  editWarehouse(id: number, warehouse: Warehouse) {
    this.warehouseService.editWarehouse(id, warehouse).subscribe(warehouse => this.warehouses[this.selectedRow] = warehouse);
    this.toaster.success(`Warehouse on row ${this.selectedRow + 1} was edited`);
  }
}
