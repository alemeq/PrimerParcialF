using System.Data.Entity;

namespace MVCparcial1F.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<MVCparcial1F.Models.AleMenachoFriend> AleMenachoFriends { get; set; }
    }
}