﻿using FanficMobileVersion.Models;
using FanficMobileVersion.Models.Login;
using FanficMobileVersion.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FanficMobileVersion.ViewModel;
using System.Collections.ObjectModel;

namespace FanficMobileVersion.Views
{
    public partial class AboutPage : ContentPage
    {
        FavoriteViewModel viewModel;

        //ListView categoriesList;
        LoginApiResponseModel _Content { get; set; }
        bool edited = true; // флаг редактирования

        protected internal ObservableCollection<FavoriteFan> Fan { get; set; }



        //public List<FavoriteFan> Fan { get; set; }

        //LoginApiResponseModel Content { get; set; }
        //bool edited = true; // флаг редактирования

        public AboutPage(LoginApiResponseModel content)
        {
            InitializeComponent();

            viewModel = new FavoriteViewModel(content) { Navigation = this.Navigation };
            BindingContext = viewModel;

            _Content = content;

            if (content == null)
            {
                _Content = new LoginApiResponseModel();
                edited = false;
            }


            //Content = content;

            //if (content == null)
            //{
            //    Content = new LoginApiResponseModel();
            //    edited = false;
            //}

            //GetFavorites(content.accessToken, content.user.id);
            //catList.ItemsSource = (List<FavoriteFan>)Fan;
            ////this.BindingContext = this;
            ////this.BindingContext = Fan;
        }


        protected override async void OnAppearing()
        {
            await viewModel.GetFriends(_Content);
            base.OnAppearing();
        }

        //public async void GetFavorites(string s, int id)
        //{
        //    ProfileService p = new ProfileService();
        //    Fan = (List<FavoriteFan>)await p.GetFanList(s, id);
        //    int i = 0;
        //}
    }
    }