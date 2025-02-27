using System.Diagnostics;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
	bool isRandom=false;
	string hexValue = "";

	public MainPage()
	{
		InitializeComponent();
	}

	private void SetColor(Color color)
	{
		Debug.WriteLine(color.ToString());
		Container.BackgroundColor = color;
		ColorBox.BackgroundColor = color;
		hexValue = color.ToHex();
		lblHex.Text = hexValue;
	}

	private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		if(!isRandom){
			// Get the slider value
			var red = RedSlider.Value;
			var green = GreenSlider.Value;
			var blue = BlueSlider.Value;


			// Create a new Color object
				Color color = Color.FromRgb(red, green, blue);

				// Set the color of the boxView
				SetColor(color);
			}
		}
		
	private void btnRandomColor_Clicked(object sender, EventArgs e)
	{
		isRandom = true;
		var random = new Random();
		var color = Color.FromRgb(
			random.Next(0, 256),
			random.Next(0, 256),
			random.Next(0, 256)
		);

		SetColor(color);

		RedSlider.Value = color.Red;
		GreenSlider.Value = color.Green;
		BlueSlider.Value = color.Blue;
		isRandom = false;
	}

	private async void btnCopyHex_Clicked(object sender, EventArgs e)
	{
		await Clipboard.SetTextAsync(hexValue);

		await DisplayAlert("Valor Copiado", "Valor Hexadecimal Copiado al Portapapeles", "OK");
	}
}