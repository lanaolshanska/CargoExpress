import { Component, OnInit, ViewChild, ElementRef } from '@angular/core'

import { Warehouse } from "../../../models/warehouse";
import { WarehouseService } from "../../../services/warehouse.service";

@Component({
  selector: 'warehouse-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
})
export class ListComponent implements OnInit {
	warehouses: Warehouse[];
	headers: string[] = ["Id", "State", "City", "Phone", "Postcode"];
	selectedRow: number;
	selectedId: number;

  constructor(private warehouseService: WarehouseService) { }

  ngOnInit() {
  	this.warehouseService.getWarehouses().subscribe((data: Warehouse[]) => this.warehouses = data);
  }

  selectRow(id: number, warehouseId: number){
  	this.selectedRow = id;
  	this.selectedId = warehouseId;
  }
}