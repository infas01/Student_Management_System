using Desktop_UI.ViewModels;
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

namespace Desktop_UI.Views
{
    /// <summary>
    /// Interaction logic for AddStudentWindowView.xaml
    /// </summary>
    public partial class AddStudentWindowView : Window
    {
        public AddStudentWindowView(AddStudentVM addSW)
        {
            InitializeComponent();
            DataContext = addSW;
            addSW.CloseAction = () => Close();
            
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
