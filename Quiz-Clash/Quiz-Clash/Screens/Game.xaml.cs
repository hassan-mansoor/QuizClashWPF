using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace Quiz_Clash.Screens
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        string currentTime,CurrentPlayer = string.Empty;
       // int _time = 10;
        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch stopWatch = new Stopwatch();
        GamePlay.Questions ques = new GamePlay.Questions();
      

      static int count=0;
      static int _round=0;
        public Game(string currentPlayer)
        {
            InitializeComponent();
            count = 0;
         
            CurrentPlayer=currentPlayer;
            lbl_status.Content = CurrentPlayer + " is playing....";
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
            Load(count);
            stopWatch.Start();
            dt.Start();
        }


       
        void dt_Tick(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                TimeSpan ts = stopWatch.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

                watch.Content = currentTime;

                if (ts.Seconds ==10)
                {
                   count++;

                    Load(count);
                  

                }
            }
        }





        public void Load(int num)
        {
            bool Flag;
            ResetBtnBG();
            stopWatch.Reset();
            stopWatch.Start();
            dt.Start();
         Flag=ques.Generate_Qestion(num);
         if (Flag == true)
         {
             txt_question.Text = ques.Question;
             btn_A.Content = ques.ChoiceA;
             btn_B.Content = ques.ChoiceB;
             btn_C.Content = ques.ChoiceC;
             btn_D.Content = ques.ChoiceD;
         }

         else
         {
             if (stopWatch.IsRunning)
                 stopWatch.Stop();

             if(count>=4){
           var res=  MessageBox.Show("you Turn is Over","Turn over",MessageBoxButton.OK,MessageBoxImage.Information);
           if (res.ToString() == "OK")
           {

               GamePlay.Users _User = new GamePlay.Users();
               _User.CurPlayer = CurrentPlayer;
               _User.PlayerScore = ques.final;
               _User.DeactivePlayer();
              _User.AddScores();
               if (_User.UserStaus() == string.Empty)
               {
                   count = 0;
                   Screens.Login login = new Screens.Login();
                   this.Close();
                   login.Show();
               }
               else if (_User.UserStaus() =="Finish")
               {
                  
                   Screens.Rounds round = new Rounds();
                   this.Close();
                   round.Show();
                  
               }

                    }
         }

            

         }

        }




        private void btn_A_Click(object sender, RoutedEventArgs e)
        {
            if (stopWatch.IsRunning)
                      stopWatch.Stop();
            btn_A.Background = Brushes.Green;
            ques.Match_Answer(btn_A.Content.ToString());
        }

        private void btn_B_Click(object sender, RoutedEventArgs e)
        {
            if (stopWatch.IsRunning)
               stopWatch.Stop();
            btn_B.Background = Brushes.Green;
            ques.Match_Answer(btn_B.Content.ToString());
        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            if (stopWatch.IsRunning)
                stopWatch.Stop();
            btn_C.Background = Brushes.Green;
            ques.Match_Answer(btn_C.Content.ToString());
        }

        private void btn_D_Click(object sender, RoutedEventArgs e)
        {
            if (stopWatch.IsRunning)
                stopWatch.Stop();
            btn_D.Background = Brushes.Green;
            ques.Match_Answer(btn_D.Content.ToString());
        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            count++;
           
                Load(count);
           
        }



        public void ResetBtnBG()
        {
            btn_A.Background = Brushes.Silver;
            btn_B.Background = Brushes.Silver;
            btn_C.Background = Brushes.Silver;
            btn_D.Background = Brushes.Silver;
        }





    }
}
