import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/switchMap';

import { PurchaseRequest } from '../../models/PurchaseRequest';
import { PurchaserequestService } from '../../services/purchaserequest.service';
import { PurchaseRequestAndLines } from '../../models/PurchaseRequestAndLines';
import { PurchaseRequestLineItem } from '../../models/PurchaseRequestLineItem';
import { PurchaserequestlineitemService } from '../../services/purchaserequestlineitem.service'


@Component({
  selector: 'app-selectreviewitem',
  templateUrl: './selectreviewitem.component.html',
  styleUrls: ['./selectreviewitem.component.css']
})
export class SelectreviewitemComponent implements OnInit {

purchaseRequestAndLines : PurchaseRequestAndLines
purchaserequest: PurchaseRequest
purchaserequestlineitem: PurchaseRequestLineItem

 accept() : void {
 		this.purchaserequest = this.purchaseRequestAndLines.PurchaseRequest;
        this.purchaserequest.Status = "ACCEPTED";  
        this.PurchaserequestSvc.change(this.purchaserequest) 
        .then(resp => {
          console.log(resp);
          this.router.navigate(["/purchaserequests"]); 
        });
    }

  reject() : void {
 		this.purchaserequest = this.purchaseRequestAndLines.PurchaseRequest;
        this.purchaserequest.Status = "REJECTED";  
        this.PurchaserequestSvc.change(this.purchaserequest) 
        .then(resp => {
          console.log(resp);
          this.router.navigate(["/purchaserequests"]); 
        });
    }


  constructor(private PurchaserequestSvc: PurchaserequestService, 
  	private PurchaserequestlineitemSvc: PurchaserequestlineitemService,
  	private route: ActivatedRoute,
  	private router: Router) { }

  ngOnInit() {
  	this.route.paramMap	
  		.switchMap((params: ParamMap) =>
  			this.PurchaserequestlineitemSvc.GetByPurchaseRequestId(params.get('id')))
  		.subscribe((purchaseRequestAndLines:PurchaseRequestAndLines) => this.purchaseRequestAndLines = purchaseRequestAndLines);
  			//all the data is now in purchaseRequestAndLines
  }

}
