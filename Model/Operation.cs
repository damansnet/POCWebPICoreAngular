using System;
using System.Collections.Generic;
using System.Text;
using static Model.Constants;

namespace Model
{
   public class Operation
    {

        public int EntityId { get; set; }

        public string ErrorMessage { get; set; }

        public string InfoMessage { get; set; }

        public OperationStatus OperationStatus { get; set; }
    }
}
