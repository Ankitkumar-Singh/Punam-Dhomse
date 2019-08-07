
using System;
using System.ComponentModel.DataAnnotations;
namespace BusinessLayer
{
    public class Guest
    {
        #region "Guest class"
        public int Id { get; set; }
        [Required]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets ")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")] 
        public string Email { get; set; }
        [Required]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Age must be numeric")]
        public int Age { get; set; }
        [Required]
        public int InvitationId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}" ,ApplyFormatInEditMode=true )]
        public DateTime  DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        #endregion
    }
}
