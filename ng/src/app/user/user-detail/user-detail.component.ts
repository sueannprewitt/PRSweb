import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { User } from '../../models/User';
import { UserService } from '../../services/user.service';

import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {

	user: User;


  constructor(private UserSvc: UserService, private router: Router, 
  	private route: ActivatedRoute) { }

  ngOnInit() {
  		this.route.paramMap
  			.switchMap((params: ParamMap) =>
  				this.UserSvc.get(params.get('id')))
  			.subscribe((user: User) => this.user = user);
  }

}
