
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assignment2.Models
{
    [Table("Invitation")]
    public class Invitation
    {
        public int InvitationId { get; set; }
        public string Invited { get; set; }
        public List<Guest> guest { get; set; }
    }
}