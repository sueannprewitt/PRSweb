import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { PurchaserequestService } from '../../services/purchaserequest.service';
import { PurchaseRequest } from '../../models/PurchaseRequest';
import { SystemService } from '../../services/system.service';
import { PurchaseRequestAndLines } from '../../models/PurchaseRequestAndLines';
import { PurchaseRequestLineItem } from '../../models/PurchaseRequestLineItem';
import { PurchaserequestlineitemService } from '../../services/purchaserequestlineitem.service';
import { Product } from '../../models/Product';
import { ProductService } from '../../services/product.service';


@Component({
  selector: 'app-purchaserequestlineitem-add',
  templateUrl: './purchaserequestlineitem-add.component.html',
  styleUrls: ['./purchaserequestlineitem-add.component.css']
})
export class PurchaserequestlineitemAddComponent implements OnInit {

purchaserequest : PurchaseRequest
purchaseRequestAndLines : PurchaseRequestAndLines
purchaserequestlineitem : PurchaseRequestLineItem = new PurchaseRequestLineItem(0, 1, 0, 0);
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

 add() {
    this.purchaserequestlineitem.PurchaseRequestId = this.purchaserequest.ID;
    this.PurchaserequestlineitemSvc.add(this.purchaserequestlineitem)

    .then(
      resp => {
        console.log(resp);
        this.router.navigate(["/purchaserequestlineitems/" + this.purchaserequest.ID]);
      });
  }


  constructor(private SystemSvc: SystemService,
  	private PurchaserequestSvc: PurchaserequestService,
  	private ProductSvc: ProductService,
  	private PurchaserequestlineitemSvc: PurchaserequestlineitemService, 
  	private router: Router,
  	private route: ActivatedRoute) { }

  ngOnInit() {
	
	this.route.paramMap	
  		.switchMap((params: ParamMap) =>
  			this.PurchaserequestSvc.get(params.get('id')))
  		.subscribe((purchaserequest:PurchaseRequest) => this.purchaserequest = purchaserequest);
  	this.getProducts();

  }

}
