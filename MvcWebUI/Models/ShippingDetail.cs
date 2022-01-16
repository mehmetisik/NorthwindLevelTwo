using System.ComponentModel.DataAnnotations;

namespace MvcWebUI.Models
{
    public class ShippingDetail
    {
        //[Required(ErrorMessage ="İsim Gerekli")]
        public string FirstName { get; set; }
        
        //[Required]
        public string LastName { get; set; }

        //[Required]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[Required]
        public string City { get; set; }

        //[Required]
        //[MinLength(10)]
        public string Adress { get; set; }

        //[Required]
        //[Range(15,65)]
        public int Age { get; set; }
    }
}
