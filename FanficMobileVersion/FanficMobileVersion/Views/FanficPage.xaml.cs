using FanficMobileVersion.Models;
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
        bool edited = true; // флаг редактирования
        public Fanfic _Fanfic { get; set; }
        public FanficPage(Fanfic fanfic)
        {
            InitializeComponent();
            _Fanfic = fanfic;

            if (fanfic == null)
            {
                _Fanfic = new Fanfic();
                edited = false;
            }
            this.BindingContext = _Fanfic;

        }

        async void SavePhone(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
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