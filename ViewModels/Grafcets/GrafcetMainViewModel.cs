using Avalonia.Controls.Selection;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using GAG.Services;
using GAG.Views;
using System.Reflection;
using System.IO;
using System.Windows;
using System;
using GAG.Data.Repositories;
using GAG.Models;
using GAG.Models.Lists;

namespace GAG.ViewModels
{
    public class GrafcetMainViewModel : ViewModelBase
    {
        public MainDataGridConfig MainDataGridConfig = new();
        public GrafcetMainViewModel()
        {
            var grafcetRepository = new GrafcetRepository();

            List<Grafcet> items = grafcetRepository.GetAll().ToList();

            Items = new ObservableCollection<Grafcet>(items);

            GrafcetPanelContent = GrafcetPanel = new GrafcetPanelViewModel
            {
                GrafcetSelected = GrafcetSelected
            };

            DocumentService = new DocumentService();

            CreateAndShow = ReactiveCommand.Create(CreateAndShowCommand);

            CreateAndView = ReactiveCommand.Create(CreateAndViewCommand);

            string parentDirName = new FileInfo(AppDomain.CurrentDomain.BaseDirectory)
                                      .Directory.Parent.FullName;

            PdfPath = parentDirName + "\\PDF\\Grafcets.pdf";

            // SelectionModel.Source can be set to Items here, or if it is left null it will be set by
            // the `ListBox` when bound.
            Selection = new SelectionModel<Grafcet>();
            Selection.SelectionChanged += SelectionChanged;

            // Select item 10 in Items.
            Selection.Select(0);

            SetColumnConfigs();
        }
        private void SetColumnConfigs()
        {
  
            MainDataGridConfig = new()
            { 
                ColumnConfigs = {
                    new DataGridColumnConfig { Header = "ID", BindingPath = "Id", ListType = ColumnListType.Text },
                    new DataGridColumnConfig { Header = "Name", BindingPath = "Nom", ListType = ColumnListType.Text },
                    new DataGridColumnConfig { Header = "Active", BindingPath = "Serveur", ListType = ColumnListType.Checkbox }
                }
            };
            
        }

        public ObservableCollection<Grafcet> Items { get; }

        public SelectionModel<Grafcet> Selection { get; }

        // Switch to single selection via the view model.
        public void SwitchToSingleSelect() => Selection.SingleSelect = true;

        void SelectionChanged(object sender, SelectionModelSelectionChangedEventArgs e)
        {
            var selection = (SelectionModel<Grafcet>)sender;

            if (selection != null && selection.SelectedItem != null)
            {
                GrafcetPanel.GrafcetSelected = Items.FirstOrDefault(x => x.Nom == selection.SelectedItem.Nom);
            }
            else
            {
                GrafcetPanel.GrafcetSelected = Items[0];
            }

            GrafcetPanelContent = GrafcetPanel;

        }

        Grafcet _grafcetSelected;
        public Grafcet GrafcetSelected
        {
            get => _grafcetSelected;
            set => this.RaiseAndSetIfChanged(ref _grafcetSelected, value);
        }

        ViewModelBase grafcetPanelContent;

        public ViewModelBase GrafcetPanelContent
        {
            get => grafcetPanelContent;
            private set => this.RaiseAndSetIfChanged(ref grafcetPanelContent, value);

        }

        public GrafcetPanelViewModel GrafcetPanel { get; set; }

        public ReactiveCommand<Unit, Unit> CreateAndShow { get; }

        public ReactiveCommand<Unit, Unit> CreateAndView { get; }

        private DocumentService DocumentService { get; set; }

        private string PdfPath { get; set; }

        /// <summary>
        /// Invoked when the user clicks on the "Cancel" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CreateAndViewCommand()
        {
            DocumentService.CreateGrafcetListReport(PdfPath, Items);

            var window = new ViewerWindow();

            window.PdfPath = PdfPath;

            window.Show();
        }

        void CreateAndShowCommand()
        {
            DocumentService.CreateGrafcetListReport(PdfPath, Items);

            Process.Start(@"cmd.exe", @"/c" + PdfPath);
        }
    }
}