import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { PurchaserequestService } from '../../services/purchaserequest.service';
import { PurchaseRequest } from '../../models/PurchaseRequest';

import { UserService } from '../../services/user.service';
import { User } from '../../models/User';

import { SystemService } from '../../services/system.service';

@Component({
  selector: 'app-purchaserequest-add',
  templateUrl: './purchaserequest-add.component.html',
  // template: "<h1 *ngIf='loggedInUser'>{{loggedInUser.UserName}}</h1>",
  styleUrls: ['./purchaserequest-add.component.css']
})
export class PurchaserequestAddComponent implements OnInit {

  dateNeeded: Date;

  setDateNeeded() {
    this.dateNeeded = new Date();
    this.dateNeeded.setDate(this.dateNeeded.getDate() + 7);
  }

	loggedInUser: User;
  purchaserequest: PurchaseRequest = 
    new PurchaseRequest (0, '', '', this.dateNeeded, '', 'New', 0, new Date(), 0); //these are defaults - what's going to come up on the screen
  
  add() {
    console.log(this.purchaserequest);
    this.PurchaserequestSvc.add(this.purchaserequest).then(
      resp => {
        console.log(resp);
        this.router.navigate(["/purchaserequests"]);
      });
  }

  constructor(private PurchaserequestSvc: PurchaserequestService, 
  	private SystemSvc: SystemService,
  	private UserSvc: UserService, 
  	private router: Router) { }

  ngOnInit() {
  	
  	if(!this.SystemSvc.IsLoggedIn()) {
  		this.router.navigateByUrl("/login");
  	}
  	this.loggedInUser = this.SystemSvc.getLoggedIn();
    console.log(this.loggedInUser);
    this.purchaserequest.UserId = this.loggedInUser.ID;
  }

  }


