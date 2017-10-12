import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
//import { Observable } from 'rxjs';

import { PurchaseRequest } from '../models/PurchaseRequest';

const urlBase = 'http://localhost:57177/';
const mvcCtrl = 'PurchaseRequests/';
const url: string = urlBase + mvcCtrl;


@Injectable()
export class PurchaserequestService {
constructor(private http: Http) {}

  		list(): Promise<PurchaseRequest[]> {
   			return this.http.get(url+'List')
   				.toPromise()
   				.then(resp => resp.json() as PurchaseRequest[])
   				.catch(this.handleError);
   		}
   		get(id): Promise<PurchaseRequest> {
   			return this.http.get(url+'Get/'+id)
   				.toPromise()
   				.then(resp => resp.json() as PurchaseRequest)
   				.catch(this.handleError);
   		}

      add(purchaseRequest:PurchaseRequest): Promise<any> {
        return this.http.post(url+'Add', PurchaseRequest)
        .toPromise()
        .then(resp => resp.json() || {})
        .catch(this.handleError);
      }

      change(purchaseRequest:PurchaseRequest): Promise<any> {
        return this.http.post(url+'Change', PurchaseRequest)
        .toPromise()
        .then(resp => resp.json() || {})
        .catch(this.handleError);
      }

      remove(purchaseRequest:PurchaseRequest): Promise<any> {
        return this.http.post(url+'Remove', PurchaseRequest)
        .toPromise()
        .then(resp => resp.json() || {})
        .catch(this.handleError);
      }

//any error that generates from above will get passed into here:

  private handleError(error: any): Promise<any> {  //returns a Promise of any type
  	console.error('An error has occurred', error);
  	return Promise.reject(error.message || error); //reject means failed (so whatever user tried to do didn't work)
  }

}