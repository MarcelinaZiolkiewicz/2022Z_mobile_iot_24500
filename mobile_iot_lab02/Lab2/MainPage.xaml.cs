namespace Lab2;

public partial class MainPage : ContentPage
{
	string translateNumber;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnTranslate(object sender, EventArgs e)
	{
		string enteredNumber = PhonenumberText.Text;
		translateNumber = Lab2.PhonewordTranslator.ToNumber(enteredNumber);

		if (!string.IsNullOrEmpty(translateNumber))
		{
			CallButton.IsEnabled = true;
			CallButton.Text = "Call " + translateNumber;
		} else
		{
			CallButton.IsEnabled = false;
			CallButton.Text = "Call";
		}
	}

	async void OnCall(object sender, System.EventArgs e)
	{
		if(await this.DisplayAlert(
			"Dial a Number", "Would you like to call " + translateNumber + "?", "Yes", "No"))
		{
			try
			{
				if (PhoneDialer.Default.IsSupported) PhoneDialer.Default.Open(translateNumber);
			}
			catch (ArgumentNullException)
			{
				await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
			}
			catch (Exception)
			{
				await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
			}
		}
	}

}

