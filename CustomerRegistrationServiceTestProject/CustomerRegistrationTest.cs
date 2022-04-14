using Xunit;
using UserRegistrationService.Controllers;
using UserRegistrationService.Model;
using UserRegistrationService.Repository;
using Moq;
using UserRegistrationService.Repository.Interfaces;
using System;

namespace CustomerRegistrationServiceTestProject
{
    public class CustomerRegistrationTest
    {
        public Mock<ICustomerContract> mock = new Mock<ICustomerContract>();
        public CustomerRegistrationTest()
        {

           
        }

        [Fact]
        public async void GetCustomerData()
        {

            var customerDTO = new Customer()
            {
                Customerid = 1,
                FullName = "shirsendu nandi",
                DOB = Convert.ToDateTime("1985-07-06"),
                RGNumber = "s009",
                Adress = "bangalore",
                DateOfregistration = System.DateTime.Now.Date,
                ActiveCustomer=true

            };

            mock.Setup(p => p.GetCustomerData(1)).Returns(customerDTO);
            CustomerController cus = new CustomerController(mock.Object);
            var result = cus.GetCustomerData(1);
            Assert.Equal("shirsendu nandi", result.ToString());
        }
        [Fact]
        public async void GetCustomerDetails()
        {

            var customerDTO = new Customer()
            {
                Customerid = 1,
                FullName = "shirsendu nandi",
                DOB = Convert.ToDateTime("1985-07-06"),
                RGNumber = "s009",
                Adress = "bangalore",
                DateOfregistration = System.DateTime.Now.Date,
                ActiveCustomer = true

            };

            mock.Setup(p => p.GetCustomerDetails());
            CustomerController cus = new CustomerController(mock.Object);
            var result = cus.GetCustomerDetails();
            Assert.True(customerDTO.Equals(result));
        }

        [Fact]
        public async void PostCustomerDetails()
        {

            var customerDTO = new Customer()
            {
               
                FullName = "shirsendu nandi new test data",
                DOB = Convert.ToDateTime("1985-07-06"),
                RGNumber = "s003",
                Adress = "Chennai",
                DateOfregistration = System.DateTime.Now.Date,
                ActiveCustomer = true

            };

            mock.Setup(p => p.AddCustomer(customerDTO));
            CustomerController cus = new CustomerController(mock.Object);
            cus.Post(customerDTO);
            
        }
        [Fact]
        public async void UpdateCustomerDetails()
        {

            var customerDTO = new Customer()
            {
                Customerid=3,
                FullName = "Update customer name",
                DOB = Convert.ToDateTime("1985-07-06"),
                RGNumber = "s003",
                Adress = "Mumbai",
                DateOfregistration = System.DateTime.Now.Date,
                ActiveCustomer = true

            };

            mock.Setup(p => p.AddCustomer(customerDTO));
            CustomerController cus = new CustomerController(mock.Object);
            cus.Put(customerDTO);

        }

        [Fact]
        public void DeleteCustomerData()
        {
            var customerDTO = new Customer()
            {
                Customerid = 1,
                FullName = "shirsendu nandi",
                DOB = Convert.ToDateTime("1985-07-06"),
                RGNumber = "s009",
                Adress = "bangalore",
                DateOfregistration = System.DateTime.Now.Date,
                ActiveCustomer = true

            };

            mock.Setup(p => p.DeleteCustomerDetails(1));
            CustomerController cus = new CustomerController(mock.Object);
            var result = cus.Delete(3);
           
        }
    }
}