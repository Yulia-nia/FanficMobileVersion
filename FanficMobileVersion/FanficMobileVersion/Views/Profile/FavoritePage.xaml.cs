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

        private void Button_Clicked(object sender, EventArgs e)
        {
            //GetFavorites(Content.accessToken, Content.user.id);
        }
    }
}