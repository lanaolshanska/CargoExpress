import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Warehouse } from "../models/warehouse";

@Injectable({
  providedIn: 'root'
})
export class WarehouseService {

	private readonly warehouseUrl = 'http://localhost:5000/api/warehouse/';

	constructor(private http: HttpClient) { }

	getWarehouses(): Observable<Warehouse[]> {
		return this.http.get<Warehouse[]>(this.warehouseUrl);
	}

	getWarehouse(id: number): Observable<Warehouse> {
		return this.http.get<Warehouse>(this.warehouseUrl + id);
	}

	createWarehouse(warehouse: Warehouse): Observable<Warehouse>{
		return this.http.post<Warehouse>(this.warehouseUrl, warehouse);
	}

	editWarehouse(id: number, warehouse: Warehouse): Observable<Warehouse>{
		return this.http.put<Warehouse>(this.warehouseUrl + id, warehouse);
	}
}