using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyon
{
    public class Database
    {
        HotelDbEntities _conn;
        public Database(HotelDbEntities conn) { 
           _conn = conn;
        }   
        public void Add(string tablo)
        {
            
        }
    }
}
