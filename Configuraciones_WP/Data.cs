using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Configuraciones_WP
{
    public class Data : DataContext
    {
        public Data(String connectionString)
            : base(connectionString)
        {

        }

        public Table<User> User
        {
            get
            {
                return this.GetTable<User>();
            }
        }
    }
}