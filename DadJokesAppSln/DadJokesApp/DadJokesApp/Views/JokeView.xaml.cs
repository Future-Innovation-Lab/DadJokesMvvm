using DadJokesApp.Models.Service;
using DadJokesApp.Services;
using DadJokesApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DadJokesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JokeView : ContentPage
    {
        public JokeView()
        {
            InitializeComponent();

            BindingContext = new JokeViewModel();

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as JokeViewModel;

            vm.NewJokeCommand.Execute(null);

        }
    }
}