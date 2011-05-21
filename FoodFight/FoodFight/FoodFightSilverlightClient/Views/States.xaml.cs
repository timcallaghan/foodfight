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
    public partial class States : Page
    {
        public States()
        {
            InitializeComponent();
            stateDomainDataSource.SubmittedChanges += new EventHandler<SubmittedChangesEventArgs>(stateDomainDataSource_SubmittedChanges);
        }

        void stateDomainDataSource_SubmittedChanges(object sender, SubmittedChangesEventArgs e)
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
            stateDataGrid.Focus();
        }

        private void btnAddState_Click(object sender, RoutedEventArgs e)
        {
            Web.State NewState = new Web.State();
            if (stateDomainDataSource.DataView.CanAdd == false)
            {
                stateDomainDataSource.Load();
            }
            stateDomainDataSource.DataView.Add(NewState);
            stateDataGrid.CurrentColumn = stateDataGrid.Columns[1];
            stateDataGrid.BeginEdit();
            stateDataGrid.Focus();
        }

        private void btnSaveState_Click(object sender, RoutedEventArgs e)
        {
            stateDomainDataSource.SubmitChanges();
        }

        private void btnDeleteState_Click(object sender, RoutedEventArgs e)
        {
            Web.State SelectedItem = stateDomainDataSource.DataView.CurrentItem as Web.State;
            if (SelectedItem != null)
            {
                IEditableCollectionView IEditableCollectionView = stateDomainDataSource.DataView as IEditableCollectionView;
                if (IEditableCollectionView != null && IEditableCollectionView.IsEditingItem)
                {
                    IEditableCollectionView.CancelEdit();
                }
                stateDomainDataSource.DataView.Remove(SelectedItem);
                stateDomainDataSource.SubmitChanges();
            }
        }

        private void stateDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

    }
}
