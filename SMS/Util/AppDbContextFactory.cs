using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SMS.Model.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Util
{
    public class AppDbContextFactory
    {
        private readonly string _connectionString;

        public AppDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public AppDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new AppDbContext(options);
        }
    }
}
