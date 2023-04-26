using ReactiveUI;
using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using GAG.Models;
using GAG.Views;

namespace GAG.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {

        public void InitGrafcetViewMode()
        {
            GrafcetMain = new GrafcetMainViewModel();
            //grafcetNumber = List.Items.Count.ToString();

            SupprimerGrafcet = ReactiveCommand.CreateFromTask<Grafcet>(async g => await ExecuteSupprimerGrafcet(g));

            ModifierGrafcet = ReactiveCommand.CreateFromTask<Grafcet>(async g => await ExecuteModifierGrafcet(g));
        }

        ViewModelBase grafcetMain;

        public ViewModelBase GrafcetMain
        {
            get => grafcetMain;
            private set => this.RaiseAndSetIfChanged(ref grafcetMain, value);

        }

        public GrafcetMainViewModel List { get; set; }

        async Task ExecuteSupprimerGrafcet(Grafcet grafcet)
        {
            var model = new ConfirmViewModel();

            var confirm = await ShowDialog.Handle(model);

            if (confirm.Result)
            {
                List.Items.Remove(grafcet);
                GafcetNumber = List.Items.Count.ToString();
            }
        }

        async Task ExecuteModifierGrafcet(Grafcet grafcet)
        {
            var vm = new UpdateGrafcetViewModel(grafcet);

            Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (Grafcet)null))
                .Take(1)
                .Subscribe(model =>
                {
                    if (model != null)
                    {
                        var item = List.Items.FirstOrDefault(i => i.Nom == model.Nom);

                        if (item != null)
                        {
                            item.Nom = model.Nom;
                            item.Titre = model.Titre;
                            item.Type = model.Type;
                        }
                    }

                    GrafcetMain = List;
                });

            GrafcetMain = vm;
        }

        public void AddGrafcet()
        {
            var vm = new AddGrafcetViewModel();

            Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (Grafcet)null))
                .Take(1)
                .Subscribe(model =>
                {
                    if (model != null)
                    {
                        List.Items.Add(model);
                        GafcetNumber = List.Items.Count.ToString();
                    }

                    GrafcetMain = List;
                });

            GrafcetMain = vm;
        }

        public ReactiveCommand<Grafcet, Unit> SupprimerGrafcet { get; set; }

        public ReactiveCommand<Grafcet, Unit> ModifierGrafcet { get; set; }

        private string _gafcetNumber;
        public string GafcetNumber
        {
            get => _gafcetNumber;
            set => this.RaiseAndSetIfChanged(ref _gafcetNumber, value);
        }
    }
}
