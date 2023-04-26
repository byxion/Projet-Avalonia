using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Data;
using Avalonia.Markup.Xaml.Templates;
using GAG.ViewModels;
using System;
using GAG.Models.Lists;
using GAG.Helpers;

namespace GAG.Views.Components.Lists.MainDataGrid
{
    public partial class MainDataGridListView : UserControl
    {
        public MainDataGridListView()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }
        private void OnDataContextChanged(object sender, EventArgs e)
        {
            SetupColumns();
        }

        public static readonly StyledProperty<MainDataGridConfig> MainDataGridConfigProperty =
        AvaloniaProperty.Register<MainDataGridListView, MainDataGridConfig>(nameof(MainDataGridConfig));

        public MainDataGridConfig MainDataGridConfig
        {
            get => GetValue(MainDataGridConfigProperty);
            set => SetValue(MainDataGridConfigProperty, value);
        }

        private void SetupColumns()
        {
            var viewModel = DataContext as GrafcetMainViewModel;
            if (viewModel == null) return;

            MainDataGrid.Columns.Clear();

            // Generate Column Config
            foreach (DataGridColumnConfig columnConfig in viewModel.MainDataGridConfig.ColumnConfigs)
            {
                DataGridColumn column = columnConfig.ListType switch
                {
                    ColumnListType.Checkbox => new DataGridCheckBoxColumn(),
                    _ => new DataGridTextColumn(),
                };
                column.Header = columnConfig.Header;
                if (column is DataGridBoundColumn boundColumn)
                {
                    boundColumn.Binding = new Binding(columnConfig.BindingPath);
                }

                MainDataGrid.Columns.Add(column);
            }

            // Generate General Config 
            if (viewModel.MainDataGridConfig.HasDeleteBtn)
            {
                DataGridTemplateColumn customColumn = new();
               
                customColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                customColumn.HeaderTemplate = new DataTemplate();
                DataTemplate deleteColumnTemplate = (DataTemplate)Resources["DeleteColumnTemplate"];

                if (deleteColumnTemplate != null)
                {
                    customColumn.CellTemplate = deleteColumnTemplate;
                }
                MainDataGrid.Columns.Add(customColumn);
            }
        }

        public void OnDeleteButtonClicked(object? sender, RoutedEventArgs e)
        {
            //var item = (sender as Button)?.DataContext as Item;
            //if (item != null)
            //{
            //    Items.Remove(item);
            //    ItemsCopy.Remove(item);
            //}
            return;
        }
        private void LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.PointerEnter += MouseHover;
            e.Row.PointerLeave += MouseHover;
        }
        private void MouseHover(object sender, PointerEventArgs e)
        {
            if (sender is DataGridRow row)
            {
                // Find the button and set IsVisible to true
                var button = ElementFinder.FindElementInDescendants<Button>(row, "DeleteButton");
                if (button != null)
                {
                    button.IsVisible = !button.IsVisible;
                }
            }
        }

    }
}



