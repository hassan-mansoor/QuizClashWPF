using Quiz_Clash.Screens;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz_Clash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBLib lib = new DBLib();
        static int count=0;
        List<string> Slct_Players = new List<string>();
        public MainWindow()
        {
            InitializeComponent();

          
            load_List();
        }

        private void load_List()
        {
            DataTable dt = new DataTable();
            dt = lib.SelectQuery("select * from [Tbl_Users]");
            if (dt.Rows.Count==0)
            {
                lblNote.Content = "No user Exist Please register.";
                btn_reg.IsEnabled = false;
                stck_list.Visibility = Visibility.Collapsed;
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lst_user.Items.Add(dt.Rows[i]["id"].ToString() + "--" + dt.Rows[i]["username"].ToString());
                }
            }
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (count >=2)
            {
                lblNote.Content = "You can select only two users";


                lst_user.SelectedIndex = -1;
                count = 0;
            }
            else
            {
                count++;
                lblNote.Content = string.Empty;
            }
        }

        private void btn_reg_Click(object sender, RoutedEventArgs e)
        {
            

                if (lst_user.SelectedItems.Count < 2)
                {
                    lblNote.Content = "Select two Players";
                }
                else
                {
                    lblNote.Content = string.Empty;

                    string i = string.Empty;
                    foreach (var player in lst_user.SelectedItems)
                    {
                        Slct_Players.Add(player.ToString().Substring(3));
                    }

                    GamePlay.Users users = new GamePlay.Users();

                    int Flag = users.Players(Slct_Players);

                    if (Flag == 0)
                    {
                        //Screens.Login _login = new Screens.Login();
                        //this.Close();
                        //_login.Show();


                        Screens.Rounds round = new Screens.Rounds();
                        this.Close();
                        round.Show();
                    }
                    else
                    {
                        MessageBox.Show("Something Wrong with Database", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
        


        }



        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            Screens.Register register = new Register();
            register.Show();
        }


        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            GamePlay.SetContents contents = new GamePlay.SetContents();
            contents.close();
            this.Close();
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
          

        
        }
        
       
    }
}
