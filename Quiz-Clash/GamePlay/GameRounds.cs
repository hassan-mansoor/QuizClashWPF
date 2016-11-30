using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Clash.GamePlay
{
    class GameRounds
    {
        #region Fields
        public string CurPlayer { get;  set; }
        public int CurRound { get;  set; }
        int Flag, Status = 0;
        #endregion

        DBLib lib = new DBLib();


     public   GameRounds()
        {
            CurRound = 1;
        }
        public int NextRound(int roundNo,string playername)
        {
            DataTable dt = new DataTable();
            if (CurRound < 4)
            {

                Flag = lib.InsertQuery("update Tbl_Users set RoundNo='" + roundNo.ToString() + "' where UserName='"+playername+"'");
                if (Flag == 1)
                {
                    dt = lib.SelectQuery("select * from Tbl_Users where RoundNo='" + roundNo.ToString() + "'");
                    if (dt.Rows.Count == 2)
                    {
                        Status = 0;
                    }
                    else
                    {
                        Status = 1;
                    }
                   
                }
                else
                {
                    Status = 1;
                }
               


            }
            else if(CurRound==4)
            {
                CurRound = 4;
                Status = 1;
            }
              
            
            
            

            return Status;

        }


       


        public string check_login()
        {
            DataTable dt = new DataTable();
            dt = lib.SelectQuery("select * from Tbl_Users where status='1' and IsPlaying='active'");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["UserName"].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public int  RoundPlayed(int id)
        {
            int Flag, Status = 0;

            Flag = lib.InsertQuery("update Tbl_Rounds set RoundStatus='Played' where ID='" + id.ToString() + "'");
            if (Flag == 1)
            {
                Status = 0;
            }
            else
            {
                Status = 1;
            }


            return Status;

        }


       
       


       

    }
}
