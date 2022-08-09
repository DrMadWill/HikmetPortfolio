using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HikmetRecebli.Models
{
    public class OnlineAddress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Link { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        public string Icon { get; set; }
        
        public Address Address { get; set; }
        public int AddressId { get; set; }
    }
}
