
import { Component } from '@angular/core';
import { Payment } from '../../../shared/payment.type';
import { PaymentService } from '../../../services/payment.services';
import { OperationInfo } from '../../../shared/OperationInfo.type';

@Component({
    selector: 'payment',
    templateUrl: './payment.component.html'
})
export class PaymentComponent {

    operationInfo: OperationInfo;
    payment: Payment;
    errorMessage: any;
    serverMessage: Array<string>;
    statusMessage: string;
    data: Array<string>;
    constructor(private paymentService: PaymentService) {
        this.payment = new Payment();
        this.data = new Array();
        this.operationInfo = new OperationInfo();
        this.errorMessage = {};
        this.statusMessage = "";
        this.serverMessage = new Array();
    }

    SaveClicked() {

        var objResult = this.paymentService.savePayment(this.payment).subscribe(r => {
            this.payment = r;
            //this.ResetPayment();
        }, (error) => this.ProcessError(error));// this.errorMessage = error);
       
        //debugger;
        
    }

    ProcessError(res: any) {
     
        // res.json().then(body => alert(body));
        debugger;  
        this.errorMessage = res;
        console.log("after error : " + this.errorMessage);
        JSON.parse( this.errorMessage.toString(), (key, value) => {
            if (key == "_body") {
                //console.log(key + " , " + value);
                let _bodyItem: any = value;
                this.errorMessage = _bodyItem;
                console.log(this.errorMessage)
                // this.statusMessage = v[0];
                JSON.parse(this.errorMessage, (key, value) => {
                    this.serverMessage.push(value);

                   
                });
            }
            
        });

        debugger;
    }
    ResetPayment() {
        debugger;
        this.payment.AccountName = "";
        this.payment.AccountNumber = "";
        this.payment.BsbNumber = "";
        this.payment.Reference = "";
        this.payment.Amount = 0.00;
    }

    
}
