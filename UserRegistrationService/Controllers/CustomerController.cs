using Microsoft.AspNetCore.Mvc;
using UserRegistrationService.Model;
using UserRegistrationService.Repository.Interfaces;

namespace UserRegistrationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerContract _ICustomer;
        public CustomerController(ICustomerContract iCustomer)
        {
            _ICustomer = iCustomer;
        }

        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
           
            if (_ICustomer.ValidateExistingCustomer(customer.RGNumber))
            {

                 StatusCode(404, "Existing Customer '"+ customer.FullName+"' Find for the RG Number '"+customer.RGNumber+"'");

                 BadRequest("Existing Customer '" + customer.FullName + "' Find for the RG Number '" + customer.RGNumber + "'");
                throw new BadHttpRequestException("Existing Customer '" + customer.FullName + "' Find for the RG Number '" + customer.RGNumber + "'");
            }
            else
            _ICustomer.AddCustomer(customer);
        }

        [HttpPut]
        public void Put(Customer customer)
        {
            _ICustomer.UpdateCustomerDetails(customer);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ICustomer.DeleteCustomerDetails(id);
            return Ok();
        }

        [HttpGet]
        public async Task<List<Customer>> GetCustomerDetails()
        {
            return await Task.FromResult(_ICustomer.GetCustomerDetails());
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomerData(int id)
        {
            Customer customer = _ICustomer.GetCustomerData(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            return NotFound();
        }

    }
}
