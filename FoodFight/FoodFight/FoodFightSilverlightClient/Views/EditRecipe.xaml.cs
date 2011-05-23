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
using System.ServiceModel.DomainServices.Client;

namespace FoodFightSilverlightClient.Views
{
    public partial class EditRecipe : Page
    {
        public Web.FoodFightDomainContext Context 
        { 
            get
            {
                return context;
            }
        }

        private Web.FoodFightDomainContext context;
        public EditRecipe()
        {
            InitializeComponent();
            context = recipeDomainDataSource.DomainContext as Web.FoodFightDomainContext;
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
                // This is because we have unattached new items in the collection that we are deleting
                // before we have added them.  So ignore for now.
                e.MarkErrorAsHandled();
            }
            else if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Save Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("RecipeID"))
            {
                int RecipeID = Int32.Parse(NavigationContext.QueryString["RecipeID"]);
                recipeDomainDataSource.QueryParameters.Add(new Parameter() { ParameterName = "RecipeID", Value = RecipeID });
                recipeDomainDataSource.Load();
            }
        }

        private void recipeDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void btnSaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            recipeDomainDataSource.SubmitChanges();
        }

        private void btnUndoChanges_Click(object sender, RoutedEventArgs e)
        {
            recipeDomainDataSource.RejectChanges();
        }

        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {
            Web.RecipeStep NewRecipeStep = new Web.RecipeStep();
            Web.Recipe Recipe = recipeDomainDataSource.DataView.CurrentItem as Web.Recipe;
            NewRecipeStep.StepNumber = 1;
            if (Recipe.RecipeSteps.Count > 0)
            {
                NewRecipeStep.StepNumber = Recipe.RecipeSteps.Max(RS => RS.StepNumber) + 1;
            }
            Recipe.RecipeSteps.Add(NewRecipeStep);
        }

        private void btnDeleteStep_Click(object sender, RoutedEventArgs e)
        {
            Web.RecipeStep SelectedItem = recipeStepsDataGrid.SelectedItem as Web.RecipeStep;
            if (SelectedItem != null)
            {
                IEditableCollectionView IEditableCollectionView = recipeDomainDataSource.DataView as IEditableCollectionView;
                if (IEditableCollectionView != null && IEditableCollectionView.IsEditingItem)
                {
                    IEditableCollectionView.CancelEdit();
                }

                context.RecipeSteps.Remove(SelectedItem);
            }
        }

        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            Web.RecipeIngredient NewReipeIngredient = new Web.RecipeIngredient();
            Web.Recipe Recipe = recipeDomainDataSource.DataView.CurrentItem as Web.Recipe;
            Recipe.RecipeIngredients.Add(NewReipeIngredient);
        }

        private void btnDeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            Web.RecipeIngredient SelectedItem = recipeIngredientsDataGrid.SelectedItem as Web.RecipeIngredient;
            if (SelectedItem != null)
            {
                IEditableCollectionView IEditableCollectionView = recipeDomainDataSource.DataView as IEditableCollectionView;
                if (IEditableCollectionView != null && IEditableCollectionView.IsEditingItem)
                {
                    IEditableCollectionView.CancelEdit();
                }

                context.RecipeIngredients.Remove(SelectedItem);
            }
        }

        private void btnAddFoodGroup_Click(object sender, RoutedEventArgs e)
        {
            Web.RecipeFoodGroup NewRecipeFoodGroup = new Web.RecipeFoodGroup();
            Web.Recipe Recipe = recipeDomainDataSource.DataView.CurrentItem as Web.Recipe;
            Recipe.RecipeFoodGroups.Add(NewRecipeFoodGroup);
        }

        private void btnDeleteFoodGroup_Click(object sender, RoutedEventArgs e)
        {
            Web.RecipeFoodGroup SelectedItem = recipeFoodGroupsDataGrid.SelectedItem as Web.RecipeFoodGroup;
            if (SelectedItem != null)
            {
                IEditableCollectionView IEditableCollectionView = recipeDomainDataSource.DataView as IEditableCollectionView;
                if (IEditableCollectionView != null && IEditableCollectionView.IsEditingItem)
                {
                    IEditableCollectionView.CancelEdit();
                }

                context.RecipeFoodGroups.Remove(SelectedItem);
            }
        }

        private void btnAddTag_Click(object sender, RoutedEventArgs e)
        {
            Web.RecipeTag NewRecipeTag = new Web.RecipeTag();
            Web.Recipe Recipe = recipeDomainDataSource.DataView.CurrentItem as Web.Recipe;
            Recipe.RecipeTags.Add(NewRecipeTag);
        }

        private void btnDeleteTag_Click(object sender, RoutedEventArgs e)
        {
            Web.RecipeTag SelectedItem = recipeTagsDataGrid.SelectedItem as Web.RecipeTag;
            if (SelectedItem != null)
            {
                IEditableCollectionView IEditableCollectionView = recipeDomainDataSource.DataView as IEditableCollectionView;
                if (IEditableCollectionView != null && IEditableCollectionView.IsEditingItem)
                {
                    IEditableCollectionView.CancelEdit();
                }

                context.RecipeTags.Remove(SelectedItem);
            }
        }

        private void btnAddEquipmentTag_Click(object sender, RoutedEventArgs e)
        {
            Web.RecipeEquipmentTag NewRecipeEquipmentTag = new Web.RecipeEquipmentTag();
            Web.Recipe Recipe = recipeDomainDataSource.DataView.CurrentItem as Web.Recipe;
            Recipe.RecipeEquipmentTags.Add(NewRecipeEquipmentTag);
        }

        private void btnDeleteEquipmentTag_Click(object sender, RoutedEventArgs e)
        {
            Web.RecipeEquipmentTag SelectedItem = recipeEquipmentTagsDataGrid.SelectedItem as Web.RecipeEquipmentTag;
            if (SelectedItem != null)
            {
                IEditableCollectionView IEditableCollectionView = recipeDomainDataSource.DataView as IEditableCollectionView;
                if (IEditableCollectionView != null && IEditableCollectionView.IsEditingItem)
                {
                    IEditableCollectionView.CancelEdit();
                }

                context.RecipeEquipmentTags.Remove(SelectedItem);
            }
        }
    }
}
