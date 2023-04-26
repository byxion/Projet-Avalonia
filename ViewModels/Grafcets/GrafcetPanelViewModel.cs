using ReactiveUI;
using GAG.Models;

namespace GAG.ViewModels
{
    public class GrafcetPanelViewModel : ViewModelBase
    {

        Grafcet _grafcetSelected;
        public Grafcet GrafcetSelected
        {
            get => _grafcetSelected;
            set => this.RaiseAndSetIfChanged(ref _grafcetSelected, value);
        }
    }


}
