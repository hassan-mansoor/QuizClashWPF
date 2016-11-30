using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Clash.GamePlay
{
    class SetContents
    {
        public bool close()
        {
            DBLib lib = new DBLib();
            int flag = lib.InsertQuery("Truncate table Tbl_Users");
            if (flag == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
