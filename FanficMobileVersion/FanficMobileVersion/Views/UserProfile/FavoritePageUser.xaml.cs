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


namespace FanficMobileVersion.Views.UserProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritePageUser : ContentPage
    {
        FavoriteViewModel viewModel;
        protected internal ObservableCollection<FavoriteFan> Fan { get; set; }
        User User { get; set; }
        bool edited = true; // флаг редактирования
        public FavoritePageUser(User user)
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
            //this.BindingContext = User;
        }

        protected override async void OnAppearing()
        {
            await viewModel.FavoriteFanfic(User.id);
            base.OnAppearing();
        }

    }
}