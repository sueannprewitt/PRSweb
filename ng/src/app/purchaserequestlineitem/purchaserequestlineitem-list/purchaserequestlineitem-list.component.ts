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
  selector: 'app-purchaserequestlineitem-list',
  templateUrl: './purchaserequestlineitem-list.component.html',
  styleUrls: ['./purchaserequestlineitem-list.component.css']
})
export class PurchaserequestlineitemListComponent implements OnInit {

purchaseRequestAndLines : PurchaseRequestAndLines



  constructor(private PurchaserequestSvc: PurchaserequestService, 
  	private PurchaserequestlineitemSvc: PurchaserequestlineitemService,
  	private route: ActivatedRoute,
  	private router: Router) { }

  ngOnInit() {
  	this.route.paramMap	
  		.switchMap((params: ParamMap) =>
  			this.PurchaserequestlineitemSvc.GetByPurchaseRequestId(params.get('id')))
  		.subscribe((purchaseRequestAndLines:PurchaseRequestAndLines) => this.purchaseRequestAndLines = purchaseRequestAndLines);

  	  }

}
