using System.Data.Entity;
using Interns.Core.Data;

namespace Interns.DataAccessLayer.Context
{
    public class AppContext : DbContext
    {
        public AppContext() : base("AppContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<SubDomain> SubDomains { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Advertise> Advertisments { get; set; }
        public DbSet<Qa> QAs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
