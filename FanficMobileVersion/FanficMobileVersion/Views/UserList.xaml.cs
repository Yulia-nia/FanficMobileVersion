using FanficMobileVersion.Models;
using FanficMobileVersion.Models.Login;
using FanficMobileVersion.Services;
using FanficMobileVersion.ViewModel;
using FanficMobileVersion.Views.UserProfile;
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

        private async void catList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            ProfileService cr = new ProfileService();
            // Получаем выбранный элемент 
            User selectedPhone = e.SelectedItem as User;

            User cat2 = await cr.GetUserById(selectedPhone.id);

            if (selectedPhone != null)
            {
                // Снимаем выделение
                //catList.SelectedItem = null;
                await Navigation.PushAsync(new TabbedPageUser(cat2, _Content));
                // Переходим на страницу редактирования элемента                 
            }
        }
    }
}
