import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Payment } from '../shared/payment.type';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';

 @Injectable()
export class PaymentService {

     paymentUrl: string;
    constructor(private http: Http) {

        this.paymentUrl = "http://localhost:53323/api/payment";
    }

     savePayment(payment: Payment): Observable<Payment> {

         debugger;
         let headerOptions = new Headers();
         headerOptions.append('Access-Control-Allow-Origin', '*');
         headerOptions.append('Access-Control-Allow-Headers', 'X-Requested-With,content-type');
         headerOptions.append('Content-Type', 'application/json; charset=utf-8');
         console.log(headerOptions);
         let options = new RequestOptions();
         options.headers = headerOptions;
         return this.http.post(this.paymentUrl, JSON.stringify(payment), options).map(this.extractData).catch(this.handleObservable);
    }

     extractData(res: Response) {
//         debugger;
         console.log(res);
         let body = res.json();
         return body || {};
     }

     handleObservable(error: Response) {
         
         
         
         //alert(JSON.stringify(error));
         return Observable.throw(JSON.stringify(error));
     }

}
