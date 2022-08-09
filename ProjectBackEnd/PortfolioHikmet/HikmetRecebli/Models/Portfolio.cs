using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HikmetRecebli.Models
{
    public class Portfolio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [Url]
        public string Link { get; set; }
        [Required]
        [Url]
        public string Image { get; set; }
    }
}
