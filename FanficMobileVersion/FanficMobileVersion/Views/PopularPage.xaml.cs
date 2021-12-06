using FanficMobileVersion.Models;
using FanficMobileVersion.Models.Login;
using FanficMobileVersion.Repositories;
using FanficMobileVersion.Services;
using FanficMobileVersion.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FanficMobileVersion.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopularPage : ContentPage
    {
        LoginApiResponseModel _Content { get; set; }
        bool edited = true; // флаг редактирования

        FavoriteViewModel viewModel;
        protected internal ObservableCollection<FavoriteFan> Fan { get; set; }
        public PopularPage(LoginApiResponseModel content)
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
            await viewModel.PopularFanfic();
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
                await Navigation.PushAsync(new FanficPage(cat2, _Content));
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            viewModel = new FavoriteViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;
            await viewModel.PopularFanfic();
            base.OnAppearing();
        }
    }
}