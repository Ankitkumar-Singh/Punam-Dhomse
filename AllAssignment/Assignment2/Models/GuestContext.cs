using System.Data.Entity;

namespace Assignment2.Models
{
    #region "DbContext"
    /// <summary>
    /// Conntection context with mode
    /// </summary>
    public class GuestContext : DbContext
    {
        public DbSet<Guest> Guest { get; set; }
        public DbSet<Invitation> invitation { get; set; }
    }
    #endregion
}