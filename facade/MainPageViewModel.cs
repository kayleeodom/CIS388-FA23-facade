using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace facade
{
	public partial class MainPageViewModel: ObservableObject 
	{
		[ObservableProperty]
		private string secretColor;

		[ObservableProperty]
		private string currentGuess;

		public ObservableCollection<ColorGuess> Guesses { get; set; }
        public bool DidWin { get; set; }

        public MainPageViewModel()
		{
			secretColor = "FACADE";
			currentGuess = "";

			Guesses = new ObservableCollection<ColorGuess>();

			//Guesses.Add( new ColorGuess("#beaded")  );
            //Guesses.Add( new ColorGuess("#efaced") );

        }


		[RelayCommand]
		void AddLetter(string letter)
		{
			if( CurrentGuess.Length < 6)
			{
				CurrentGuess = CurrentGuess += letter;
			}
		}

        [RelayCommand]
        async Task Guess()
        {
			// if correct, then go to game over (DidWin=true)
			if (CurrentGuess == SecretColor)
			{
				// go to GameOverPage (win)
				//await Shell.Current.GoToAsync((nameof(GameOverPage)));
				await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={true}");

            }

			// else if this is the 6th guess (and it's wrong)
			else
			{

				if(Guesses.Count >= 5 && CurrentGuess != SecretColor)
				{
                    // then go to game over (DidWin=false)
                    await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={false}");
                }

				// Add this guess to the Guesses (not right)
				Guesses.Add(new ColorGuess(CurrentGuess));
				// make type in area blank again
				CurrentGuess = "";
            }
			

        }

        [RelayCommand]
        void Delete()
        {
			// Remove letter from the end of the current guess
            if (CurrentGuess.Length != 0)
            {
                CurrentGuess = CurrentGuess.Substring(0, CurrentGuess.Length - 1);
            }

        }


    }
}

