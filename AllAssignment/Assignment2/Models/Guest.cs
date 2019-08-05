using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2.Models
{
    /// <summary>
    /// Mapping Database table with existing model
    /// </summary>
    [Table("GuestDetails")]

    #region "Guest Model"
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int InvitationId { get; set; }
    }
    #endregion
}