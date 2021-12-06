using FanficMobileVersion.Models;
using FanficMobileVersion.Models.Login;
using FanficMobileVersion.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FanficMobileVersion.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserList : ContentPage
    {
        LoginApiResponseModel _Content { get; set; }

        protected internal ObservableCollection<User> Categories { get; set; }
        bool edited = true; // флаг редактирования
        UserVieModel viewModel;
        public UserList(LoginApiResponseModel content)
        {
            InitializeComponent();
            viewModel = new UserVieModel(content) { Navigation = this.Navigation };
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
    }
}
