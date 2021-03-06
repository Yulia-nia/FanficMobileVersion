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
using FanficMobileVersion.Repositories;
using FanficMobileVersion.Models.Login;

namespace FanficMobileVersion.Views
{

    public partial class CategoriesListViewPage : ContentPage
    {
        //   public List<Category> categories;
        CategoryViewModel viewModel;

        //ListView categoriesList;
        LoginApiResponseModel _Content { get; set; }
        bool edited = true; // флаг редактирования

        protected internal ObservableCollection<Category> Categories { get; set; }

        public CategoriesListViewPage(LoginApiResponseModel content)
        {
            InitializeComponent();

            viewModel = new CategoryViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;
            
            _Content = content;

            if (content == null)
            {
                _Content = new LoginApiResponseModel();
                edited = false;
            }


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


        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            CategoryRepository cr = new CategoryRepository();
            // Получаем выбранный элемент 
            Category selectedPhone = args.SelectedItem as Category;
            Category cat2 = await cr.GetCategorieById(selectedPhone.id);
            
            if (selectedPhone != null)
            {
                // Снимаем выделение
                //catList.SelectedItem = null;
                await Navigation.PushAsync(new CategoryDetailPage(cat2, _Content));
                // Переходим на страницу редактирования элемента                 
            }
            
        }


        protected override async void OnAppearing()
        {
            await viewModel.GetFriends();
            //BindingContext = viewModel;
            base.OnAppearing();
        }
    }
}
