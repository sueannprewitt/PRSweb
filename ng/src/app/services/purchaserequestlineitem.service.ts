import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
//import { Observable } from 'rxjs';

import { PurchaseRequestLineItem } from '../models/PurchaseRequestLineItem';

const urlBase = 'http://localhost:57177/';
const mvcCtrl = 'PurchaseRequestLineItems/';
const url: string = urlBase + mvcCtrl;

@Injectable()
export class PurchaserequestlineitemService {

//stopped here!!!!!!!


  constructor() { }

}
