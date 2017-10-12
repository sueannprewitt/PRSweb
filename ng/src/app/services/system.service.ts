import { Injectable } from '@angular/core';

import { User } from '../models/User';



@Injectable()
export class SystemService {

	LoggedInUser: User;

	//methods to get, set and check to see if there is any value:
	getLoggedIn(): User {
		console.log("SystemService", "getLoggedIn()", this.LoggedInUser);
		return this.LoggedInUser;
	}

	setLoggedIn(user: User): void {
		console.log("SystemService", "setLoggedIn()", user);
		this.LoggedInUser = user;
	}

	IsLoggedIn(): boolean {
		console.log("SystemService", "IsLoggedIn()", this.LoggedInUser != null);
		return this.LoggedInUser != null;
	}


  constructor() { }

}
