export class CreditCardValidationResponse {
    cardName :string;
    cardNumber :string;
    validationStatus :boolean;

    constructor(
        cardName: string ="",
        cardNumber: string ="",
        validationStatus: boolean =false,    
        ) 
    {
        this.cardName = cardName;
        this.cardNumber = cardNumber;
        this.validationStatus = validationStatus;
    }
}