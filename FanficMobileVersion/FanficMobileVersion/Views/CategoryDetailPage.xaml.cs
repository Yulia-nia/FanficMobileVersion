using FanficMobileVersion.Models;
using FanficMobileVersion.Models.Login;
using FanficMobileVersion.Repositories;
using FanficMobileVersion.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FanficMobileVersion.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryDetailPage : ContentPage
    {

        LoginApiResponseModel _Login { get; set; }
        bool edited1 = true; // флаг редактирования

        bool edited = true; // флаг редактирования
        public Category Category { get; set; }
        public CategoryDetailPage(Category category, LoginApiResponseModel login)
        {
            InitializeComponent();

            Category = category;

            if (category == null)
            {
                Category = new Category();
                edited = false;
            }


            _Login = login;

            if (login == null)
            {
                _Login = new LoginApiResponseModel();
                edited1 = false;
            }

            this.BindingContext = Category;
        }


        private async void OnListViewFanficSelected(object sender, SelectedItemChangedEventArgs args)
        {
            FanficRepository fr = new FanficRepository();
            // Получаем выбранный элемент 
            Fanfic selectedPhone = args.SelectedItem as Fanfic;
            Fanfic cat2 = await fr.GetFanfic(selectedPhone.id);
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
