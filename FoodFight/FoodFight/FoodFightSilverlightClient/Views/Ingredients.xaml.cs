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
    public partial class Ingredients : Page
    {
        public Ingredients()
        {
            InitializeComponent();
            ingredientDomainDataSource.SubmittedChanges += new EventHandler<SubmittedChangesEventArgs>(ingredientDomainDataSource_SubmittedChanges);
        }

        void ingredientDomainDataSource_SubmittedChanges(object sender, SubmittedChangesEventArgs e)
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
            ingredientDataGrid.Focus();
        }

        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            Web.Ingredient NewIngredient = new Web.Ingredient();
            if (ingredientDomainDataSource.DataView.CanAdd == false)
            {
                ingredientDomainDataSource.Load();
            }
            ingredientDomainDataSource.DataView.Add(NewIngredient);
            ingredientDataGrid.CurrentColumn = ingredientDataGrid.Columns[1];
            ingredientDataGrid.BeginEdit();
            ingredientDataGrid.Focus();
        }

        private void btnSaveIngredient_Click(object sender, RoutedEventArgs e)
        {
            ingredientDomainDataSource.SubmitChanges();
        }

        private void btnDeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            Web.Ingredient SelectedItem = ingredientDomainDataSource.DataView.CurrentItem as Web.Ingredient;
            if (SelectedItem != null)
            {
                IEditableCollectionView IEditableCollectionView = ingredientDomainDataSource.DataView as IEditableCollectionView;
                if (IEditableCollectionView != null && IEditableCollectionView.IsEditingItem)
                {
                    IEditableCollectionView.CancelEdit();
                }
                ingredientDomainDataSource.DataView.Remove(SelectedItem);
                ingredientDomainDataSource.SubmitChanges();
            }
        }

        private void ingredientDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

    }
}
