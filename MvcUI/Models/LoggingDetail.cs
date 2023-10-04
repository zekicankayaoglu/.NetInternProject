using System.ComponentModel.DataAnnotations;

namespace MvcUI.Models
{
    public class LoggingDetail
    {
        
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

        

    }
}
