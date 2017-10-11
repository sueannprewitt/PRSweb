import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { VendorService } from '../../services/vendor.service';
import { Vendor } from '../../models/Vendors';

@Component({
  selector: 'app-vendor-add',
  templateUrl: './vendor-add.component.html',
  styleUrls: ['./vendor-add.component.css']
})
export class VendorAddComponent implements OnInit {

	vendor: Vendor = new Vendor (0, '', '', '', '', '', '', '', false); //these are defaults - what's going to come up on the screen

	add() {
		this.VendorSvc.add(this.vendor).then(
			resp => {
				console.log(resp);
				this.router.navigate(["/vendors"]);
			});
	}


  constructor(private VendorSvc: VendorService, private router: Router) { }

  ngOnInit() {
  }

}
