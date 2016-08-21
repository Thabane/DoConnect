using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEdmx
{
    public class DoConnectContext : BaseContext<DoConnectContext>
    {
        public DbSet<DataEdmx.Doctors> AllDoctors { get; set; }

    }
}
