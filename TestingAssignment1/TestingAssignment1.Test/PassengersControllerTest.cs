using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAssignment1.Controllers;
using TestingAssignment1.DAL.Interface;
using TestingAssignment1.Models;
using Xunit;
using System.Web.Http;

namespace TestingAssignment1.Test
{
    
    public class PassengersControllerTest
    {
        private readonly Mock<IPassengersRepository> mockRepository = new Mock<IPassengersRepository>();
        private readonly PassengersController _controller;

        public PassengersControllerTest()
        {
            _controller = new PassengersController(mockRepository.Object);
        }


        /*
            This method tests the GetPassengers method if all the inputs are entered correctly.
             */
        [Fact]
        public void Test_GetPassengers()
        {
            List<Passengers> passengers = new List<Passengers>()
            {
                new Passengers(){Id=1,FirstName="ABC",LastName="XYZ",PhoneNumber="15541654"},
                new Passengers(){Id=2,FirstName="PQR",LastName="XYZ",PhoneNumber="543535434"}
            };
            var resultObj = mockRepository.Setup(x => x.GetPassengers()).Returns(passengers);

            List<Passengers> response = _controller.GetPassengers().ToList();

            Assert.Equal(2, response.Count);
        }


        /*
            This method tests the GetPassengers method if all the inputs are not entered correctly.
             */
        [Fact]
        public void Test_GetPassengersFail()
        {
            List<Passengers> passengers = new List<Passengers>()
            {
                new Passengers(){Id=1,FirstName="ABC",LastName="XYZ",PhoneNumber="15541654"},
                new Passengers(){Id=2,FirstName="PQR",LastName="XYZ",PhoneNumber="543535434"}
            };
            var resultObj = mockRepository.Setup(x => x.GetPassengers()).Returns(passengers);

            List<Passengers> response = _controller.GetPassengers().ToList();

            Assert.NotEqual(3, response.Count);
        }


        /*
            This method tests the DeletePassenger method if all the inputs are entered correctly.
             */
        [Fact]
        public void Test_DeletePassenger()
        {
            int id = 1;
            var resultObj = mockRepository.Setup(x => x.DeletePassenger(id)).Returns("Passenger Deleted");

            var response = _controller.DeletePassenger(1);

            Assert.Equal("Passenger Deleted", response);
        }


        /*
            This method tests the DeletePassenger method if all the inputs are not entered correctly.
             */
        [Fact]
        public void Test_DeletePassengerFail()
        {
            int id = 1;
            var resultObj = mockRepository.Setup(x => x.DeletePassenger(id)).Returns("Passenger Deleted");

            var response = _controller.DeletePassenger(2);

            Assert.NotEqual("Passenger Deleted", response);
        }


        /*
            This method tests the AddPassenger method if all the inputs are entered correctly.
             */
        [Fact]
        public void Test_AddPassenger()
        {
            var data = new Passengers() { Id = 1, FirstName = "ABC", LastName = "XYZ", PhoneNumber = "15541654" };
            var resultObj = mockRepository.Setup(x => x.AddPassenger(data)).Returns("Passenger Added");

            var response = _controller.AddPassenger(data);

            Assert.Equal("Passenger Added", response);
        }

        /*
            This method tests the AddPassenger method if all the inputs are not entered correctly.
             */
        [Fact]
        public void Test_AddPassengerFail()
        {
            var data = new Passengers() { Id = 1, FirstName = "ABC", LastName = "XYZ", PhoneNumber = "15541654" };
            var Newdata = new Passengers() { Id = 2, FirstName = "ABC", LastName = "XYZ", PhoneNumber = "15541654" };
            var resultObj = mockRepository.Setup(x => x.AddPassenger(data)).Returns("Passenger Added");

            var response = _controller.AddPassenger(Newdata);

            Assert.NotEqual("Passenger Added", response);
        }


        /*
            This method tests the EditPassenger method if all the inputs are entered correctly.
             */
        [Fact]
        public void Test_EditPassenger()
        {
            int id = 1;
            var data = new Passengers() { Id = 1, FirstName = "ABC", LastName = "XYZ", PhoneNumber = "15541654" };
            var resultObj = mockRepository.Setup(x => x.EditPassenger(id,data)).Returns("Passenger Edited");

            var response = _controller.EditPassenger(id,data);

            Assert.Equal("Passenger Edited", response);
        }


        /*
            This method tests the EditPassenger method if all the inputs are not entered correctly.
             */
        [Fact]
        public void Test_EditPassengerFail()
        {
            int id = 1;
            var data = new Passengers() { Id = 1, FirstName = "ABC", LastName = "XYZ", PhoneNumber = "15541654" };
            var resultObj = mockRepository.Setup(x => x.EditPassenger(id, data)).Returns("Passenger Edited");

            var response = _controller.EditPassenger(2, data);

            Assert.NotEqual("Passenger Edited", response);
        }

        /*
            This method tests the GetPassenger method if all the inputs are entered correctly.
             */
        [Fact]
        public void Test_GetPassenger()
        {
            int id = 1;
            var data = new Passengers() { Id = 1, FirstName = "ABC", LastName = "XYZ", PhoneNumber = "15541654" };
            var resultObj = mockRepository.Setup(x => x.GetPassenger(id)).Returns(data);

            Passengers response = _controller.GetPassenger(id);

            Assert.Equal(data, response);
        }


        /*
            This method tests the GetPassenger method if all the inputs are not entered correctly.
             */
        [Fact]
        public void Test_GetPassengerFail()
        {
            int id = 1;
            var data = new Passengers() { Id = 1, FirstName = "ABC", LastName = "XYZ", PhoneNumber = "15541654" };
            var resultObj = mockRepository.Setup(x => x.GetPassenger(id)).Returns(data);

            Passengers response = _controller.GetPassenger(2);

            Assert.NotEqual(data, response);
        }
    }
}
