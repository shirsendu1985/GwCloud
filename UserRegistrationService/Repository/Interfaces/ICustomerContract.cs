using UserRegistrationService.Model;

namespace UserRegistrationService.Repository.Interfaces
{
    public interface ICustomerContract
    {
        public  List<Customer> GetCustomerDetails();
        public void AddCustomer(Customer user);
        public void UpdateCustomerDetails(Customer user);
        public Customer GetCustomerData(int id);
        public void DeleteCustomerDetails(int id);
        public bool ValidateExistingCustomer(string rgNo);
    }
}
