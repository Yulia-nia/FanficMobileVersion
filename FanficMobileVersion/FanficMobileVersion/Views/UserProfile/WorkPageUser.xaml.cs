using FanficMobileVersion.Models;
using FanficMobileVersion.Models.Login;
using FanficMobileVersion.Repositories;
using FanficMobileVersion.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FanficMobileVersion.Views.UserProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkPageUser : ContentPage
    {
        FanficViewModel viewModel;
        protected internal ObservableCollection<FavoriteFan> Fan { get; set; }
        User User { get; set; }
        bool edited = true; // флаг редактирования

        LoginApiResponseModel _Login { get; set; }
        bool edited2 = true; // флаг редактирования
        public WorkPageUser(User user, LoginApiResponseModel content)
        {
            InitializeComponent();
            viewModel = new FanficViewModel() { Navigation = this.Navigation };
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
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetUserWork(User.id);
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

    }
}