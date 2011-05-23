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
    public partial class Recipes : Page
    {
        public Recipes()
        {
            InitializeComponent();
            recipeDomainDataSource.SubmittedChanges += new EventHandler<SubmittedChangesEventArgs>(recipeDomainDataSource_SubmittedChanges);
        }

        void recipeDomainDataSource_SubmittedChanges(object sender, SubmittedChangesEventArgs e)
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
            recipeDataGrid.Focus();
        }

        private void recipeDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            Web.Recipe NewRecipe = new Web.Recipe();
            
            if (recipeDomainDataSource.DataView.CanAdd == false)
            {
                recipeDomainDataSource.Load();
            }
            recipeDomainDataSource.DataView.Add(NewRecipe);
            recipeDataGrid.CurrentColumn = recipeDataGrid.Columns[1];
            recipeDataGrid.BeginEdit();
            recipeDataGrid.Focus();
        }

        private void btnSaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            recipeDomainDataSource.SubmitChanges();
        }

        private void btnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            Web.Recipe SelectedItem = recipeDomainDataSource.DataView.CurrentItem as Web.Recipe;
            if (SelectedItem != null)
            {
                IEditableCollectionView IEditableCollectionView = recipeDomainDataSource.DataView as IEditableCollectionView;
                if (IEditableCollectionView != null && IEditableCollectionView.IsEditingItem)
                {
                    IEditableCollectionView.CancelEdit();
                }
                recipeDomainDataSource.DataView.Remove(SelectedItem);
                recipeDomainDataSource.SubmitChanges();
            }
        }

        private void btnEditRecipe_Click(object sender, RoutedEventArgs e)
        {
            Web.Recipe SelectedItem = recipeDomainDataSource.DataView.CurrentItem as Web.Recipe;
            if (SelectedItem != null && SelectedItem.RecipeID > 0)
            {
                string urlWithQueryString = String.Format(@"/EditRecipe?RecipeID={0}", SelectedItem.RecipeID);
                NavigationService.Navigate(new Uri(urlWithQueryString, UriKind.Relative));
            }
            else
            {
                System.Windows.MessageBox.Show("Please save this new recipe before trying to edit it.", "Error", System.Windows.MessageBoxButton.OK);
            }
        }

    }
}
