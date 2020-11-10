using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using ObsTest.Models;

namespace ObsTest.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
        }
    
        public ObservableCollection<Number> Data1 { get; set; } = GetData();
        public ObservableCollection<Number> Data2 { get; set; } = GetData();

        private static ObservableCollection<Number> GetData()
        {
            var data = new ObservableCollection<Number>();
            var rnd = new Random();
            Enumerable.Range(0, 10).ToList().ForEach(x => { data.Add(new Number {Value = rnd.Next(-50, 50)}); });
            return data;

        }
    }
}
