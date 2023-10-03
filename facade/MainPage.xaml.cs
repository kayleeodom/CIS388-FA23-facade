using System;

namespace facade;

public partial class MainPage : ContentPage
{
	//int count = 0;

	// this is where the hard code of true or false used to be
	public bool DidWin { get; set; }
	public MainPage()
	{
		InitializeComponent();

		BindingContext = new MainPageViewModel();

	}

    async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={DidWin}");
    }
}


