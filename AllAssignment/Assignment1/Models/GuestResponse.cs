using System.ComponentModel.DataAnnotations;

namespace AllAssignment.Models
{
    public class GuestResponse
    {
        #region "Guest Model"
        /// <summary>
        /// Validation and model parameters
        /// </summary>
        [Required(ErrorMessage = "Please enter your name")]
        [RegularExpression("^([a-zA-z]{4,32})$", ErrorMessage = "Please enter a valid name")] 
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please specify whether you'll attend")]
        public bool? WillAttend { get; set; }
    }
        #endregion
}