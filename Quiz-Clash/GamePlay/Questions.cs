using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Clash.GamePlay
{
  public  class Questions
    {
        DataTable dt = new DataTable();
        DBLib lib = new DBLib();
        #region Fields
        public string Question { get;  set; }
       public string ChoiceA { get;  set; }
       public string ChoiceB { get;  set; }
       public string ChoiceC { get;  set; }
       public string ChoiceD { get;  set; }
       public string Category { get;  set; }
       public string CorrectAnswer { get;  set; }

        #endregion

       public int final;
       int score = 0;

      public Questions()
       {

       }

       #region Generate Questions
       public bool Generate_Qestion(int row)
        {

            if (row >= 4)
            {
                return false;
            }
            else
            {
                dt = lib.SelectQuery("SELECT  TOP 4  * FROM [question-answer]ORDER BY CHECKSUM(NEWID())");

                Question = dt.Rows[row]["question"].ToString();
                ChoiceA = dt.Rows[row]["A"].ToString();
                ChoiceB = dt.Rows[row]["B"].ToString();
                ChoiceC = dt.Rows[row]["C"].ToString();
                ChoiceD = dt.Rows[row]["D"].ToString();
                Category = dt.Rows[row]["cat_id"].ToString();
                CorrectAnswer = dt.Rows[row]["answer"].ToString();
                return true;
            }

        }
      
       #endregion

       
        #region calculate Scores
        public void Match_Answer(string cor_ans)
    {
       
        if (cor_ans == CorrectAnswer)
        {
            score = score + 1;
        }

        final = score;
    }




        #endregion



        #region Add Question

        public string InsertQuestion()
        {
            string Status = string.Empty;
            Status = Validaiton();
            if (Status == string.Empty)
            {
                int flag = lib.InsertQuery("insert into [question-answer] values ('" + Question + "','" + ChoiceA + "','" + ChoiceB + "','" + ChoiceC + "','" + ChoiceD + "','" + Category + "','" + CorrectAnswer + "')");
                if (flag == 1)
                {
                    Status= "success";
                }
                else
                {
                    Status="Failure";
                }

                return Status;
            }
            else
            {
               return Status;
            }

        }

        #endregion


        #region Validation

        public string Validaiton()
        {
            if (Question.Trim() == string.Empty)
            {
                return "Please Insert Question, Cannot be Empty";
            }
            if (ChoiceA.Trim() == string.Empty)
            {
                return "Please Insert Choice A, Cannot be Empty";
            }
            if (ChoiceB.Trim() == string.Empty)
            {
                return "Please Insert Choice A, Cannot be Empty";
            }
            if (ChoiceC.Trim() == string.Empty)
            {
                return "Please Insert Choice A, Cannot be Empty";
            }
            if (ChoiceD.Trim() == string.Empty)
            {
                return "Please Insert Choice A, Cannot be Empty";
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion


       

    }
}
