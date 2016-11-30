using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Quiz_Clash.Authentication
{
 public   class Authentication
    {
        DBLib lib = new DBLib();
        public Authentication()
        {

        }


        #region Fields _fname, _lname, _email, _password, _username,_emailExt,error_flag,NewPassword
        string _fname, _lname, _email,_emailExt, _password, _username,_newpassword;
       public string error_flag =string.Empty;
        public string FName
        {
            get
            {
                return this._fname;
            }
            set
            {
                this._fname = value;
            }
        }

        public string LName
        {
            get
            {
                return this._lname;
            }
            set
            {
                this._lname = value;
            }
        }
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }

        public string NewPassword
        {
            get
            {
                return this._newpassword;
            }
            set
            {
                this._newpassword = value;
            }
        }


        public string UserName
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }

        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
            }
        }

        public string Email_Ext
        {
            get
            {
                return this._emailExt;
            }
            set
            {
                this._emailExt = value;
            }
        }
#endregion


        #region Registration validation


        public string  validation()
        {

            if (check_len() ==string.Empty)
            {
                error_flag =string.Empty;
            }
           
            if (validate_specialchar() ==string.Empty)
            {
                error_flag =string.Empty;
               
            }

            return error_flag;
         

        }




        public string check_len()
        {
           
            if (_fname.Trim().Length == 0)
            {
                error_flag +="1:First name cannot be empty.\n";
            }
            if (_username.Trim().Length == 0)
            {
                error_flag += "2:Username cannot be empty.\n";
            }
            if (_email.Trim().Length == 0)
            {
                error_flag += "3:Email cannot be empty.\n";
            }
            if (_password.Trim().Length == 0)
            {
                error_flag += "4:Password cannot be empty.\n";
            }

            if (_fname.Trim().Length <3)
            {
                error_flag += "5:First name should be atleast 3 charaters.\n";
            }
            if (_username.Trim().Length< 3)
            {
                error_flag += "6:Username should be atleast 3 charaters.\n";
            }
            if (_email.Trim().Length<3)
            {
                error_flag += "7:Email should be atleast 3 charaters.\n";
            }
            if (_password.Trim().Length <7)
            {
                error_flag += "8:Password should be atleast 7 charaters.\n";
            }

            return error_flag;
        }

        public string validate_specialchar()
        {
    
            Match match_name = Regex.Match(_fname+_lname, "[^a-z0-9]",RegexOptions.IgnoreCase);
             
            if (match_name.Success)
            {
                if (Regex.Match(_fname + _lname, @"\d+").Success)
                {
                    error_flag += "9:Name should  not contain special characters or empty space.\n";
                }
              

            }
           
            Match match_email = Regex.Match(_email, "[^a-z0-9]",RegexOptions.IgnoreCase);

            if (match_email.Success)
            {
                
                if (Regex.Match(_email, @"\d+").Success || Regex.Match(_email, "[._]").Success)
                {
                    error_flag += string.Empty;
                }
                
                else {
                    error_flag += "10:Email should not contain special characters or empty space.\n"; 
                }              
          
            }

            Match match_user = Regex.Match(_username, "[^a-z0-9]", RegexOptions.IgnoreCase);
            if (match_user.Success)
            {
                if (Regex.Match(_username, @"\d+").Success == true)
                {
                    error_flag += string.Empty;
                }
                else
                {

                    error_flag += "11:Username should not contain special characters or empty space.\n";
                }
            }

           
            return error_flag;

        }





        #endregion


        #region Sumbit registeration

        public string Sumbit()
        {

            int Flag;

          
            string FullName = _fname + " " + _lname;
            string EmailAddress = _email + _emailExt;
            if (validation() == string.Empty)
            {


                Flag = lib.InsertQuery("insert into Tbl_Users (FullName,UserName,Email,Password) values ('" + FullName + "','" + _username + "','" + EmailAddress + "','" + _password + "') ");

                if (Flag == 1)
                {
                    return error_flag;
                }


                else
                {
                    return error_flag;
                       
                }
            }

            else
            {
                return error_flag ;
            }
        }

#endregion

        #region validate Login

        public string validate_login()
        {
            int flag;
            DataTable dt = new DataTable();
          
            dt = lib.SelectQuery("select * from Tbl_Users where UserName='"+_username+"' and Password='"+_password+"'");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["status"].ToString() == "0" || dt.Rows[0]["status"].ToString() == string.Empty)
                {

                    flag = lib.InsertQuery("update Tbl_Users set status=1 where UserName='" + dt.Rows[0]["UserName"] + "'");
                    if (flag == 1)
                    {
                        error_flag = string.Empty;
                    }
                    else
                    {
                        error_flag += "Some problem in database";
                    }
                }
                else
                {
                    error_flag += "12:User already loged in.\n";
                }
            }
            else
            {
                error_flag += "13:No user exist.\n";
            }
            
            return error_flag;
        }

        #endregion


        #region ChangePassword
        public string ChangePassword()
        {
            int flag;
            DataTable dt = new DataTable();

            dt = lib.SelectQuery("select * from Tbl_Users where UserName='" + _username + "' and Password='" + _password + "'");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["status"].ToString() == "1")
                {

                    flag = lib.InsertQuery("update Tbl_Users set Password='"+_newpassword+"' where UserName='" + dt.Rows[0]["UserName"] + "'");
                    if (flag == 1)
                    {
                        error_flag = "Password Updated successfully";
                    }
                    else
                    {
                        error_flag += "Some problem in database";
                    }
                }
                else
                {
                    error_flag += "Invalid User.\n";
                }
            }
            else
            {
                error_flag += "User name or Password Invalid.\n";
            }

            return error_flag;


        }
#endregion


        #region Logout
        public string logout()
        {
            DataTable dt = new DataTable();
            dt = lib.SelectQuery("select * from Tbl_USers where UserName='" + _username + "' and Password='" + _password + "'");
            if (dt.Rows.Count > 0)
            {

                int flag = lib.InsertQuery("update Tbl_Users set status='0' where UserName='" + dt.Rows[0]["UserName"].ToString() + "'");
                if (flag == 1)
                {
                    error_flag = string.Empty;
                }

                else
                {
                    error_flag = "failure";
                }
                return error_flag;

            }

            else
            {
                error_flag = "Invalid Password";
                return error_flag;
            }
        }

        #endregion


        #region Exit
        public bool exit()
        {
            int flag = lib.InsertQuery("update Tbl_Users set status=null, IsPlaying=null ,Scores=null, RoundNo=null");
            if (flag == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        #endregion





    }
}
