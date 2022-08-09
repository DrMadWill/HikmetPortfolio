using System.ComponentModel.DataAnnotations;

namespace HikmetRecebli.ViewModels
{
    public class ChangePasswordVM
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string OldPassword { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }

    }
}
