
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
    errorMessage: object;
    data: Array<string>;
    constructor(private paymentService: PaymentService) {
        this.payment = new Payment();
        this.data = new Array();
        this.operationInfo = new OperationInfo();
        this.errorMessage = new Object();
    }

    SaveClicked() {

        
        
        var objResult = this.paymentService.savePayment(this.payment).subscribe(r => {

            this.payment = r;
            //this.ResetPayment();
        }, (error) => this.ProcessError(error));
        console.log(JSON.stringify(this.errorMessage));
        debugger;
        
    }

    ProcessError(res: Response) {
     
       // res.json().then(body => alert(body));
        
      alert();
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
