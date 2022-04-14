using System.ComponentModel.DataAnnotations;

namespace UserRegistrationService.Model
{
    public class Customer
    {
        [Key]
        public int Customerid { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime DOB { get; set; } 
        public string RGNumber { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public DateTime DateOfregistration { get; set; } 
        public bool ActiveCustomer { get; set; }
    }
}
