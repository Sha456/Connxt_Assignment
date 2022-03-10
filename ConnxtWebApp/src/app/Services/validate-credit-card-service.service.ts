import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { CreditCard } from '../Models/CreditCard.Model';
import { CreditCardValidationResponse } from '../Models/CreditCardValidationResponse.Model';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ValidateCreditCardServiceService {

  constructor( private httpClient: HttpClient) { }
  private host = environment.host;

  ValidateCreditCard(creditCardNumb: string): Observable<CreditCardValidationResponse> {

    var cc : CreditCard = new CreditCard();
    cc.creditCardNumber = creditCardNumb.toString();
    console.log(JSON.stringify(cc));
    const headerDict = {
      'Content-Type': 'application/json',
      'responseType': 'json',
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Methods':'DELETE, POST, GET, OPTIONS',
    };

  let options = { headers: headerDict };
    return this.httpClient.post<CreditCardValidationResponse>(this.host + "/api/Payment/validatecc", JSON.stringify(cc), options)

      .pipe(map((x:CreditCardValidationResponse) => {
        return x;
      }));
  }
}