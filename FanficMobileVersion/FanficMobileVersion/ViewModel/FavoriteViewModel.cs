using FanficMobileVersion.Models;
using FanficMobileVersion.Models.Login;
using FanficMobileVersion.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FanficMobileVersion.ViewModel
{
    public  class FavoriteViewModel
    {
        bool initialized = false;       // была ли начальная инициализация
        private bool isBusy;            // идет ли загрузка с сервера

        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }

        //Category selectedCategorie;   // выбранный друг
        public ObservableCollection<FavoriteFan> Categories { get; set; }

        ProfileService _categoryRepository = new ProfileService();


        //CategoryService _categoriesService; // = new CategoryService(_categoryRepository);


        public ICommand BackCommand { protected set; get; }
        public Command AddItemCommand { get; }


        public Command LoadItemsCommand { get; }   //переход!


        private async void OnAddItem(object obj)
        {
            //await Shell.Current.GoToAsync(nameof(FanficsListViewPage));
        }
        public Command<FavoriteFan> ItemTapped { get; }

        /*
         * public ICommand CreateCategorieCommand { protected set; get; }
        public ICommand DeleteCategorieCommand { protected set; get; }
        public ICommand SaveCategorieCommand { protected set; get; }
        */

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("IsLoaded");
            }
        }
        public bool IsLoaded
        {
            get { return !isBusy; }
        }

        public FavoriteViewModel()
        {
            Categories = new ObservableCollection<FavoriteFan>();
            IsBusy = false;

            //CreateCategorieCommand = new Command(CreateCategorie);
            //DeleteCategorieCommand = new Command(DeleteCategorie);
            //SaveCategorieCommand = new Command(SaveCategorie);
            //ItemTapped = new Command<FavoriteFan>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            BackCommand = new Command(Back);
        }



        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        /// <summary>
        /// Get from server all categories
        /// </summary>
        public async Task GetFriends(LoginApiResponseModel content)
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<FavoriteFan> categories = await _categoryRepository.GetFanList(content.accessToken, content.user.id);

            // очищаем список
            //Friends.Clear();
            while (Categories.Any())
                Categories.RemoveAt(Categories.Count - 1);

            // добавляем загруженные данные
            foreach (FavoriteFan c in categories)
                Categories.Add(c);

            IsBusy = false;
            initialized = true;
        }



        public async Task GetUserFav(int id)
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<FavoriteFan> categories = await _categoryRepository.GetFanListUser(id);

            // очищаем список
            //Friends.Clear();
            while (Categories.Any())
                Categories.RemoveAt(Categories.Count - 1);

            // добавляем загруженные данные
            foreach (FavoriteFan c in categories)
                Categories.Add(c);

            IsBusy = false;
            initialized = true;
        }


        // избранное
        public async Task FavoriteFanfic(int id)
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<FavoriteFan> categories = await _categoryRepository.FavoriteFanficUser(id);

            // очищаем список
            //Friends.Clear();
            while (Categories.Any())
                Categories.RemoveAt(Categories.Count - 1);

            // добавляем загруженные данные
            foreach (FavoriteFan c in categories)
                Categories.Add(c);

            IsBusy = false;
            initialized = true;
        }



        private void Back()
        {
            Navigation.PopAsync();
        }



        async void OnItemSelected(Category item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(CategoryDetailPage)}?{nameof(CategoryDetail.ItemId)}={item.id}");
        }




    }
}
