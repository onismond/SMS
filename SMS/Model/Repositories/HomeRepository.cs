using SMS.Model.Db.Entities;
using SMS.Model.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Model.Responses;
using SMS.Util.Network;

namespace SMS.Model.Repositories
{
    public class HomeRepository
    {
        private readonly AppDbContext db;

        private readonly MyApi api;
        public HomeRepository(AppDbContext appDbContext, MyApi myApi)
        {
            db = appDbContext;
            api = myApi;
        }

        public async Task AddStudent(Student student) => await db.GetStudentDao().AddStudent(student);

        public async Task<IEnumerable<Student>> GetAllStudents() => await db.GetStudentDao().GetAllStudents();

        public async Task<IndexResponse> GetUser() => await api.Get<IndexResponse>("index");

        public async Task<IndexResponse> PostUser(Dictionary<string, string> values) => await api.Post<IndexResponse>("product/detail", values);

    }
}
