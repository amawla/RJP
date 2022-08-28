using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDatabaseInitializer
    {
        //Task SeedAsync();
    }
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDbContext _context;
        //private readonly IAccountManager _accountManager;
        //private readonly ILogger _logger;

        public DatabaseInitializer(ApplicationDbContext context/*, IAccountManager accountManager, ILogger<DatabaseInitializer> logger*/)
        {
            //_accountManager = accountManager;
            _context = context;
            //_logger = logger;
        }
    }
}
