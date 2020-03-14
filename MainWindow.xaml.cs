using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CaricatureBasics
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
        UC_Swan1 swan1 = new UC_Swan1();
        UC_Car car = new UC_Car();
        private void button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnSwanUI_Click(object sender, RoutedEventArgs e)
        {
            mainArea.Children.Clear();
            mainArea.Children.Add(swan1);
        }

        private void btnCarUI_Click(object sender, RoutedEventArgs e)
        {
            mainArea.Children.Clear();
            mainArea.Children.Add(car);
        }
    }
}
