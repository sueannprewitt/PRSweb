import { BrowserModule } from '@angular/platform-browser'; //imports are Javascript
import { NgModule } from '@angular/core';  //data inside the curly braces is the class name; from  - file name (like the references)
// the things you need from Angular will be in the @angular files
import { HttpModule } from '@angular/http';  //allows us to make AJAX calls
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { HeadingComponent } from './heading/heading.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { HelpComponent } from './help/help.component';
import { LoginComponent } from './login/login.component';
import { UserService } from './services/user.service';
import { UserListComponent } from './user/user-list/user-list.component';
import { UserDetailComponent } from './user/user-detail/user-detail.component';


@NgModule({  //decorator (@ sign) - never use semi-colons. The module has to know about all components. This is a module thing.
  declarations: [  //Javascript objects - a set of key value pairs seperated by commas.  These are keys.  Data are arrays. They take components or modules.
    AppComponent, 
    MenuComponent, 
    HeadingComponent, 
    HomeComponent, 
    AboutComponent, 
    ContactComponent, 
    HelpComponent, 
    LoginComponent, 
    UserListComponent, UserDetailComponent  //Your components get added here so the module knows about them.
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpModule
  ],
  providers: [
    UserService
  ],
  bootstrap: [AppComponent] //this is a component that is going to start up automatically when we fire up our application
})
export class AppModule { }  //export just says to Angular that other components outside of this can use this - makes it available throughout your application
//when you create a new component - you MUST tell the module about it - or it won't be accessible.  CLI will tell the module 
//about component for you.