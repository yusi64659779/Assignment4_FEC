using Federal_Election.Models;
using Microsoft.EntityFrameworkCore;

namespace Federal_Election.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Candidates> Candidates { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Committees> Committees { get; set; }
        public DbSet<Committee> Committee { get; set; }
        public DbSet<Filings> Filings { get; set; }
        public DbSet<Filing> Filing { get; set; }
    }
}
