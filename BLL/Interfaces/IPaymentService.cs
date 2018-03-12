using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
   public interface IPaymentService
    {

         Operation AddPayment(Payment Payment);

       
    }
}
