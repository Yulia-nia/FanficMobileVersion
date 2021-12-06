using FanficMobileVersion.Models;
using FanficMobileVersion.Models.Login;
using FanficMobileVersion.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FanficMobileVersion.ViewModel;
using System.Collections.ObjectModel;
using FanficMobileVersion.Repositories;

namespace FanficMobileVersion.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritePage : ContentPage
    {
        FavoriteViewModel viewModel;

        //ListView categoriesList;
        LoginApiResponseModel _Content { get; set; }
        bool edited = true; // флаг редактирования

        protected internal ObservableCollection<FavoriteFan> Fan { get; set; }

        //public List<FavoriteFan> Fan { get; set; }

        //LoginApiResponseModel Content { get; set; }
        //bool edited = true; // флаг редактирования

        public FavoritePage(LoginApiResponseModel content)
        {
            InitializeComponent();

            viewModel = new FavoriteViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;

            _Content = content;

            if (content == null)
            {
                _Content = new LoginApiResponseModel();
                edited = false;
            }
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetFriends(_Content);
            base.OnAppearing();
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    //GetFavorites(Content.accessToken, Content.user.id);
        //}

        private async void catList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            FanficRepository fr = new FanficRepository();
            // Получаем выбранный элемент 
            FavoriteFan selectedPhone = e.SelectedItem as FavoriteFan;
            Fanfic cat2 = await fr.GetFanfic(selectedPhone.info.id);
            if (selectedPhone != null)
            {
                // Снимаем выделение
                //phonesList.SelectedItem = null;
                // Переходим на страницу редактирования элемента 
                await Navigation.PushAsync(new FanficPage(cat2, _Content));
            }
        }
    }
}