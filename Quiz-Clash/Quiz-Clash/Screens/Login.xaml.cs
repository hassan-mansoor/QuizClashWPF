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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            Authentication.Authentication auth = new Authentication.Authentication();
            GamePlay.GameRounds rounds = new GamePlay.GameRounds();
            auth.UserName = txt_Username.Text.Trim();
            auth.Password = txt_Pswd.Password.ToString().Trim();
            string flag = auth.validate_login();
            if (flag == string.Empty)
            {
                rounds.NextRound(2,auth.UserName);
                Screens.Game game = new Screens.Game(auth.UserName);
                game.Show();
            }
            else
            {
               var res= MessageBox.Show(flag, "Error Information", MessageBoxButton.OK, MessageBoxImage.Error);
                auth.error_flag = string.Empty;
                if (res.ToString() == "OK")
                {
                    txt_Username.Text = string.Empty;
                    txt_Pswd.Password = string.Empty;
                    this.Show();
                }
            } 


        }
    }
}
