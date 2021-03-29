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
            <summary>
                This method tests the GetPassengers method if all the inputs are entered correctly.
            </summary>
             */
        [Fact]
        public void Test_GetPassengers()
        {
            //Arrange
            List<Passengers> passengers = Passengers();
            var resultObj = mockRepository.Setup(x => x.GetPassengers()).Returns(passengers);

            //Act
            List<Passengers> response = _controller.GetPassengers().ToList();

            //Assert
            Assert.Equal(2, response.Count);
        }


        /*
            <summary>
                This method tests the GetPassengers method if all the inputs are not entered correctly.
            </summary>
             */
        [Fact]
        public void Test_GetPassengersFail()
        {
            //Arrange
            List<Passengers> passengers = Passengers();
            var resultObj = mockRepository.Setup(x => x.GetPassengers()).Returns(passengers);

            //Act
            List<Passengers> response = _controller.GetPassengers().ToList();

            //Assert
            Assert.NotEqual(3, response.Count);
        }


        /*
            <summary>
                This method tests the DeletePassenger method if all the inputs are entered correctly.
            </summary>
             */
        [Fact]
        public void Test_DeletePassenger()
        {
            //Arramge
            int id = 1;
            var resultObj = mockRepository.Setup(x => x.DeletePassenger(id)).Returns("Passenger Deleted");

            //Act
            var response = _controller.DeletePassenger(1);


            //Assert
            Assert.Equal("Passenger Deleted", response);
        }


        /*
            <summary>
                This method tests the DeletePassenger method if all the inputs are not entered correctly.
            </summary>
             */
        [Fact]
        public void Test_DeletePassengerFail()
        {
            //Arrange
            int id = 1;
            var resultObj = mockRepository.Setup(x => x.DeletePassenger(id)).Returns("Passenger Deleted");

            //Act
            var response = _controller.DeletePassenger(2);
            
            //Assert
            Assert.NotEqual("Passenger Deleted", response);
        }


        /*
            <summary>
                This method tests the AddPassenger method if all the inputs are entered correctly.
            </summary>
             */
        [Fact]
        public void Test_AddPassenger()
        {
            //Arrange
            var data = new Passengers() { Id = 1, FirstName = "ABC", LastName = "XYZ", PhoneNumber = "15541654" };
            var resultObj = mockRepository.Setup(x => x.AddPassenger(data)).Returns("Passenger Added");

            //Act
            var response = _controller.AddPassenger(data);

            //Assert
            Assert.Equal("Passenger Added", response);
        }

        /*
            <summary>
                This method tests the AddPassenger method if all the inputs are not entered correctly.
            </summary>
             */
        [Fact]
        public void Test_AddPassengerFail()
        {
            //Arrange
            var data = new Passengers() { Id = 1, FirstName = "ABC", LastName = "XYZ", PhoneNumber = "15541654" };
            var Newdata = new Passengers() { Id = 2, FirstName = "ABC", LastName = "XYZ", PhoneNumber = "15541654" };
            var resultObj = mockRepository.Setup(x => x.AddPassenger(data)).Returns("Passenger Added");

            //Act
            var response = _controller.AddPassenger(Newdata);

            //Assert
            Assert.NotEqual("Passenger Added", response);
        }


        /*
            <summary>
                This method tests the EditPassenger method if all the inputs are entered correctly.
            </summary>
             */
        [Fact]
        public void Test_EditPassenger()
        {
            //Arrange
            int id = 1;
            var data = new Passengers() { Id = 1, FirstName = "ABC", LastName = "XYZ", PhoneNumber = "15541654" };
            var resultObj = mockRepository.Setup(x => x.EditPassenger(id,data)).Returns("Passenger Edited");

            //Act
            var response = _controller.EditPassenger(id,data);

            //Assert
            Assert.Equal("Passenger Edited", response);
        }


        /*
            <summary>
                This method tests the EditPassenger method if all the inputs are not entered correctly.
            </summary>
             */
        [Fact]
        public void Test_EditPassengerFail()
        {
            //Arrange
            int id = 1;
            var data = new Passengers() { Id = 1, FirstName = "ABC", LastName = "XYZ", PhoneNumber = "15541654" };
            var resultObj = mockRepository.Setup(x => x.EditPassenger(id, data)).Returns("Passenger Edited");

            //Act
            var response = _controller.EditPassenger(2, data);

            //Assert
            Assert.NotEqual("Passenger Edited", response);
        }

        /*
            <summary>
                This method tests the GetPassenger method if all the inputs are entered correctly.
            </summary>
             */
        [Fact]
        public void Test_GetPassenger()
        {
            //Arrange
            int id = 1;
            var data = new Passengers() { Id = 1, FirstName = "ABC", LastName = "XYZ", PhoneNumber = "15541654" };
            var resultObj = mockRepository.Setup(x => x.GetPassenger(id)).Returns(data);

            //Act
            Passengers response = _controller.GetPassenger(id);

            //Assert
            Assert.Equal(data, response);
        }


        /*
            <summary>
                This method tests the GetPassenger method if all the inputs are not entered correctly.
            </summary>
             */
        [Fact]
        public void Test_GetPassengerFail()
        {
            //Arrange
            int id = 1;
            var data = new Passengers() { Id = 1, FirstName = "ABC", LastName = "XYZ", PhoneNumber = "15541654" };
            var resultObj = mockRepository.Setup(x => x.GetPassenger(id)).Returns(data);

            //Act
            Passengers response = _controller.GetPassenger(2);

            //Assert
            Assert.NotEqual(data, response);
        }


        private List<Passengers> Passengers()
        {
            return new List<Passengers>()
            {
                new Passengers(){Id=1,FirstName="ABC",LastName="XYZ",PhoneNumber="15541654"},
                new Passengers(){Id=2,FirstName="PQR",LastName="XYZ",PhoneNumber="543535434"}
            };
        }

    }
}
