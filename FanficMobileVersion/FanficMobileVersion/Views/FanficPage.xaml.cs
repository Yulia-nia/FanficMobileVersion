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
        //public bool _chek { get; set; }
         
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

            GetChekLike();
            GetChekFavorite();
        
            this.BindingContext = _Fanfic;        
        }

        async void SavePhone(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(CategoriesListViewPage)}");            
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


        public async void GetChekLike()
        {
            LikeService ls = new LikeService();
            bool _chek = await ls.CheckLike(_Login.user.id, _Fanfic.id, _Login.accessToken);
            var b = (Button)LikeButton;
            if (_chek == true)
            {
                LikeButton.BackgroundColor = Color.Green;
            }
            else
            {
                b.BackgroundColor = Color.Blue;
            }

        }

        public async void GetChekFavorite()
        {
            FavoriteService ls = new FavoriteService();
            bool _chek = await ls.CheckLike(_Login.user.id, _Fanfic.id, _Login.accessToken);
            var b = (Button)FavoriteButton;
            if (_chek == true)
            {
                b.BackgroundColor = Color.Orange;
            }
            else
            {
                b.BackgroundColor = Color.Blue;
            }

        }

     
        private async void Button_Clicked(object sender, EventArgs e)
        {   
            LikeService ls = new LikeService();
            //LikeService ls = new LikeService();
            var b = (Button)sender;
            bool _chek = await ls.CheckLike(_Login.user.id, _Fanfic.id, _Login.accessToken);
            if (_chek == true)
            {
                await ls.DeleteLike(_Login.user.id, _Fanfic.id, _Login.accessToken);
                FanficRepository fp = new FanficRepository();
                Fanfic fanfic = await fp.GetFanfic(_Fanfic.id);                
                b.BackgroundColor = Color.Blue;
                //LikeButton.TextColor = BackgroundColor;
                this.BindingContext = fanfic;

            }
            else if (_chek == false)
            {
                await ls.AddLike(_Login.user.id, _Fanfic.id, _Login.accessToken);
                FanficRepository fp = new FanficRepository();
                Fanfic fanfic = await fp.GetFanfic(_Fanfic.id);
                b.BackgroundColor = Color.Green;
                this.BindingContext = fanfic;                
                //LikeButton.TextColor = BackgroundColor;
            }            
        }

        private async void FavoriteButton_Clicked(object sender, EventArgs e)
        {
            FavoriteService ls = new FavoriteService();
            //LikeService ls = new LikeService();
            var b = (Button)sender;
            bool _chek = await ls.CheckLike(_Login.user.id, _Fanfic.id, _Login.accessToken);
            if (_chek == true)
            {
                await ls.DeleteLike(_Login.user.id, _Fanfic.id, _Login.accessToken);
                FanficRepository fp = new FanficRepository();
                Fanfic fanfic = await fp.GetFanfic(_Fanfic.id);
                b.BackgroundColor = Color.Blue;
                //LikeButton.TextColor = BackgroundColor;
                this.BindingContext = fanfic;

            }
            else if (_chek == false)
            {
                await ls.AddLike(_Login.user.id, _Fanfic.id, _Login.accessToken);
                FanficRepository fp = new FanficRepository();
                Fanfic fanfic = await fp.GetFanfic(_Fanfic.id);
                b.BackgroundColor = Color.Orange;
                this.BindingContext = fanfic;
                //LikeButton.TextColor = BackgroundColor;
            }
        }


    }
}