using FanficMobileVersion.Models;
using FanficMobileVersion.Models.Login;
using FanficMobileVersion.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FanficMobileVersion.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FanficPage : ContentPage
    {

        //Label nameauther;
        public List<string> Tags;

        LoginApiResponseModel _Login { get; set; }
        bool edited1 = true; // флаг редактирования


        bool edited = true; // флаг редактирования
        public Fanfic _Fanfic { get; set; }
        public FanficPage(Fanfic fanfic, LoginApiResponseModel login)
        {
            InitializeComponent();
            _Fanfic = fanfic;

            if (fanfic == null)
            {
                _Fanfic = new Fanfic();
                edited = false;
            }

            _Login = login;

            if (login == null)
            {
                _Login = new LoginApiResponseModel();
                edited1 = false;
            }


            this.BindingContext = _Fanfic;

        }

        async void SavePhone(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(CategoriesListViewPage)}");
            //await Navigation.PushAsync(new LoginPage());
        }

        async void GoToComment(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync($"//{nameof(CommentPage)}", _Login);
            //await Navigation.PushAsync(new LoginPage());


            FanficRepository fr = new FanficRepository();
            Fanfic fanfic = await fr.GetFanfic(_Fanfic.id);
            await Navigation.PushModalAsync(new CommentPage(_Login, fanfic));
        }

        private async void tagssList_ItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            Tag selectedPhone = e.Item as Tag;

            await DisplayAlert($"{selectedPhone.name}", $"{selectedPhone.description}", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async void categoriesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            FanficRepository fr = new FanficRepository();
            // Получаем выбранный элемент 
            Chapter selectedPhone = e.SelectedItem as Chapter;

            Chapter cat2 = await fr.GetChapter(selectedPhone.id);
            if (selectedPhone != null)
            {
                // Снимаем выделение
                //phonesList.SelectedItem = null;
                // Переходим на страницу редактирования элемента 
                await Navigation.PushModalAsync(new ChapterPage(cat2, _Fanfic.id));
            }

        }


        //private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        //{
        //    CategoryRepository cr = new CategoryRepository();
        //    // Получаем выбранный элемент 
        //    Category selectedPhone = args.SelectedItem as Category;
        //    Category cat2 = await cr.GetCategorieById(selectedPhone.id);
        //    if (selectedPhone != null)
        //    {
        //        // Снимаем выделение
        //        //phonesList.SelectedItem = null;
        //        // Переходим на страницу редактирования элемента 
        //        await Navigation.PushAsync(new CategoryDetailPage(cat2));
        //    }
        //}


    }
}