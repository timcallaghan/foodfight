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
    public partial class Units : Page
    {
        public Units()
        {
            InitializeComponent();
            unitDomainDataSource.SubmittedChanges += new EventHandler<SubmittedChangesEventArgs>(unitDomainDataSource_SubmittedChanges);
        }

        void unitDomainDataSource_SubmittedChanges(object sender, SubmittedChangesEventArgs e)
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
            unitDataGrid.Focus();
        }

        private void unitDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void btnAddUnit_Click(object sender, RoutedEventArgs e)
        {
            Web.Unit NewUnit = new Web.Unit();
            if (unitDomainDataSource.DataView.CanAdd == false)
            {
                unitDomainDataSource.Load();
            }
            unitDomainDataSource.DataView.Add(NewUnit);
            unitDataGrid.CurrentColumn = unitDataGrid.Columns[1];
            unitDataGrid.BeginEdit();
            unitDataGrid.Focus();
        }

        private void btnSaveUnit_Click(object sender, RoutedEventArgs e)
        {
            unitDomainDataSource.SubmitChanges();
        }

        private void btnDeleteUnit_Click(object sender, RoutedEventArgs e)
        {
            Web.Unit SelectedItem = unitDomainDataSource.DataView.CurrentItem as Web.Unit;
            if (SelectedItem != null)
            {
                IEditableCollectionView IEditableCollectionView  = unitDomainDataSource.DataView as IEditableCollectionView;
                if (IEditableCollectionView != null && IEditableCollectionView.IsEditingItem)
                {
                    IEditableCollectionView.CancelEdit();
                }
                unitDomainDataSource.DataView.Remove(SelectedItem);
                unitDomainDataSource.SubmitChanges();
            }
        }
    }
}
