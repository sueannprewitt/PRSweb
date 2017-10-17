import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
//import { Observable } from 'rxjs';

import { PurchaseRequestLineItem } from '../models/PurchaseRequestLineItem';
import { PurchaseRequestAndLines } from '../models/PurchaseRequestAndLines';

const urlBase = 'http://localhost:57177/';
const mvcCtrl = 'PurchaseRequestLineItems/';
const url: string = urlBase + mvcCtrl;

@Injectable()
export class PurchaserequestlineitemService {

constructor(private http: Http) {}

		list(): Promise<PurchaseRequestLineItem[]> {
   			return this.http.get(url+'List')
   				.toPromise()
   				.then(resp => resp.json() as PurchaseRequestLineItem[])
   				.catch(this.handleError);
   		}
   		get(id): Promise<PurchaseRequestLineItem> {
   			return this.http.get(url+'Get/'+id)
   				.toPromise()
   				.then(resp => resp.json() as PurchaseRequestLineItem)
   				.catch(this.handleError);
   		}

      add(purchaseRequestLineItem:PurchaseRequestLineItem): Promise<any> {
        return this.http.post(url+'Add', purchaseRequestLineItem)
        .toPromise()
        .then(resp => resp.json() || {})
        .catch(this.handleError);
      }

      change(purchaseRequestLineItem:PurchaseRequestLineItem): Promise<any> {
        return this.http.post(url+'Change', purchaseRequestLineItem)
        .toPromise()
        .then(resp => resp.json() || {})
        .catch(this.handleError);
      }

      remove(purchaseRequestLineItem:PurchaseRequestLineItem): Promise<any> {
        return this.http.post(url+'Remove', purchaseRequestLineItem)
        .toPromise()
        .then(resp => resp.json() || {})
        .catch(this.handleError);
	}
  	GetByPurchaseRequestId(id): Promise<PurchaseRequestAndLines> {
   		return this.http.get(url+'GetByPurchaseRequestId/'+id)
   				.toPromise()
   				.then(resp => resp.json() as PurchaseRequestAndLines)
   				.catch(this.handleError);
   		}


private handleError(error: any): Promise<any> {  //returns a Promise of any type
  	console.error('An error has occurred', error);
  	return Promise.reject(error.message || error); //reject means failed (so whatever user tried to do didn't work)
  }

}