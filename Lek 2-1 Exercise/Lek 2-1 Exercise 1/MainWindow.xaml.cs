using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lek_2_1_Exercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Sailboat boat;

        public MainWindow()
        {
            InitializeComponent();
            boat = new Sailboat();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(tbxName);
        }

        private void tbxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            boat.Name = tbxName.Text;
        }

        private void tbxLenght_TextChanged(object sender, TextChangedEventArgs e)
        {
            boat.Length = Double.Parse(tbxLenght.Text);
        }

        private void btnCalculateHullSpeed_Click(object sender, RoutedEventArgs e)
        {
            tbxHullSpeed.Text = boat.Hullspeed().ToString("F1");
        }
    }
}
