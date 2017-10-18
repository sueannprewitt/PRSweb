import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { PurchaseRequest } from '../../models/PurchaseRequest';
import { PurchaserequestService } from '../../services/purchaserequest.service';

import 'rxjs/add/operator/switchMap';
import { PurchaseRequestAndLines } from '../../models/PurchaseRequestAndLines';
import { PurchaseRequestLineItem } from '../../models/PurchaseRequestLineItem';
import { PurchaserequestlineitemService } from '../../services/purchaserequestlineitem.service'


@Component({
  selector: 'app-purchaserequestlineitem-detail',
  templateUrl: './purchaserequestlineitem-detail.component.html',
  styleUrls: ['./purchaserequestlineitem-detail.component.css']
})
export class PurchaserequestlineitemDetailComponent implements OnInit {

purchaserequestlineitem: PurchaseRequestLineItem
purchaserequest: PurchaseRequest

remove() {
  		 console.log("remove()");
  		 this.PurchaserequestlineitemSvc.remove(this.purchaserequestlineitem)
        .then(resp => {
          console.log(resp);
          this.router.navigate(["/purchaserequestlineitems/" + this.purchaserequestlineitem.PurchaseRequestId]);
        });
  }


  constructor(private PurchaserequestSvc: PurchaserequestService, 
  	private PurchaserequestlineitemSvc: PurchaserequestlineitemService,
  	private router: Router, 
  	private route: ActivatedRoute) { }

  ngOnInit() {
this.route.paramMap
  		.switchMap((params: ParamMap) =>
  			this.PurchaserequestlineitemSvc.get(params.get('id')))
  			.subscribe((purchaserequestlineitem: PurchaseRequestLineItem) => 
  				this.purchaserequestlineitem = purchaserequestlineitem);

  }
	


}
