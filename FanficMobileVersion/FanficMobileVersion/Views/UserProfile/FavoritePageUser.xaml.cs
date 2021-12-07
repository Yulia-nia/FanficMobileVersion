using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FanficMobileVersion.Models;
using FanficMobileVersion.ViewModel;
using System.Collections.ObjectModel;
using FanficMobileVersion.Models.Login;
using FanficMobileVersion.Repositories;

namespace FanficMobileVersion.Views.UserProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritePageUser : ContentPage
    {
        FavoriteViewModel viewModel;
        protected internal ObservableCollection<FavoriteFan> Fan { get; set; }
        User User { get; set; }
        bool edited = true; // флаг редактирования

        LoginApiResponseModel _Login { get; set; }
        bool edited2 = true; // флаг редактирования
        public FavoritePageUser(User user, LoginApiResponseModel content)
        {
            InitializeComponent();

            viewModel = new FavoriteViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;

            User = user;

            if (user == null)
            {
                User = new User();
                edited = false;
            }

            _Login = content;

            if (content == null)
            {
                _Login = new LoginApiResponseModel();
                edited2 = false;
            }
            //this.BindingContext = User;
        }

        protected override async void OnAppearing()
        {
            await viewModel.FavoriteFanfic(User.id);
            base.OnAppearing();
        }

        private async void OnListViewFanficSelected(object sender, SelectedItemChangedEventArgs args)
        {
            FanficRepository fr = new FanficRepository();
            // Получаем выбранный элемент 
            FavoriteFan selectedPhone = args.SelectedItem as FavoriteFan;
            Fanfic cat2 = await fr.GetFanfic(selectedPhone.info.id);
            if (selectedPhone != null)
            {
                // Снимаем выделение
                //phonesList.SelectedItem = null;
                // Переходим на страницу редактирования элемента 
                await Navigation.PushAsync(new FanficPage(cat2, _Login));
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            viewModel = new FavoriteViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;
            await viewModel.FavoriteFanfic(User.id);
            base.OnAppearing();
        }

    }
}