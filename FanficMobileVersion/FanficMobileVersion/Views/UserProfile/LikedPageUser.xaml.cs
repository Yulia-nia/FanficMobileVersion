using FanficMobileVersion.Models;
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
    public partial class LikedPageUser : ContentPage
    {

        FavoriteViewModel viewModel;
        protected internal ObservableCollection<FavoriteFan> Fan { get; set; }
        User User { get; set; }
        bool edited = true; // флаг редактирования
        public LikedPageUser(User user)
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
            await viewModel.GetUserFav(User.id);
            base.OnAppearing();
        }


    }
}