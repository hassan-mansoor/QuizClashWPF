using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Clash.GamePlay
{
     class Users
    {
        DBLib lib = new DBLib();
        string flag=string.Empty;
        #region Feild
        public string CurPlayer { get;  set; }
        public int PlayerScore { get; set; }
        #endregion

        public int Players(List<string> Players)
        {
            int Flag,Status=0;
            foreach (var player in Players)
            {
                Flag = lib.InsertQuery("update Tbl_Users set IsPlaying='active',RoundNo='1' where UserName='"+player.ToString()+"'");
                
                if (Flag == 1)
                {
                    
                   
                    Status = 0;
                }
                else
                {
                    Status = 1;
                }
            }

            return Status;
        }

        public string UserStaus()
        {
            DataTable dt = new DataTable();
            dt = lib.SelectQuery("select * from Tbl_Users where status='1' and IsPlaying='active'");
            if (dt.Rows.Count > 0)
            {
                flag += dt.Rows[0]["UserName"].ToString();   
            }
            else
            {
                //check deactivared users  
                dt = lib.SelectQuery("select * from Tbl_Users where status='1' and IsPlaying='deactive'");
               
                if (dt.Rows.Count==2)
                {
                    flag = "Finish";
                  
                }
                else
                {
                    flag = string.Empty;
                }
            }
            return flag;
        }


        public int DeactivePlayer()
        {
            int Flag, Status = 0;
           
                Flag = lib.InsertQuery("update Tbl_Users set IsPlaying='deactive' where UserName='" + CurPlayer + "'");
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

        public bool AddScores()
        {
            bool status;
            int old_score = calculate_scores(CurPlayer);
            int finalscore = old_score + PlayerScore;
            int Flag = lib.InsertQuery("update Tbl_Users set Scores='"+finalscore.ToString()+"' where UserName='" + CurPlayer + "'");
            if (Flag == 1)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            return status;
        }

        private int calculate_scores(string player)
        {
            int score = 0;
            DataTable dt = new DataTable();
            dt = lib.SelectQuery("select * from Tbl_Users where UserName='" + player + "'");
            if (dt.Rows.Count > 0 && dt.Rows[0]["Scores"].ToString() != string.Empty)
            {
                score = Convert.ToInt32(dt.Rows[0]["Scores"].ToString());
                return score;
            }
            else
            {
                return score;
            }
        }


        public string displayScores()
        {
            string DsplyScores = string.Empty;
            DataTable dt = new DataTable();
            dt = lib.SelectQuery("select * from Tbl_Users where status='1'");
            
            if (dt.Rows.Count==2)
            {
               
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   DsplyScores+= dt.Rows[i]["UserName"].ToString() + ":" + dt.Rows[i]["Scores"].ToString()+",";
               }

               return DsplyScores;
            }

            else
            {
                return string.Empty;
            } 
        }





    }
}
