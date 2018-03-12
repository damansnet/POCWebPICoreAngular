using BLL.Interfaces;
using Core.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class PaymentService : IPaymentService
    {
        private readonly IDataOperation _dataOperation;

        public PaymentService(IDataOperation dataOperation)
        {
            _dataOperation = dataOperation;
        }

        public Operation AddPayment(Payment Payment)
        {
            Operation result;
            bool flag=_dataOperation.SavePaymentData(Payment, out result);

            return result;
        }

       
    }
}
