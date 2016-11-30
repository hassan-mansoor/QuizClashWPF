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
    /// Interaction logic for AddQuestions.xaml
    /// </summary>
    public partial class AddQuestions : Window
    {
        string _correct_anser ,_category= string.Empty;
        
        public AddQuestions()
        {
            InitializeComponent();
            OnLoad();
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            SelectedAsnwer();
            GamePlay.Questions InsertQuestion = new GamePlay.Questions();
            InsertQuestion.Question = txt_question.Text.Trim().ToString();
            InsertQuestion.ChoiceA = txt_AnswerA.Text.Trim().ToString();
            InsertQuestion.ChoiceB = txt_AnswerB.Text.Trim().ToString();
            InsertQuestion.ChoiceC = txt_AnswerC.Text.Trim().ToString();
            InsertQuestion.ChoiceD = txt_AnswerD.Text.Trim().ToString();
            InsertQuestion.CorrectAnswer = _correct_anser;
            InsertQuestion.Category = _category;
            string flag = InsertQuestion.InsertQuestion();
            if (flag == string.Empty || flag == "success")
            {
                var result = MessageBox.Show("Question added successfully.\nDo you want to add more", "Information", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                if (result.ToString() == "OK")
                {
                    txt_question.Text = string.Empty;
                    txt_AnswerA.Text = string.Empty;
                    txt_AnswerB.Text = string.Empty;
                    txt_AnswerC.Text = string.Empty;
                    txt_AnswerD.Text = string.Empty;
                    cmb_ans.SelectedIndex = 0;
                }
                
            }
            else
            {
                MessageBox.Show(flag, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            


        }

        public void OnLoad()
        {
            cmb_ans.Items.Add("ChoiceA");
            cmb_ans.Items.Add("ChoiceB");
            cmb_ans.Items.Add("ChoiceC");
            cmb_ans.Items.Add("ChoiceD");
            cmb_cat.Items.Add("Entertaintment");
            cmb_cat.Items.Add("Animal");
            cmb_cat.Items.Add("Plant");
            cmb_cat.Items.Add("General");

            cmb_ans.SelectedIndex = 0;
            cmb_cat.SelectedIndex = 0;
        }

        public void SelectedAsnwer()
        {
            switch(cmb_ans.SelectedItem.ToString())
            {
                case "ChoiceA":
                    _correct_anser = txt_AnswerA.Text.ToString();
                    break;
                    
                case "ChoiceB":
                    _correct_anser = txt_AnswerB.Text.ToString();
                    break;
                case "ChoiceC":
                    _correct_anser = txt_AnswerC.Text.ToString();
                    break;
                case "ChoiceD":
                    _correct_anser = txt_AnswerD.Text.ToString();
                    break;


            }


            switch (cmb_cat.SelectedItem.ToString())
            {
                case "Entertaintment":
                    _category ="1";
                    break;

                case "Animal":
                    _category = "2";
                    break;
                case "Plant":
                    _category = "3";
                    break;
                case "General":
                    _category = "4";
                    break;

            }


           
        }




    }
}
