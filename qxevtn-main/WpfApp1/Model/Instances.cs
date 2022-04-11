using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Instances
    {
        private static user2Entities _Db = null;
        public static user2Entities db
        {
            get
            {
                if (_Db == null)
                    _Db = new user2Entities();
                return _Db;
            }
        }
    }
}
