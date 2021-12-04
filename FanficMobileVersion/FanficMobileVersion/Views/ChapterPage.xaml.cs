using FanficMobileVersion.Models;
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
    public partial class ChapterPage : ContentPage
    {
        bool edited = true; // флаг редактирования
        public Chapter _Chapter { get; set; }
        public int fanId;
        public ChapterPage(Chapter chapter, int fanficId)
        {
            InitializeComponent();

            _Chapter = chapter;

            fanId = fanficId;

            if (chapter == null)
            {
                _Chapter = new Chapter();
                edited = false;
            }

            this.BindingContext = _Chapter;
        }

        async void Back(object sender, EventArgs e)
        {
            FanficRepository fr = new FanficRepository();
            Fanfic fanfic = await fr.GetFanfic(fanId);
            //await Shell.Current.GoToAsync($"//{nameof(CategoryDetailPage)}/{nameof(FanficPage)}/"); // Shell.Current.GoToAsync("..");
            await Navigation.PopModalAsync(); // (new FanficPage(fanfic));
        }
    }
}