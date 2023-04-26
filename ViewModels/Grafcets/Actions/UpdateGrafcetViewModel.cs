using Avalonia.Controls;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using GAG.Models;
namespace GAG.ViewModels
{
    internal class UpdateGrafcetViewModel : ViewModelBase
    {
        string nom;
        string titre;

        public ObservableCollection<ComboBoxItem> cbItems { get; set; }
        public ComboBoxItem SelectedcbItem { get; set; }

        public UpdateGrafcetViewModel(Grafcet grafcet)
        {
            var okEnabled = this.WhenAnyValue(
                x => x.Nom,
                x => !string.IsNullOrWhiteSpace(x));

            Ok = ReactiveCommand.Create(
                () => new Grafcet { Nom = Nom, Titre = titre, Type = SelectedcbItem.Content.ToString() },
                okEnabled);

            Cancel = ReactiveCommand.Create(() => { });

            cbItems = new ObservableCollection<ComboBoxItem>();
            var cbItem = new ComboBoxItem { Content = "Simple" };
            SelectedcbItem = cbItem;
            cbItems.Add(cbItem);
            cbItems.Add(new ComboBoxItem { Content = "Phase" });
            cbItems.Add(new ComboBoxItem { Content = "Formule" });

            SetGrafcet(grafcet);

        }

        private void SetGrafcet(Grafcet grafcet)
        {
            Nom = grafcet.Nom;
            Titre = grafcet.Titre;

            if (grafcet.Type == "Simple")
                SelectedcbItem = cbItems[0];
            if (grafcet.Type == "Phase")
                SelectedcbItem = cbItems[1];
            if (grafcet.Type == "Formule")
                SelectedcbItem = cbItems[1]; ;

        }

        public string Nom
        {
            get => nom;
            set => this.RaiseAndSetIfChanged(ref nom, value);
        }

        public string Titre
        {
            get => titre;
            set => this.RaiseAndSetIfChanged(ref titre, value);
        }

        public ReactiveCommand<Unit, Grafcet> Ok { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
    }
}
