using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using ObsTest.Models;
using ObsTest.ViewModels;

namespace ObsTest.Views
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private void Dec_click(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            ((Number)fe.DataContext).Decrement();
        }

        private void Inc_click(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            ((Number)fe.DataContext).Increment();
        }

        private  void Print_Click(object sender, RoutedEventArgs e)
        {
            Enumerable.Range(0,5).ToList().ForEach(x => Debug.WriteLine("\n"));
            SimpleIoc.Default.GetInstance<MainViewModel>().Data1.ToList().ForEach(x => Debug.WriteLine(x.Value));
        }
    }
}
