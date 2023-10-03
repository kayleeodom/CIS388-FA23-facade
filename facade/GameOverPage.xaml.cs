namespace facade;

[QueryProperty("DidWin", "DidWin")]
public partial class GameOverPage : ContentPage
{
	private bool didWin;
	public bool DidWin
	{
		get => didWin;
		set
		{
			didWin = value;
			if(DidWin == true)
			{
				ResultLabel.Text = "YOU WON! :)";
			}
			else
			{
				ResultLabel.Text = "you lost :(";
			}
		}
	}


    public GameOverPage()
	{
		InitializeComponent();

	}

	async void Button_clicked_main(System.Object sender, System.EventArgs e)
	{
		await Shell.Current.GoToAsync($"..");
	}

}
