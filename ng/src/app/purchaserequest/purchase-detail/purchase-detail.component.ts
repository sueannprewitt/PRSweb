import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { PurchaseRequest } from '../../models/PurchaseRequest';
import { PurchaserequestService } from '../../services/purchaserequest.service';

import 'rxjs/add/operator/switchMap';


@Component({
  selector: 'app-purchase-detail',
  templateUrl: './purchase-detail.component.html',
  styleUrls: ['./purchase-detail.component.css']
})
export class PurchaseDetailComponent implements OnInit {

	purchaserequest: PurchaseRequest;

 	 remove() {
  		 console.log("remove()");
   		 this.PurchaserequestSvc.remove(this.purchaserequest)
        .then(resp => {
          console.log(resp);
          this.router.navigate(["/purchaserequests"]);
        });
  }

   review() : void {
        this.purchaserequest.Status = "REVIEW";  //sets purchaserequest status to review
        this.PurchaserequestSvc.change(this.purchaserequest) //calls the change in service
        .then(resp => {
          console.log(resp);
          this.router.navigate(["/purchaserequests"]); //navigates to the list component
        });
    } 

  constructor(private PurchaserequestSvc: PurchaserequestService, private router: Router, 
  	private route: ActivatedRoute) { }

  ngOnInit() {
  	this.route.paramMap
  			.switchMap((params: ParamMap) =>
  				this.PurchaserequestSvc.get(params.get('id')))
  			.subscribe((purchaserequest: PurchaseRequest) => this.purchaserequest = purchaserequest);
  }

}
