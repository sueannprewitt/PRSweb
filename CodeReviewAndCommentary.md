# PrsWeb by Sue Ann Prewitt

## Back-end C#/EF/MVC

Comments in the User.cs and UsersController.cs files are very good.

On line 22 of PurchaseRequestsController.cs, the comment about the user if JsonNetResult says: `//changes the way that dates are decoded in Json` That may not be descriptive enough after a bit more time passes as to why you'd use JsonNetResult in the future.

Overall your code is well done. Keep up the good work.

## Front-end Angular/Typescript

The app.module.ts and app-routing.module.ts look good. With all the imports, you might consider looking at the alternative of using the SharedModule and CoreModule we talked about in class. It would help eliminate the multitudes of import statements.

There is a small inconsistency with the Vendors.ts file. The class is Vendor. Probably better to keep the file name and the class names consistent and probably singular.

It would probably be worthwhile to add some commentary to the PurchaseRequestAndLines.ts and Review.ts as to what they were created for and why they were structured like they are.

I'd suggest it might be good to do a complete commenting of all the user components and the system service in the project and what the individual lines of code do and why. They would be a good place to refer back to the next time you need to do Angular.

_A note: Google just upgraded Angular to v5. The only significant change I'm aware of has to do with services and the change from using `Http` to using `HttpClient`. I have it on my list to look into the differences, but have not done so yet. Just so you know._

## Summary

You did an excellent job on this project. I believe the copious notes you took will serve you well. I'd suggest scanning them into digitial copies.

Also, if with all those notes, you decide to write a book on how to survive my boot camp, I'll buy the first copy (signed of course!). ;)