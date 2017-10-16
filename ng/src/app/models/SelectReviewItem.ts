export class SelectReviewItem{
	
	Id: number;
	Quantity: number;
	ProductId: number;
	PurchaseRequestId: number;
			
	constructor(
		Id: number,
		Quantity: number,
		ProductId: number,
		PurchaseRequestId: number,
		)

	 {
	 	this.Id = Id;
	 	this.Quantity = Quantity;
	 	this.ProductId = ProductId;
	 	this.PurchaseRequestId = PurchaseRequestId;
	 		 		 	
	 	}


}