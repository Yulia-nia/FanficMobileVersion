using FanficMobileVersion.Models;
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


        bool edited = true; // флаг редактирования
        public Category Category { get; set; }
        public CategoryDetailPage(Category category)
        {
            InitializeComponent();

            Category = category;

            if (category == null)
            {
                Category = new Category();
                edited = false;
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
                await Navigation.PushAsync(new FanficPage(cat2));
            }
        }


    }

    //public List<Fanfic> Items { get; set; }
    //CategoryDetail categoryDetail;


    //public CategoryDetailPage(int id)
    //{
    //    InitializeComponent();
    //    //categoryDetail = Id;
    //    BindingContext = new CategoryDetail();
    //    categoryDetail.GetFriendsF(categoryDetail.Id);

    //    Items = categoryDetail.Fanfics;

    //    MyListView.ItemsSource = Items;
    //}

    //async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
    //{
    //    if (e.Item == null)
    //        return;

    //    await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

    //    //Deselect Item
    //    ((ListView)sender).SelectedItem = null;
    //}

    //protected override async void OnAppearing()
    //{
    //    categoryDetail.GetFriendsF(categoryDetail.Id);
    //    base.OnAppearing();
    //}
    //}
}
