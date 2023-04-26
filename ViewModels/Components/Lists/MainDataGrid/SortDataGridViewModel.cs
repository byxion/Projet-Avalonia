using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using ReactiveUI;
using GAG.Models;

namespace GAG.ViewModels.Components.Lists.MainDataGrid
{
    public class SortDataGridViewModel : ViewModelBase
    {
        //private string? _title = "Choix du filtrage";
        //public string? Title
        //{
        //    get => _title;
        //    set => this.RaiseAndSetIfChanged(ref _title, value);
        //}

        //private string? _selectedGrafcet;
        //public string? SelectedGrafcet
        //{
        //    get => _selectedGrafcet;
        //    set => this.RaiseAndSetIfChanged(ref _selectedGrafcet, value);
        //}

        //public ObservableCollection<Item> Items { get; set; }
        //public ObservableCollection<string> GrafcetList { get; set; }
        //public Window Window { get; set; }

        //public SortDataGridViewModel()
        //{
        //    Items = new ObservableCollection<Item>();
        //    GrafcetList = new ObservableCollection<string>();
        //}
        //public SortDataGridViewModel(ObservableCollection<Item> items, Window window)
        //{
        //    Items = items;
        //    Window = window; /* Propre ? */
        //    GrafcetList = new ObservableCollection<string>();
        //    foreach (var item in Items)
        //    {
        //        if (!GrafcetList.Contains(item.Grafcet))
        //        {
        //            GrafcetList.Add(item.Grafcet);
        //        }
        //    }
        //}

        //private ObservableCollection<Item> _filteredItems;
        //public ObservableCollection<Item> FilteredItems
        //{
        //    get => _filteredItems;
        //    set => this.RaiseAndSetIfChanged(ref _filteredItems, value);
        //}

        //public void Filter()
        //{
        //    if (SelectedGrafcet != null)
        //    {
        //        FilteredItems = new ObservableCollection<Item>(Items.Where(x => x.Grafcet == SelectedGrafcet));
        //    }
        //    else
        //    {
        //        FilteredItems = new ObservableCollection<Item>(Items);
        //    }
        //}

        //public void Close()
        //{
        //    Window.Close();
        //}

        //public void Save()
        //{
        //    Filter();
        //    this.Close();
        //}

        //public void Cancel()
        //{
        //    this.Close();
        //}
    }
}

