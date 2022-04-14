using Microsoft.EntityFrameworkCore;
using UserRegistrationService.Data;
using UserRegistrationService.Model;
using UserRegistrationService.Repository.Interfaces;

namespace UserRegistrationService.Repository.DataProvider
{
    public class CustomerDataprovider : ICustomerContract
    {

        readonly CustomerDataContext _dbContext = new CustomerDataContext();
        public CustomerDataprovider(CustomerDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        void ICustomerContract.AddCustomer(Customer customer)
        {
            try
            {
                _dbContext.Customer.Add(customer);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }


        bool ICustomerContract.ValidateExistingCustomer(string rgNo)
        {
            try
            {
                //Customer? customer = _dbContext.Customer.Find(rgNo);

               
                 return  _dbContext.Customer.ToList().Where(y => y.RGNumber == rgNo).Any();
                
            }
            catch
            {
                throw;
            }
        }

        void ICustomerContract.DeleteCustomerDetails(int id)
        {
             try
            {
                var customerData = _dbContext.Customer?.Find(id);
                if (customerData != null)
                {
                    _dbContext.Customer.Remove(customerData);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        Customer ICustomerContract.GetCustomerData(int id)
        {
            try
            {
                Customer? customer = _dbContext.Customer?.Find(id);
                if (customer != null)
                {
                    return customer;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        List<Customer> ICustomerContract.GetCustomerDetails()
        {
            try
            {
                return _dbContext.Customer?.ToList();
            }
            catch
            {
                throw;
            }
            throw new NotImplementedException();
        }

        void ICustomerContract.UpdateCustomerDetails(Customer customer)
        {
            try
            {
                _dbContext.Entry(customer).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
