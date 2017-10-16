import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { PurchaseRequest } from '../../models/PurchaseRequest';
import { PurchaserequestService } from '../../services/purchaserequest.service';

import 'rxjs/add/operator/switchMap';

import { Review } from '../../models/Review';


@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {

purchaserequests: PurchaseRequest[];

 	review() : void {
        this.PurchaserequestSvc.review() //calls the change in service
        .then(resp => {
          console.log(resp);
         this.purchaserequests = resp;
        });
    } 
  constructor(private PurchaserequestSvc: PurchaserequestService, private router: Router, 
  	private route: ActivatedRoute) { }

  ngOnInit() {
  	this.review()
  }

}
