namespace dotnet_maui_calculator;

public partial class MainPage : ContentPage
{
	int currentState = 1;
	string operationMath;
	double firstNum, secondNum;
	public MainPage()
	{
		InitializeComponent();
		OnClear(this, null);
	}

	void OnClear(object sender, EventArgs e)
	{
		firstNum = 0;
		secondNum = 0;
		currentState = 1;
		result.Text = "0";
	}

	void OnSquareRoot(object sender, EventArgs e)
	{
		if (firstNum == 0)
			return;
		firstNum = firstNum * firstNum;
		result.Text = firstNum.ToString();
	}

	void OnNumberSelection(object sender, EventArgs e)
	{
		var button = (Button)sender;
		var btnPressed = button.Text;

		if (result.Text == "0" || currentState < 0)
		{
			result.Text = string.Empty;
			if (currentState < 0)
				currentState *= -1;
		}

		result.Text = btnPressed;

		double number;
		if (double.TryParse(result.Text, out number))
		{
			result.Text = number.ToString("N0");
			if (currentState == 1)
			{
				firstNum = number;
			}
			else
			{
				secondNum = number;
			}
		}
	}

	void OnOperationSelection(object sender, EventArgs e)
	{
		currentState = -2;
		var button = (Button)sender;
		var btnPressed = button.Text;
		operationMath = btnPressed;
	}

	void OnCalculate(object sender, EventArgs e)
	{
		if (currentState == 2)
		{
			var result = Calculator.Calculate(firstNum, secondNum, operationMath);
			this.result.Text = result.ToString();
			firstNum = result;
			currentState = -1;
		}
	}
}

