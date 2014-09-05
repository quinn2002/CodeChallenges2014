using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCCodeChallenges.Models
{
    public class CodeChallengesDB : DbContext
    {
        public CodeChallengesDB()
            :base("name=DefaultConnection")
        {
        }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<ChallengeInput> ChallengeInputs { get; set; }
        public DbSet<InputLookupValue> InputLookupValues { get; set; }
        public DbSet<Validation> Validations { get; set; } // NOT currently used - validation is currently handled at the Challenge class level - here for future reference only
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}