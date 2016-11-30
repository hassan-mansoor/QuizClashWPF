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
    /// Interaction logic for Rounds.xaml
    /// </summary>
    public partial class Rounds : Window
    {
       
        public Rounds()
        {
            InitializeComponent();
      
           ShowScores();
        }

        private void btn_Round1_Click(object sender, RoutedEventArgs e)
        {
            
            Screens.Login login = new Login();
            this.Close();
            login.Show();

        }

        private void btn_Round2_Click(object sender, RoutedEventArgs e)
        {
           
          

            Screens.Roundlogin log = new Roundlogin(3);
            this.Close();
            log.Show();

        }

        private void btn_Round3_Click(object sender, RoutedEventArgs e)
        {
            Screens.Roundlogin log = new Roundlogin(4);
            this.Close();
            log.Show();
        }

        private void btn_Round4_Click(object sender, RoutedEventArgs e)
        {
            Screens.Roundlogin log = new Roundlogin(4);
            this.Close();
            log.Show();
        }



              

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Authentication.Authentication auth=new Authentication.Authentication();
            bool flag = auth.exit();
            if (flag == true)
            {
                MainWindow main = new MainWindow();
                this.Close();
                main.Show();
            }
            //this.Close();
        }

        private void question_Click(object sender, RoutedEventArgs e)
        {
            Screens.AddQuestions question = new AddQuestions();
          
            question.Show();
        }

        private void ChngPass_Click(object sender, RoutedEventArgs e)
        {
            Screens.ChangePassword chngpass = new ChangePassword();
            chngpass.Show();

        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            Screens.Logout logout = new Logout();
            logout.Show();
        }

        public void ShowScores()
        {
            GamePlay.Users _user=new GamePlay.Users();
            string scores=_user.displayScores();
            if (scores.ToString() == string.Empty)
            {
                lblscore1.Content = "0";
                lblscore2.Content = "0";
            }
            else
            {
                string[] arr_scores = scores.Split(',');
                lblscore1.Content = arr_scores[0].ToString();
                lblscore2.Content = arr_scores[1].ToString();
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }





    }
}
