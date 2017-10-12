export class PurchaseRequest{
	
	ID: number;
	Description: string;
	Justification: string;
	DateNeeded: Date;
	DeliveryMode: string;
	Status: string;
	Total: number;
	SubmittedDate: Date;
	UserId: number
		
	constructor(
		ID: number,
		Description: string,
		Justification: string,
		DateNeeded: Date,
		DeliveryMode: string,
		Status: string,
		Total: number,
		SubmittedDate: Date,
		UserId: number
			)

	 {
	 	this.ID = ID;
	 	this.Description = Description;
	 	this.Justification = Justification;
	 	this.DateNeeded = DateNeeded;
	 	this.DeliveryMode = DeliveryMode;
	 	this.Status = Status;
	 	this.Total = Total;
	 	this.SubmittedDate = SubmittedDate;
	 	this.UserId = UserId
	 		 	
	 	}


}