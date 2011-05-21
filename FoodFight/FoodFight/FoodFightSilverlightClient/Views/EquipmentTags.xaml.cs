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
    public partial class EquipmentTags : Page
    {
        public EquipmentTags()
        {
            InitializeComponent();
            equipmentTagDomainDataSource.SubmittedChanges += new EventHandler<SubmittedChangesEventArgs>(equipmentTagDomainDataSource_SubmittedChanges);
        }

        void equipmentTagDomainDataSource_SubmittedChanges(object sender, SubmittedChangesEventArgs e)
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
            equipmentTagDataGrid.Focus();
        }

        private void btnAddEquipmentTag_Click(object sender, RoutedEventArgs e)
        {
            Web.EquipmentTag NewEquipmentTag = new Web.EquipmentTag();
            if (equipmentTagDomainDataSource.DataView.CanAdd == false)
            {
                equipmentTagDomainDataSource.Load();
            }
            equipmentTagDomainDataSource.DataView.Add(NewEquipmentTag);
            equipmentTagDataGrid.CurrentColumn = equipmentTagDataGrid.Columns[1];
            equipmentTagDataGrid.BeginEdit();
            equipmentTagDataGrid.Focus();
        }

        private void btnSaveEquipmentTag_Click(object sender, RoutedEventArgs e)
        {
            equipmentTagDomainDataSource.SubmitChanges();
        }

        private void btnDeleteEquipmentTag_Click(object sender, RoutedEventArgs e)
        {
            Web.EquipmentTag SelectedItem = equipmentTagDomainDataSource.DataView.CurrentItem as Web.EquipmentTag;
            if (SelectedItem != null)
            {
                IEditableCollectionView IEditableCollectionView = equipmentTagDomainDataSource.DataView as IEditableCollectionView;
                if (IEditableCollectionView != null && IEditableCollectionView.IsEditingItem)
                {
                    IEditableCollectionView.CancelEdit();
                }
                equipmentTagDomainDataSource.DataView.Remove(SelectedItem);
                equipmentTagDomainDataSource.SubmitChanges();
            }
        }

        private void equipmentTagDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

    }
}
