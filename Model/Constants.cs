namespace Model
{
    public class Constants
    {

        public enum OperationStatus
        {
            /// <summary>
            /// When requested operation is not completed
            /// </summary>
            NotSuccessful = 0,

            /// <summary>
            /// Requested operation is Successfully completed
            /// </summary>
            Successful = 1,

            /// <summary>
            /// Pass with errors
            /// </summary>
            PassWithErrors = 2,

            /// <summary>
            ///  Validation Message
            /// </summary>
            ValidationMessage = 3
        }
    }
}
