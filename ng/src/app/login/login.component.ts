import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import 'rxjs/add/operator/toPromise';

import { User } from '../models/User';
import { UserService } from '../services/user.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

username: string = "admin";
password: string = "admin";

user: User;

message: string = " ";

login(): void {
		this.message = "";
		this.UserSvc.login(this.username, this.password)
			.then(resp => this.checkData(resp));

	// let parms = "UserName=" + this.username + "&Password=" + this.password;
	 //this.http.get("http://localhost:57177/Users/Login?" + parms) //this makes the call to the server and passes in the data when the user enters their username and password
	//.subscribe(data => { this.checkData(data); }); //data is then passed into the variable called data
}

checkData(users: User[]) : void {
	if (users.length > 0) {
		this.user = users[0];

		console.log("");
		this.router.navigateByUrl("/home");
	} else {
		this.message = "USER NAME AND/OR PASSWORD NOT FOUND";
	}
	
}

  constructor(private UserSvc: UserService, private router: Router) { }

  ngOnInit() {
  	console.log("In LoginComponent");
  }

}
