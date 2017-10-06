import { Component } from '@angular/core';

@Component({
  selector: 'app-root', 
  templateUrl: './app.component.html', 
  //template: '<h1>Template</h1>', (hard put in line instead of using the file)
  styleUrls: ['./app.component.css']
  //styles: ['h1 {color: blue;}'] (hard put in line instead of using the file)
})
export class AppComponent { //export allows the class to be used throughout the application with the import statement. ALWAYS include export!
  title = '.Net Bootcamp';
  scriptingLanguage = 'Typescript';
}
