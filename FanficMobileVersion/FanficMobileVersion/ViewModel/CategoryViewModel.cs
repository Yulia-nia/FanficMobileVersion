using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;
using FanficMobileVersion.Models;
using FanficMobileVersion.Services;
using FanficMobileVersion.Views;
using FanficMobileVersion.ViewModels;
using System.Runtime.CompilerServices;
using FanficMobileVersion.Repositories;

namespace FanficMobileVersion.ViewModel
{
    public class CategoryViewModel : INotifyPropertyChanged
    {

        bool initialized = false;       // была ли начальная инициализация
        private bool isBusy;            // идет ли загрузка с сервера

        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }





        //Category selectedCategorie;   // выбранный друг
        public ObservableCollection<Category> Categories { get; set; }

        CategoryRepository _categoryRepository= new CategoryRepository();


        CategoryService _categoriesService; // = new CategoryService(_categoryRepository);


        public ICommand BackCommand { protected set; get; }
        public Command AddItemCommand { get; }


        public Command LoadItemsCommand { get; }   //переход!


        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(FanficsListViewPage));
        }
        public Command<Category> ItemTapped { get; }

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

        public CategoryViewModel()
        {
            Categories = new ObservableCollection<Category>();
            IsBusy = false;

            //CreateCategorieCommand = new Command(CreateCategorie);
            //DeleteCategorieCommand = new Command(DeleteCategorie);
            //SaveCategorieCommand = new Command(SaveCategorie);
            ItemTapped = new Command<Category>(OnItemSelected);

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
        public async Task GetFriends()
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<Category> categories = await _categoryRepository.GetAllCategories();

            // очищаем список
            //Friends.Clear();
            while (Categories.Any())
                Categories.RemoveAt(Categories.Count - 1);

            // добавляем загруженные данные
            foreach (Category c in categories)
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
            await Shell.Current.GoToAsync($"{nameof(CategoryDetailPage)}?{nameof(CategoryDetail.ItemId)}={item.id}");
        }
    }
}
