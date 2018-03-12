using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interface
{
    public interface IDataOperation
    {
        bool SavePaymentData(Payment payment, out Operation opr);
    }
}
