import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { HelpComponent } from './help/help.component';
import { LoginComponent } from './login/login.component';
import { UserListComponent } from './user/user-list/user-list.component';
import { UserDetailComponent } from './user/user-detail/user-detail.component';
import { UserEditComponent } from './user/user-edit/user-edit.component';
import { UserAddComponent } from './user/user-add/user-add.component';
import { VendorListComponent } from './vendor/vendor-list/vendor-list.component';
import { VendorDetailComponent } from './vendor/vendor-detail/vendor-detail.component';
import { VendorAddComponent } from './vendor/vendor-add/vendor-add.component';
import { VendorEditComponent } from './vendor/vendor-edit/vendor-edit.component';
import { ProductListComponent } from './product/product-list/product-list.component';
import { ProductDetailComponent } from './product/product-detail/product-detail.component';
import { ProductAddComponent } from './product/product-add/product-add.component';
import { ProductEditComponent } from './product/product-edit/product-edit.component';
import { PurchaserequestListComponent } from './purchaserequest/purchaserequest-list/purchaserequest-list.component';
import { PurchaseDetailComponent } from './purchaserequest/purchase-detail/purchase-detail.component';
import { PurchaserequestAddComponent } from './purchaserequest/purchaserequest-add/purchaserequest-add.component';
import { PurchaserequestEditComponent } from './purchaserequest/purchaserequest-edit/purchaserequest-edit.component';
import { ReviewComponent } from './review/review/review.component';


const routes: Routes = [
	{ path: "", redirectTo: "/home", pathMatch: "full" },
	{ path: "home", component: HomeComponent },
	{ path: "login", component: LoginComponent },
	{ path: "users", component: UserListComponent },
	{ path: "users/detail/:id", component: UserDetailComponent },
	{ path: "users/edit/:id", component: UserEditComponent },
	{ path: "users/add", component: UserAddComponent},
	{ path: "about", component: AboutComponent },
	{ path: "contact", component: ContactComponent },
	{ path: "help", component: HelpComponent },
	{ path: "vendors", component: VendorListComponent },
	{ path: "vendors/detail/:id", component: VendorDetailComponent },
	{ path: "vendors/add", component: VendorAddComponent },
	{ path: "vendors/edit/:id", component: VendorEditComponent},
	{ path: "products", component: ProductListComponent },
	{ path: "products/detail/:id", component: ProductDetailComponent },
	{ path: "products/add", component: ProductAddComponent },
	{ path: "products/edit/:id", component: ProductEditComponent },
	{ path: "purchaserequests", component: PurchaserequestListComponent},
	{ path: "purchaserequests/detail/:id", component: PurchaseDetailComponent},
	{ path: "purchaserequests/add", component: PurchaserequestAddComponent},
	{ path: "purchaserequests/edit/:id", component: PurchaserequestEditComponent},
	{ path: "review", component: ReviewComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
