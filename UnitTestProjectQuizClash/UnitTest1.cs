using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiz_Clash;

namespace UnitTestProjectQuizClash
{
    [TestClass]
    public class UnitTest1
    {
      
        
        [TestMethod]
        public void TestAuthentication_Checklen()
        {
            
            Quiz_Clash.Authentication.Authentication auth = new  Quiz_Clash.Authentication.Authentication();
            auth.FName = "hassan";
            auth.LName = "mansoor";
            auth.Email = "hassan_mansoor@yahoo.com";
            auth.Password = "1234567";
            auth.UserName = "hassan123";
           string actual= auth.check_len();
           string expected = string.Empty;
           Assert.AreEqual(actual, expected);

        }

             [TestMethod]
        public void TestAuthentication_validate_specialchar()
        {

            Quiz_Clash.Authentication.Authentication auth = new Quiz_Clash.Authentication.Authentication();
            auth.FName = "hassan";
            auth.LName = "mansoor";
            auth.Email = "hassan_mansoor@yahoo.com";
            auth.Password = "1234567";
            auth.UserName = "hassan123";
            string actual = auth.validate_specialchar();
            string expected = string.Empty;
            Assert.AreEqual(actual, expected);

        }

             [TestMethod]
        public void TestAuthentication_validation()
        {

            Quiz_Clash.Authentication.Authentication auth = new Quiz_Clash.Authentication.Authentication();
            auth.FName = "hassan";
            auth.LName = "mansoor";
            auth.Email = "hassan_mansoor@yahoo.com";
            auth.Password = "1234567";
            auth.UserName = "hassan123";
            string actual = auth.validation();
            string expected = string.Empty;
            Assert.AreEqual(actual, expected);

        }

          [TestMethod]

             public void TestAuthentication_Submit()
             {

                 Quiz_Clash.Authentication.Authentication auth = new Quiz_Clash.Authentication.Authentication();
                 auth.FName = "hassan";
                 auth.LName = "mansoor";
                 auth.Email = "hassan_mansoor@yahoo.com";
                 auth.Password = "1234567";
                 auth.UserName = "hassan123";
                 string actual = auth.Sumbit();
                 string expected = string.Empty;
                 Assert.AreEqual(actual, expected);

             }

        [TestMethod]
          public void TestAuthentication_Validate_login()
          {

              Quiz_Clash.Authentication.Authentication auth = new Quiz_Clash.Authentication.Authentication();
              auth.FName = "hassan";
              auth.LName = "mansoor";
              auth.Email = "hassan_mansoor@yahoo.com";
              auth.Password = "1234567";
              auth.UserName = "hassan123";
              string actual = auth.validate_login();
              string expected = string.Empty;
              Assert.AreEqual(actual, expected);

          }



        //[TestMethod]
        //public void TestAuthentication_ChangePassword()
        //{

        //    Quiz_Clash.Authentication.Authentication auth = new Quiz_Clash.Authentication.Authentication();

        //    auth.Password = "abcd123456789";
        //    auth.UserName = "hassan123";
        //    auth.NewPassword = "12345678";
        //    string actual = auth.ChangePassword();
        //    string expected = "Password Updated successfully";
        //    Assert.AreEqual(actual, expected);

        //}

        //



        //logout andchangepassword cannot run at the same time 

        [TestMethod]
        public void TestAuthentication_Logout()
        {

            Quiz_Clash.Authentication.Authentication auth = new Quiz_Clash.Authentication.Authentication();

            auth.Password = "12345678";
            auth.UserName = "hassan123";
           
            string actual = auth.logout();
            string expected = string.Empty;
            Assert.AreEqual(actual, expected);

        }


        [TestMethod]
        public void TestQuestions_GenerateQuestion()
        {

            Quiz_Clash.GamePlay.Questions ques = new Quiz_Clash.GamePlay.Questions();

         bool actual=  ques.Generate_Qestion(1);

           
           bool expected = true;
            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void TestQuestions_InsertQuestion()
        {

            Quiz_Clash.GamePlay.Questions ques = new Quiz_Clash.GamePlay.Questions();
            ques.Question = "This is Sample Question";
            ques.Category = "1";
            ques.ChoiceA = "A";
            ques.ChoiceB = "B";
            ques.ChoiceC = "C";
            ques.ChoiceD = "D";
            ques.CorrectAnswer = "A";

           string actual = ques.InsertQuestion();


            string expected = "success";
            Assert.AreEqual(actual, expected);

        }


        [TestMethod]
        public void TestQuestions_Validation()
        {

            Quiz_Clash.GamePlay.Questions ques = new Quiz_Clash.GamePlay.Questions();
            ques.Question = "This is Sample Question";
            ques.Category = "1";
            ques.ChoiceA = "A";
            ques.ChoiceB = "B";
            ques.ChoiceC = "C";
            ques.ChoiceD = "D";
            ques.CorrectAnswer = "A";

            string actual = ques.Validaiton();


            string expected = string.Empty;
            Assert.AreEqual(actual, expected);

        }

    }
}
