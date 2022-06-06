using DadJokesApp.Models;
using DadJokesApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DadJokesApp.ViewModels
{
    public class JokeHistoryViewModel : ViewModelBase
    {
        private List<DadJoke> _jokes;


        public List<DadJoke> Jokes
        {
            get { return _jokes; }
            set
            {
                _jokes = value;
                OnPropertyChanged();
            }
        }

        public void Refresh()
        {
            var database = DadJokeDatabase.Instance;
            Jokes = database.GetJokes();
        }


    }
}
