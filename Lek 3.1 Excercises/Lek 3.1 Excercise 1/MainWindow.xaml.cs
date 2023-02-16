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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lek_3._1_Excercise_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if(lbxAgents.SelectedIndex > 0)
            {
                lbxAgents.SelectedIndex = --lbxAgents.SelectedIndex;
            }
        }

        private void BtnForward_Click(object sender, RoutedEventArgs e)
        {
            if(lbxAgents.SelectedIndex < lbxAgents.Items.Count - 1)
            {
                lbxAgents.SelectedIndex = ++lbxAgents.SelectedIndex;
            }
        }

        private void BtnAddNew_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainWindowViewModel;
            vm.AddNewAgent();
            lbxAgents.SelectedIndex = lbxAgents.Items.Count - 1;
            tbxId.Focus();
        }

    }
}
