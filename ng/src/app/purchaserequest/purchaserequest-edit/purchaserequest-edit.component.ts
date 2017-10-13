import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { PurchaserequestService } from '../../services/purchaserequest.service';

import 'rxjs/add/operator/switchMap';

import { PurchaseRequest } from '../../models/PurchaseRequest';
import { UserService } from '../../services/user.service';
import { User } from '../../models/User';


@Component({
  selector: 'app-purchaserequest-edit',
  templateUrl: './purchaserequest-edit.component.html',
  styleUrls: ['./purchaserequest-edit.component.css']
})
export class PurchaserequestEditComponent implements OnInit {

	purchaserequest: PurchaseRequest;
	users: User[];

	update() {
		this.PurchaserequestSvc.change(this.purchaserequest).then(
			resp => {
				console.log(resp);
				this.router.navigate(['/purchaserequests']);
			}
			)
	}
	getUsers(): void {
		this.UserSvc.list().then(
			resp => this.users = resp);
}

  constructor(private PurchaserequestSvc: PurchaserequestService, 
  	private UserSvc: UserService, 
  	private route: ActivatedRoute,
  	private router: Router) { }

  ngOnInit() {
  	this.route.paramMap	
  		.switchMap((params: ParamMap) =>
  			this.PurchaserequestSvc.get(params.get('id')))
  		.subscribe((purchaserequest:PurchaseRequest) => this.purchaserequest = purchaserequest);

  	this.getUsers();
  }

}
