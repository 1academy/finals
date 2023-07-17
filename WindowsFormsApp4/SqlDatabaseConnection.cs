using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class SqlDatabaseConnection
    {
        public string ConnectionString() 
        {
            return "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Business; Integrated Security = True";
        }
    }
}
