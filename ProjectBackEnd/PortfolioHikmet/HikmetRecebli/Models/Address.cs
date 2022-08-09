using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HikmetRecebli.Models
{
    public class Address
    {
        public int Id { get; set; }
        
        public string Location { get; set; }
        
        [StringLength(17)]
        [Phone]
        public string Number { get; set; }
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",ErrorMessage ="Email not valid")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public IList<OnlineAddress> OnlineAddresses { get; set; }
    }
}
