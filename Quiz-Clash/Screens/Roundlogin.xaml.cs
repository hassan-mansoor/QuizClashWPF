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
    /// Interaction logic for Roundlogin.xaml
    /// </summary>
    public partial class Roundlogin : Window
    {
        int _roundno;
        public Roundlogin(int roundno)
        {
            InitializeComponent();
            _roundno = roundno;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            DBLib lib = new DBLib();
            dt = lib.SelectQuery("select * from Tbl_Users where status='1' and UserName='"+txt_username.Text.ToString()+"'");
            if (dt.Rows.Count > 0)
            {
                GamePlay.GameRounds round = new GamePlay.GameRounds();
                round.NextRound(_roundno, txt_username.Text.ToString());
                Screens.Game game = new Screens.Game(txt_username.Text);

                this.Close();
                game.Show();
            }
            else
            {
                MessageBox.Show("Invalid User","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                txt_username.Text = string.Empty;
            }
        
        }

       



    }
}
