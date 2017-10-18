import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { PurchaserequestService } from '../../services/purchaserequest.service';
import { PurchaseRequest } from '../../models/PurchaseRequest';
import 'rxjs/add/operator/switchMap';
import { PurchaseRequestAndLines } from '../../models/PurchaseRequestAndLines';
import { PurchaseRequestLineItem } from '../../models/PurchaseRequestLineItem';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/Product';
import { PurchaserequestlineitemService } from '../../services/purchaserequestlineitem.service';

@Component({
  selector: 'app-purchaserequestlineitem-edit',
  templateUrl: './purchaserequestlineitem-edit.component.html',
  styleUrls: ['./purchaserequestlineitem-edit.component.css']
})
export class PurchaserequestlineitemEditComponent implements OnInit {

purchaserequestlineitem: PurchaseRequestLineItem
products: Product[];

getProducts() {
	this.ProductSvc.list()
	.then(
		resp => {
			this.products = resp;
			console.log(resp);
		}
	);
}
	update() {
		this.PurchaserequestlineitemSvc.change(this.purchaserequestlineitem).then(
			resp => {
				console.log(resp);
				this.router.navigate(['/purchaserequestslineitems/' + this.purchaserequestlineitem.PurchaseRequestId]);
			}
			);
	}


  constructor(private PurchaserequestSvc: PurchaserequestService, 
  	private ProductSvc: ProductService,
  	private PurchaserequestlineitemSvc: PurchaserequestlineitemService, 
  	private route: ActivatedRoute,
  	private router: Router) { }

  ngOnInit() {
  	this.route.paramMap
  		.switchMap((params: ParamMap) =>
  			this.PurchaserequestlineitemSvc.get(params.get('id')))
  			.subscribe((purchaserequestlineitem: PurchaseRequestLineItem) => 
  				this.purchaserequestlineitem = purchaserequestlineitem);
  	this.getProducts();
  }

}
