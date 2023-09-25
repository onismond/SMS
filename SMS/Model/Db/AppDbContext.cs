using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ModernDesign.Data.Db;
using SMS.Model.Db.Entities;

namespace SMS.Model.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        public StudentDao GetStudentDao() => new StudentDao(this);
    }
}
