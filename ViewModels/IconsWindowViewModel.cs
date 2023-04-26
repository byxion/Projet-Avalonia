using System.Collections.ObjectModel;
using GAG.Models;

namespace GAG.ViewModels
{
    internal class IconsWindowViewModel : ViewModelBase
    {
        public IconsWindowViewModel()
        { 
            Items = new ObservableCollection<Item>();

            for( var i =0; i< 6919; i++ )
            {
                Items.Add(new Item { Num = i});
            }

        }
        public ObservableCollection<Item> Items { get; }
    }
}
