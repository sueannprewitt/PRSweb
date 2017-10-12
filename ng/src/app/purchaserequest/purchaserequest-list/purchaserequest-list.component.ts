import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/toPromise';

import { PurchaseRequest } from '../../models/PurchaseRequest';
import { PurchaserequestService } from '../../services/purchaserequest.service';

@Component({
  selector: 'app-purchaserequest-list',
  templateUrl: './purchaserequest-list.component.html',
  styleUrls: ['./purchaserequest-list.component.css']
})
export class PurchaserequestListComponent implements OnInit {

purchaserequests: PurchaseRequest[];

	getPurchaseRequests(): void {
		this.PurchaserequestSvc.list()
			.then(resp => this.purchaserequests = resp);  
	}


  constructor(private PurchaserequestSvc: PurchaserequestService) { }

  ngOnInit() {
  	this.getPurchaseRequests();
  }

}
