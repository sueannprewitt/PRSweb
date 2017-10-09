import { Component, OnInit } from '@angular/core';

import { Menu } from './menu';

@Component({
  selector: 'menu-comp',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit { //like inheritance in C#.

	name = "Menu Component";

	menus: Menu[] = [
	new Menu("HOME", "/home", "Home menu item"),
	new Menu("LOGIN", "/login", "Login to the app"),
	new Menu("ABOUT", "/about", "About menu item"),
	new Menu("CONTACT", "/contact", "About me"),
	new Menu("HELP", "/help", "When you need help")
	]

  constructor() { } //initializes data in a typescript class

  ngOnInit() {
  }

}