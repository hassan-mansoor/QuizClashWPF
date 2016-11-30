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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            cmb_Email_Ext.SelectedIndex = 0;
            cmb_Email_Ext.Items.Add("gmail.com");
            cmb_Email_Ext.Items.Add("hotmail.com");            
            cmb_Email_Ext.Items.Add("yahoo.com");
            cmb_Email_Ext.Items.Add("aol.com");
            Policy.Content = "Password Policy:\n1.First Name,Username cannot be empty andat least 3 characters.\n2.Email canot be empty\n3.Password should be at least 7 characters long.";
        }

        private void btn_reg_Click(object sender, RoutedEventArgs e)
        {

        
            string email_extension = lblat.Content + cmb_Email_Ext.SelectedItem.ToString();


            Authentication.Authentication auth = new Authentication.Authentication();
           
            auth.FName=txt_Fname.Text.ToString();
            auth.LName = txt_Lname.Text.ToString();
            auth.Email = txt_email.Text.ToString();
            auth.Email_Ext = email_extension;
            auth.Password = txt_pass.Password.ToString();
            auth.UserName = txt_Uname.Text.ToString();

     string flag= auth.Sumbit();
     if (flag ==string.Empty)
     {
       var res= MessageBox.Show("Thank you for registration","Congratulations",MessageBoxButton.OK,MessageBoxImage.Information);
       if (res.ToString() == "OK")
       {
           this.Close();
           MainWindow main = new MainWindow();
           main.Show();
       }
     }
     else
     {
         MessageBox.Show(flag,"Error Information",MessageBoxButton.OK,MessageBoxImage.Error);
         auth.error_flag = string.Empty;
     } 

        }

        private void cmb_Email_Ext_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
