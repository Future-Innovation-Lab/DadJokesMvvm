using DadJokesApp.Models.Service;
using DadJokesApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DadJokesApp.ViewModels
{
    public class JokeViewModel : ViewModelBase
    {

        private DadJoke _joke;

        public DadJoke Joke
        {
            get { return _joke; }
            set
            {
                _joke = value;
                OnPropertyChanged();
            }
        }

        private ICommand _newJokeCommand;
        public ICommand NewJokeCommand =>
            _newJokeCommand ?? (_newJokeCommand = new Command(PersistedJokeCommand));


        public async void PersistedJokeCommand()
        {
            await GetPersistedJoke();
        }

        public async Task GetPersistedJoke()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.None)
            {
                var remoteServer = new DadJokeService();

                var joke = await remoteServer.GetRemoteJoke();

                Joke = joke;

                Models.DadJoke dbJoke = new Models.DadJoke();
                dbJoke.JokeDate = DateTime.Now;
                dbJoke.Joke = joke.joke;

                var database = DadJokeDatabase.Instance;

                database.SaveDadJoke(dbJoke);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Internet", "Connectivity not available.", "Ok");
            }
        }
    }
}
