using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Quiz_Clash.Screens
{
    /// <summary>
    /// Interaction logic for Logout.xaml
    /// </summary>
    public partial class Logout : Window
    {
        DBLib lib = new DBLib();
        public Logout()
        {
            InitializeComponent();
            Onload();
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            Authentication.Authentication auth = new Authentication.Authentication();
            auth.UserName = cmb_user.SelectedItem.ToString();
            auth.Password = txt_Pswd.Password.ToString();
           string stus= auth.logout();
           if (stus == string.Empty)
           {
               this.Close();
              
           }
           else
           {
               MessageBox.Show(stus,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
           }
        }


        public void Onload()
        {
            DataTable dt = new DataTable();
            dt = lib.SelectQuery("select * from Tbl_Users where status='1'");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmb_user.Items.Add(dt.Rows[i]["UserName"].ToString());
                }

                cmb_user.SelectedIndex = 0;
            }
            else
            {
                cmb_user.Items.Add("No acitve users");
                txt_Pswd.IsEnabled = false;
                btn_logout.IsEnabled = false;
            }
        }
    }
}
