using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.UI.Xaml;
using Obs.UWP.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Obs.UWP.Models;

namespace Obs.UWP.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => ViewModelLocator.Current.MainViewModel;

        public MainPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Data1.CollectionChanged += (s, e) => { PrintAll(); };
            ViewModel.Data2.CollectionChanged += (s, e) => { PrintAll(); };
        }

        private void PrintAll()
        {
            Enumerable.Range(0,5).ToList().ForEach(x => Debug.Write("\n"));
            for (int i = 0; i < Math.Max(ViewModel.Data1.Count, ViewModel.Data2.Count); i++)
            {
                if(i < ViewModel.Data1.Count){
                Debug.Write(ViewModel.Data1[i].Value);
                }
                Debug.Write("\t\t\t");
                if (i < ViewModel.Data2.Count)
                {
                    Debug.Write(ViewModel.Data2[i].Value);
                }

                Debug.Write("\n");
            }
        }

        private void ListView_OnDragOver(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                e.AcceptedOperation = DataPackageOperation.Move;
            }
        }


        private void ListView_OnDragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            var items = string.Join(",", e.Items.Cast<Number>().Select(i => i.Id));
            e.Data.SetText(items);
            e.Data.RequestedOperation = DataPackageOperation.Move;
        }

        private async void ListView_OnDrop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                var id = await e.DataView.GetTextAsync();
                var itemIdsToMove = id.Split(',');
                var destinationListView = sender as ListView;
                var listViewItemsSource = destinationListView?.ItemsSource as ObservableCollection<Number>;
                if (listViewItemsSource != null)
                {
                    foreach (var itemId in itemIdsToMove)
                    {
                        var source = ViewModel.Data1.Where(x => x.Id.ToString() == itemId).Count() == 1
                            ? ViewModel.Data1
                            : ViewModel.Data2;
                        var itemToMove = source.First(i => i.Id.ToString() == itemId);
                        listViewItemsSource.Add(itemToMove);
                        
                        source.Remove(itemToMove);
                    }
                }
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            PrintAll();
        }
    }
}
