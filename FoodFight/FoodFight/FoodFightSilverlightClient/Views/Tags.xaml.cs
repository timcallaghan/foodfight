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
    public partial class Tags : Page
    {
        public Tags()
        {
            InitializeComponent();
            tagDomainDataSource.SubmittedChanges += new EventHandler<SubmittedChangesEventArgs>(tagDomainDataSource_SubmittedChanges);
        }

        void tagDomainDataSource_SubmittedChanges(object sender, SubmittedChangesEventArgs e)
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
            tagDataGrid.Focus();
        }

        private void btnAddTag_Click(object sender, RoutedEventArgs e)
        {
            Web.Tag NewTag = new Web.Tag();
            if (tagDomainDataSource.DataView.CanAdd == false)
            {
                tagDomainDataSource.Load();
            }
            tagDomainDataSource.DataView.Add(NewTag);
            tagDataGrid.CurrentColumn = tagDataGrid.Columns[1];
            tagDataGrid.BeginEdit();
            tagDataGrid.Focus();
        }

        private void btnSaveTag_Click(object sender, RoutedEventArgs e)
        {
            tagDomainDataSource.SubmitChanges();
        }

        private void btnDeleteTag_Click(object sender, RoutedEventArgs e)
        {
            Web.Tag SelectedItem = tagDomainDataSource.DataView.CurrentItem as Web.Tag;
            if (SelectedItem != null)
            {
                IEditableCollectionView IEditableCollectionView = tagDomainDataSource.DataView as IEditableCollectionView;
                if (IEditableCollectionView != null && IEditableCollectionView.IsEditingItem)
                {
                    IEditableCollectionView.CancelEdit();
                }
                tagDomainDataSource.DataView.Remove(SelectedItem);
                tagDomainDataSource.SubmitChanges();
            }
        }

        private void tagDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

    }
}
