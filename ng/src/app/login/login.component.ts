import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
//import { NgForm } from '@angular/forms';
import { User } from '../models/User';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

username: string = "";
password: string = "";

user: User;

login(): void {
	let parms = "UserName=" + this.username + "&Password=" + this.password;
	this.http.get("http://localhost:57177/Users/Login?" + parms) //this makes the call to the server and passes in the data when the user enters their username and password
	.subscribe(data => { this.checkData(data); }); //data is then passed into the variable called data
}

checkData(data:any) : void {
	if (data.text().length == 0)
		console.log("NO DATA");
	else {
		console.log(data.json());
		this.user = data.json();
	}
}

  constructor(private http: Http) { }

  ngOnInit() {
  	this.http.get("http://localhost:57177/Users/Login?UserName=user&Password=user")
  	.subscribe(data => { console.log(data.json()); });
  }

}
