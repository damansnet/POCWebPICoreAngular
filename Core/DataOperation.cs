using Core.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Core
{
    public class DataOperation : IDataOperation
    {

        private readonly string _filePath;

        public DataOperation(string filePath)
        {
            _filePath = filePath;
        }

        public bool SavePaymentData(Payment payment, out Operation opr)
        {
            bool flag = false;
            opr = new Operation()
            {
                EntityId = 0,
                ErrorMessage = "Failed to save",
                OperationStatus = Constants.OperationStatus.NotSuccessful,
                InfoMessage = ""
            };
            try
            {
                if (!File.Exists(_filePath))
                {
                    return flag;
                }



                using (FileStream fs = new FileStream(_filePath, FileMode.Append))
                {

                    StreamWriter stream = new StreamWriter(fs);
                    stream.WriteLine("{0},{1},{2},{3},{4}", payment.BsbNumber, payment.AccountNumber, payment.AccountName, payment.Reference, payment.Amount.ToString());
                    stream.Close();
                    fs.Close();
                }
                opr = new Operation()
                {
                    EntityId = 1,
                    ErrorMessage = "",
                    OperationStatus = Constants.OperationStatus.Successful,
                    InfoMessage = "Payment is saved"
                };
            }
            catch (Exception ex)
            {

                opr.ErrorMessage = "Failed to write to file: " + ex.Message;
            }
            return flag;
        }
    }
}
