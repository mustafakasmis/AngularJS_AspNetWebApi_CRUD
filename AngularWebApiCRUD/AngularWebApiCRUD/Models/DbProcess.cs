using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularWebApiCrudOperations.Models
{
    public class DbProcess:DbContext
    {
        public DbSet<User> users { get; set; }

        public DbProcess()
        {
            Database.SetInitializer<DbProcess>(new DbIfNotExists());
        }

    }

    public class DbIfNotExists : CreateDatabaseIfNotExists<DbProcess>
    {

    }


}