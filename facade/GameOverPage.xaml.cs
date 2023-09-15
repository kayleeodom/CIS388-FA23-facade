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
			if(didWin)
			{
				ResultLabel.Text = "You Won!";
			}
			else
			{
				ResultLabel.Text = "You Lost!";
			}
		}
	}

	public GameOverPage()
	{
		InitializeComponent();
	}
}
