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
    public class UserVieModel
    {
        bool initialized = false;       // была ли начальная инициализация
        private bool isBusy;            // идет ли загрузка с сервера

        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }

        //Category selectedCategorie;   // выбранный друг
        public ObservableCollection<User> Categories { get; set; }

        ProfileService _categoryRepository = new ProfileService();


        //CategoryService _categoriesService; // = new CategoryService(_categoryRepository);


        public ICommand BackCommand { protected set; get; }
        public Command AddItemCommand { get; }


        public Command LoadItemsCommand { get; }   //переход!


        private async void OnAddItem(object obj)
        {
            //await Shell.Current.GoToAsync(nameof(FanficsListViewPage));
        }
        public Command<User> ItemTapped { get; }

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

        public UserVieModel(LoginApiResponseModel content)
        {
            Categories = new ObservableCollection<User>();
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
            IEnumerable<User> categories = await _categoryRepository.GetAllUsers(content.accessToken);

            // очищаем список
            //Friends.Clear();
            while (Categories.Any())
                Categories.RemoveAt(Categories.Count - 1);

            // добавляем загруженные данные
            foreach (User c in categories)
                Categories.Add(c);

            IsBusy = false;
            initialized = true;
        }

        private void Back()
        {
            Navigation.PopAsync();
        }     
    }
}
