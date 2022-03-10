import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CreditCard } from '../Models/CreditCard.Model';
import { CreditCardValidationResponse } from '../Models/CreditCardValidationResponse.Model';
import { ValidateCreditCardServiceService } from '../Services/validate-credit-card-service.service';

@Component({
  selector: 'app-validate-credit-card',
  templateUrl: './validate-credit-card.component.html',
  styleUrls: ['./validate-credit-card.component.css']
})
export class ValidateCreditCardComponent implements OnInit {
  ValdiateCreditCardForm!:FormGroup;
  printCreditCardValidationResponse : CreditCardValidationResponse = new CreditCardValidationResponse();
  constructor(private formBuilder: FormBuilder,private validateCreditCardServiceService: ValidateCreditCardServiceService) { }

  ngOnInit(): void {
    this.initializeRecordVisitForm();
  }

  initializeRecordVisitForm () {
    this.ValdiateCreditCardForm = this.formBuilder.group ({
      cardnumber: [null, [Validators.required]],

    });
  }

  successResponse  : boolean = false;
  ValidateCardNumber(event: any){
    event.preventDefault();

    var cardNumber = this.ValdiateCreditCardForm.controls['cardnumber'].value;

    // Call Service and Pass
    this.validateCreditCardServiceService.ValidateCreditCard(cardNumber).subscribe(
      (response:CreditCardValidationResponse) =>
      {
        this.successResponse = true;
        this.printCreditCardValidationResponse = response;
      },
      (error) => 
      {
        this.successResponse = false;

        console.log("ERR "+ JSON.stringify(error));

      }
    );
  }
}
