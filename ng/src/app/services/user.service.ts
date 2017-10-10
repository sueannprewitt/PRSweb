import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
//import { Observable } from 'rxjs';

import { User } from '../models/User';

const urlBase = 'http://localhost:57177/';
const mvcCtrl = 'Users/';
const url: string = urlBase + mvcCtrl;


@Injectable()
export class UserService {
  constructor(private http: Http) {}

  		login(username: string, password: string): Promise<User[]> {
  			let parms = "UserName=" + username + "&Password=" + password;
 			 return this.http.get(url+'Login?' +parms)  //call to the server
  				.toPromise() //turns the response into a formal promise
  				.then(resp => resp.json() as User[]) //what to do with the response once it comes back
  				.catch(this.handleError);
  		}
   		list(): Promise<User[]> {
   			return this.http.get(url+'List')
   				.toPromise()
   				.then(resp => resp.json() as User[])
   				.catch(this.handleError);
   		}
   		get(id): Promise<User> {
   			return this.http.get(url+'Get/'+id)
   				.toPromise()
   				.then(resp => resp.json() as User)
   				.catch(this.handleError);
   		}

//any error that generates from above will get passed into here:

  private handleError(error: any): Promise<any> {  //returns a Promise of any type
  	console.error('An error has occurred', error);
  	return Promise.reject(error.message || error); //reject means failed (so whatever user tried to do didn't work)
  }

}
