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

namespace Coursework
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        EventFacade facade = new EventFacade();
        public ListWindow()
        {
            InitializeComponent();
        }

        private void SearchVisits_Click(object sender, RoutedEventArgs e)
        {
            List<String> visits = new List<String>();
            visits = facade.GetVisits(NameTxt.Text, StartDateTxt.Text, EndDateTxt.Text);

            DisplayList.Text = String.Join(Environment.NewLine, visits);
        }

        private void SearchContacts_Click(object sender, RoutedEventArgs e)
        {
            List<String> contacts = new List<String>();
            contacts = facade.GetContacts(UserIdTxt.Text, AfterDateTxt.Text);
            DisplayList.Text = String.Join(Environment.NewLine, contacts);
        }
    }
}
