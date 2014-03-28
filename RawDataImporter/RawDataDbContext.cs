using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawDataImporter
{
    using System.Data.Entity;

    public class RawDataDbContext : DbContext
    {
        public RawDataDbContext()
            : base("DbConnectionString")
        {
                
        }
        public DbSet<ImportantMatchData> Matches { get; set; }
    }
}
