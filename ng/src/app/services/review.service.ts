import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
//import { Observable } from 'rxjs';

import { PurchaseRequest } from '../models/PurchaseRequest';
import { PurchaseRequestLineItem } from '../models/PurchaseRequestLineItem';

const urlBase = 'http://localhost:57177/';
const mvcCtrl = 'Review/';
const url: string = urlBase + mvcCtrl;

@Injectable()
export class ReviewService {

  constructor(private http: Http) {}
  
		review(): 	Promise<PurchaseRequest[]> {
   					return this.http.get(url+'Review')
   					.toPromise()
   					.then(resp => resp.json() as PurchaseRequest[])
   					.catch(this.handleError);
   }

 private handleError(error: any): Promise<any> {  
  	console.error('An error has occurred', error);
  	return Promise.reject(error.message || error); 
  }
}
