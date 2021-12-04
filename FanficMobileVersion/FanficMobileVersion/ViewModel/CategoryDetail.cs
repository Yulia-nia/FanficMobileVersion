using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FanficMobileVersion.Repositories;
using FanficMobileVersion.ViewModels;
using System.Diagnostics;
using FanficMobileVersion.Models;
using System.Linq;
using System.Threading.Tasks;

namespace FanficMobileVersion.ViewModel
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    internal class CategoryDetail : BaseViewModel
    {
        private int itemId;
        private string text;
        private string description;
        public List<Fanfic> fanList { get; set; }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public int Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }





        public List<Fanfic> Fanfics { get; set; }
        public async void GetFriendsF(int id)
        {
            List<Fanfic> Fanfics = new List<Fanfic>();

            CategoryRepository repository = new CategoryRepository();
            IsBusy = true;
            IEnumerable<Fanfic> categories = await repository.GetAllFanficsInCategory(id);

            // очищаем список
            //Friends.Clear();
            while (Fanfics.Any())
                Fanfics.RemoveAt(Fanfics.Count - 1);

            // добавляем загруженные данные
            foreach (Fanfic c in categories)
                Fanfics.Add(c);

            IsBusy = false;
            initialized = true;           
        }




        
        bool initialized = false;       // была ли начальная инициализация
        private bool isBusy;            // идет ли загрузка с сервера

        public async void LoadItemId(int itemId)
        {
            CategoryRepository repository = new CategoryRepository();
            var item = await repository.GetCategorieById(itemId);
                Id = item.id;
                Text = item.name;
                Description = item.description;
                //fanList = await repository.GetAllFanficsInCategory(itemId);
        }

    }
}
