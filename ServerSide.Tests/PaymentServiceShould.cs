using BLL.Interfaces;
using System;
using Xunit;
using Moq;
using Model;
using POCWebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Core.Interface;

namespace ServerSide.Tests
{
    public class PaymentServiceShould
    {
        [Fact]
              
        public async void AcceptPaymentDetails()
        {
            Mock<IPaymentService> mockPaymentService = new Mock<IPaymentService>();
            

            var payment = new Payment() {

                BsbNumber = "123456456666",
                AccountNumber="123456789",
                AccountName="Daman"
            };
            var operationStatus = new Operation();
            mockPaymentService.Setup(x => x.AddPayment(payment)).Returns(new Operation()
            { EntityId=0, ErrorMessage="", InfoMessage="success", OperationStatus=Constants.OperationStatus.Successful });

            var controller = new PaymentController(mockPaymentService.Object);

            var result = await controller.Post(payment)  ;
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public async void AcceptPaymentDetails_WithError()
        {
            Mock<IPaymentService> mockPaymentService = new Mock<IPaymentService>();


            var payment = new Payment()
            {

                BsbNumber = "123456456666",
                AccountNumber = "123456789",
                AccountName = "Daman"
            };
            var operationStatus = new Operation();
          //  mockPaymentService.Setup(x => x.AddPayment(payment)).Returns(new Operation()
            //{ EntityId = 0, ErrorMessage = "", InfoMessage = "success", OperationStatus = Constants.OperationStatus.Successful });

            var controller = new PaymentController(mockPaymentService.Object);
            controller.ModelState.AddModelError("Amount", "Zero");
            var result = await controller.Post(payment);
            var notFound = result as NotFoundObjectResult;
            Assert.NotNull(notFound);
            Assert.Equal(404, notFound.StatusCode);

        }

        [Fact]

        public async void AcceptPaymentDetails_WithoutMock()
        {
            Mock<IPaymentService> mockPaymentService = new Mock<IPaymentService>();
            Mock<IDataOperation> mockDataService = new Mock<IDataOperation>();
           

            var payment = new Payment()
            {

                BsbNumber = "123456456666",
                AccountNumber = "123456789",
                AccountName = "Daman"
            };
            var operationStatus = new Operation()
            { EntityId = 0, ErrorMessage = "", InfoMessage = "success", OperationStatus = Constants.OperationStatus.Successful };
            mockDataService.Setup(s => s.SavePaymentData(payment, out operationStatus)).Returns(true);
            mockPaymentService.Setup(x => x.AddPayment(payment)).Returns(operationStatus);

            var controller = new PaymentController(mockPaymentService.Object);

            var result = await controller.Post(payment);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal("Successful", operationStatus.OperationStatus.ToString());

        }
    }
}
