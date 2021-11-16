using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FanficMobileVersion.Models;
using FanficMobileVersion.Services;
using System.Collections.Generic;
using FanficMobileVersion.ViewModel;

namespace FanficMobileVersion.Views
{

    public partial class CategoriesListViewPage : ContentPage
    {
        //   public List<Category> categories;
        CategoryViewModel viewModel;

        public CategoriesListViewPage()
        {
            InitializeComponent();

            viewModel = new CategoryViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;
            //List<Category> categories = _category.AllCategories();

            //MyListView.ItemsSource = categories;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetFriends();
            base.OnAppearing();
        }
    }
}
