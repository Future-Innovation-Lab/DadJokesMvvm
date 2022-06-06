using DadJokesApp.Models;
using DadJokesApp.Services;
using DadJokesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DadJokesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JokeHistoryView : ContentPage
    {
       
        public JokeHistoryView()
        {
            InitializeComponent();

            BindingContext = new JokeHistoryViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as JokeHistoryViewModel;

            vm.Refresh();
        }
    }
}