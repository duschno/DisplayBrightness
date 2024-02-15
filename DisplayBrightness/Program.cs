namespace DisplayBrightness
{
	public class Program
	{
		[System.STAThreadAttribute()]
		public static void Main()
		{
			using (new DisplayBrightnessUWP.App())
			{
				var app = new DisplayBrightness.App();
				app.InitializeComponent();
				app.Run();
			}
		}
	}
}