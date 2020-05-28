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
    /// Interaction logic for StationView.xaml
    /// </summary>
    public partial class StationView : UserControl
    {
        public StationView()
        {
            InitializeComponent();
        }

        private void selectStation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = (StationViewModel)DataContext;
            t.RefreshTrains();
        }
    }
}
