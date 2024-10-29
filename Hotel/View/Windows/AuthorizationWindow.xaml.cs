using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
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
using HoteL.Models;


namespace HoteL.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {

        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validation() == true) 
            {
                Authentication();
                BlockingUserByDate();
            }

        }

        public bool Validation()
        {
            if (LoginTb.Text == string.Empty && PasswordPb.Password == string.Empty)
            {
                //..выводим предупреждение
                Feedback.Warning("Поля для ввода не должны быть пустыми. Введите логин и пароль!");
                return false;
            }
            else if (LoginTb.Text == string.Empty)
            {
                Feedback.Warning("Поля для ввода не должны быть пустыми. введите логин!");
                  return false;
            }
            else if (LoginTb.Text == string.Empty)
            {
                Feedback.Warning("Поля для ввода не должны быть пустыми. введите пароль!");
                  return false;
            }

            return true;
        }

        public void Authentication()
        {
            App.currentUser = App.context.User.FirstOrDefault(user => user.Login == LoginTb.Text
            && user.Password == PasswordPb.Password);
            if (App.currentUser == null)
            {
                Feedback.Error("Вы ввели неверный логин или пароль. Пожалуйста провертье еще раз данные");
            }
            else if (App.currentUser.IsBlocked == true)
            {
                Feedback.Error("Вы заблокированно. Обратитесь к администратору!");
            }
            else if (App.currentUser.IsActivated == false)
            {
                ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow();
                changePasswordWindow.Show();
                Hide();
            }
            else
            {
                Feedback.Information("Вы успшно авторизовались");
            }
        
        
        }
    
        public void BlockingUserByDate()
        {
            foreach(var user in App.context.User)
            {
                if(user.RegistrationDate.AddMonths(1) <= DateTime.Now.Date)
                {
                    user.IsBlocked = true;
                }
            }
        }
    
    }

}
