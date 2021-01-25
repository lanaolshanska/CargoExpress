import {IWarehouse} from "./iwarehouse"

export class Warehouse implements IWarehouse{
	id: number;
	state: string;
	city: string;
	postcode: string;
	phone: string;
}

