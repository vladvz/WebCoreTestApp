using System.ComponentModel.DataAnnotations;

namespace WebCoreTestApp.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Too long message")]
        public string Message { get; set; }
    }
}
