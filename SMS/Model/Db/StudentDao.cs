using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SMS.Model.Db;
using SMS.Model.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDesign.Data.Db
{
    public class StudentDao
    {
        private readonly AppDbContext db;
        public StudentDao(AppDbContext appDbContext)
        {
            db = appDbContext;
        }

        public async Task AddStudent(Student student)
        {
            db.Students.Add(student);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudents() => await db.Students.ToListAsync();

    }
}
