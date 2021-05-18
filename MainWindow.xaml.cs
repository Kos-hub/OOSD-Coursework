using System;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coursework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EventFacade facade = new EventFacade();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            int tel_num = 0;
            if(Int32.TryParse(tel_NoTxt.Text, out tel_num) && facade.ValidateTel(tel_NoTxt.Text))
            {
                facade.AddNewUser(tel_num);
            }
            else
            {
                MessageBox.Show("The input is invalid. Please enter a valid telephone number that has not been registered.");
            }
        }

        private void AddLocationBtn_Click(object sender, RoutedEventArgs e)
        {
            facade.AddNewLocation(AddNameTxt.Text);
        }



        private void SearchListBtn_Click(object sender, RoutedEventArgs e)
        {
            ListWindow window = new ListWindow();
            window.Show();
        }

        private void AddContactBtn_Click(object sender, RoutedEventArgs e)
        {
            int test1 = 0;
            int test2 = 0;

            if(!Int32.TryParse(AddUserTxt.Text, out test1) && !Int32.TryParse(AddUserTxt1.Text, out test2))
            {
                MessageBox.Show("Both invalid inputs! Please insert a number.");
                return;
            } 
            if(!Int32.TryParse(AddUserTxt.Text, out test1))
            {
                MessageBox.Show("First user has an invalid input! Please insert a number.");
                return;
            }
            else if(!Int32.TryParse(AddUserTxt1.Text, out test2))
            {
                MessageBox.Show("Second user has an invalid input! Please insert a number.");
                return;
            }

            User user = facade.LoadUserFromCSV(AddUserTxt.Text);
            User user_1 = facade.LoadUserFromCSV(AddUserTxt1.Text);

            if(user == null)
            {
                MessageBox.Show("User: " + AddUserTxt.Text + " does not exist.");
            }
            else if(user_1 == null)
            {
                MessageBox.Show("User: " + AddUserTxt1.Text + " does not exist.");
            }
            else
            {
                facade.AddContact(user, user_1, ContactDateTxt.Text);
            }

        }

        private void AddVisitBtn_Click(object sender, RoutedEventArgs e)
        {
            facade.AddVisit(facade.LoadUserFromCSV(AddVisitUserTxt.Text), facade.LoadLocationFromCSV(AddLocationTxt.Text), VisitDateTxt.Text);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var filepath = @"C:\Users\Gianmarco\source\repos\Coursework\log.csv";
            File.Delete(filepath);
            File.Create(filepath);
        }
    }
}
