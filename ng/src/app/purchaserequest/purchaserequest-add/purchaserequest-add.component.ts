import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { PurchaserequestService } from '../../services/purchaserequest.service';
import { PurchaseRequest } from '../../models/PurchaseRequest';

import { UserService } from '../../services/user.service';
import { User } from '../../models/User';

import { SystemService } from '../../services/system.service';

@Component({
  selector: 'app-purchaserequest-add',
  //templateUrl: './purchaserequest-add.component.html',
  template: "<h1 *ngIf='loggedInUser'>{{loggedInUser.UserName}}</h1>",
  styleUrls: ['./purchaserequest-add.component.css']
})
export class PurchaserequestAddComponent implements OnInit {

	purchaserequest: PurchaseRequest = new PurchaseRequest (0, '', '', new Date() , '', '', 0, new Date(), 0); //these are defaults - what's going to come up on the screen
	users: User[];

	add() {
		this.PurchaserequestSvc.add(this.purchaserequest).then(
			resp => {
				console.log(resp);
				this.router.navigate(["/purchaserequests"]);
			});
	}
	getUsers(): void {
		this.UserSvc.list().then(
			resp => this.users = resp);
}
		loggedInUser: User;

  constructor(private PurchaserequestSvc: PurchaserequestService, 
  	private SystemSvc: SystemService,
  	private UserSvc: UserService, 
  	private router: Router) { }

  ngOnInit() {
  	this.getUsers();

  	if(!this.SystemSvc.IsLoggedIn()) {
  		this.router.navigateByUrl("/login");
  	}
  	this.loggedInUser = this.SystemSvc.getLoggedIn();
  }

  }

}
