using System;
using System.Collections.Generic;
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
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            Authentication.Authentication auth = new Authentication.Authentication();
            GamePlay.GameRounds rounds = new GamePlay.GameRounds();
            auth.UserName = txt_Username.Text.Trim();
            auth.Password = txt_oldPswd.Password.ToString().Trim();
            auth.NewPassword = txt_newPswd.Password.ToString().Trim();
            
                string stus = auth.ChangePassword();
                if (stus == string.Empty)
                {
                    var res = MessageBox.Show(stus, "Error Information", MessageBoxButton.OK, MessageBoxImage.Error);
                    auth.error_flag = string.Empty;
                    if (res.ToString() == "OK")
                    {
                        txt_Username.Text = string.Empty;
                        txt_oldPswd.Password = string.Empty;
                        txt_newPswd.Password = string.Empty;
                        this.Show();
                    }

                }
                else
                {
                     MessageBox.Show(stus, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                     this.Close();

                }
                    




        }
    }
}
