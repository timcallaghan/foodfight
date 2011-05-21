using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.ComponentModel;

namespace FoodFightSilverlightClient.Views
{
    public partial class FoodGroups : Page
    {
        public FoodGroups()
        {
            InitializeComponent();
            foodGroupDomainDataSource.SubmittedChanges += new EventHandler<SubmittedChangesEventArgs>(foodGroupDomainDataSource_SubmittedChanges);
        }

        void foodGroupDomainDataSource_SubmittedChanges(object sender, SubmittedChangesEventArgs e)
        {
            if
            (
                e.HasError
                &&
                e.EntitiesInError != null
                &&
                e.EntitiesInError.Where(ENT => ENT.EntityState != System.ServiceModel.DomainServices.Client.EntityState.New).Count() == 0
            )
            {
                e.MarkErrorAsHandled();
            }
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            foodGroupDataGrid.Focus();
        }

        private void btnAddFoodGroup_Click(object sender, RoutedEventArgs e)
        {
            Web.FoodGroup NewFoodGroup = new Web.FoodGroup();
            if (foodGroupDomainDataSource.DataView.CanAdd == false)
            {
                foodGroupDomainDataSource.Load();
            }
            foodGroupDomainDataSource.DataView.Add(NewFoodGroup);
            foodGroupDataGrid.CurrentColumn = foodGroupDataGrid.Columns[1];
            foodGroupDataGrid.BeginEdit();
            foodGroupDataGrid.Focus();
        }

        private void btnSaveFoodGroup_Click(object sender, RoutedEventArgs e)
        {
            foodGroupDomainDataSource.SubmitChanges();
        }

        private void btnDeleteFoodGroup_Click(object sender, RoutedEventArgs e)
        {
            Web.FoodGroup SelectedItem = foodGroupDomainDataSource.DataView.CurrentItem as Web.FoodGroup;
            if (SelectedItem != null)
            {
                IEditableCollectionView IEditableCollectionView = foodGroupDomainDataSource.DataView as IEditableCollectionView;
                if (IEditableCollectionView != null && IEditableCollectionView.IsEditingItem)
                {
                    IEditableCollectionView.CancelEdit();
                }
                foodGroupDomainDataSource.DataView.Remove(SelectedItem);
                foodGroupDomainDataSource.SubmitChanges();
            }
        }

        private void foodGroupDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

    }
}
