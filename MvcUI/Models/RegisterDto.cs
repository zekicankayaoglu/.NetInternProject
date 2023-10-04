using System.ComponentModel.DataAnnotations;

namespace MvcUI.Models
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email{ get; set; }
        public string City { get; set; }
        public string Password { get; set; }
      
        
        

    }
}
