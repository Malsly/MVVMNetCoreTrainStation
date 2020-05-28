using System;
using System.Collections.Generic;
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
using ViewModels.Impl;

namespace TrainStation.Views
{
    /// <summary>
    /// Interaction logic for TicketView.xaml
    /// </summary>
    public partial class TicketView : UserControl
    {
        public TicketView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var t = (StationViewModel)DataContext;
            t.RefreshTickets();
        }
    }
}
