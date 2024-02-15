using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using Windows.UI.Xaml.Controls.Primitives;

namespace DisplayBrightness
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Windows.UI.Xaml.Controls.Slider slider = null;
		private Windows.UI.Xaml.Controls.Grid grid = null;
		private Windows.UI.Xaml.Controls.TextBlock icon = null;
		private Windows.UI.Xaml.Controls.TextBlock value = null;
		private Windows.UI.Xaml.Controls.TextBlock displayName = null;
		NotifyIcon nIcon = new NotifyIcon();

		public MainWindow()
		{
			InitializeComponent();
			MinimizeFootprint();
		}

		//https://stackoverflow.com/questions/223283/net-exe-memory-footprint
		[DllImport("psapi.dll")]
		static extern int EmptyWorkingSet(IntPtr hwProc);

		static void MinimizeFootprint()
		{
			EmptyWorkingSet(Process.GetCurrentProcess().Handle);
		}

		private T GetControl<T>(object sender) where T: Windows.UI.Xaml.FrameworkElement
		{
			WindowsXamlHost windowsXamlHost = (WindowsXamlHost)sender;
			return (T)windowsXamlHost.Child;
		}

		private void grid_ChildChanged(object sender, EventArgs e)
		{
			var uiSettings = new Windows.UI.ViewManagement.UISettings();
			var t1 = uiSettings.GetColorValue(Windows.UI.ViewManagement.UIColorType.AccentLight1);




			grid = GetControl<Windows.UI.Xaml.Controls.Grid>(sender);
			var brush = new Windows.UI.Xaml.Media.AcrylicBrush()
			{
				BackgroundSource = Windows.UI.Xaml.Media.AcrylicBackgroundSource.HostBackdrop,
				TintOpacity = 0.9,
				Opacity = 0.1,
				TintColor = Windows.UI.Colors.Red,
				//FallbackColor = uiSettings.GetColorValue(Windows.UI.ViewManagement.UIColorType.Accent)
				FallbackColor = Windows.UI.Color.FromArgb(255, 31,31,31)
		};
			grid.Background = brush;



			value = new Windows.UI.Xaml.Controls.TextBlock();
			value.Text = "100";
			value.FontSize = 24;
			value.TextAlignment = Windows.UI.Xaml.TextAlignment.Center;
			value.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
			value.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center;
			value.Foreground = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
			value.Width = 50;
			value.Height = 36;
			value.Margin = new Windows.UI.Xaml.Thickness(294, 0, 0, 0);
			grid.Children.Add(value);



			icon = new Windows.UI.Xaml.Controls.TextBlock();
			icon.FontFamily = new Windows.UI.Xaml.Media.FontFamily("Segoe MDL2 Assets");
			icon.Foreground = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
			icon.Text = "\xE706";
			icon.FontSize = 27;
			icon.TextAlignment = Windows.UI.Xaml.TextAlignment.Center;
			icon.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
			icon.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center;
			icon.Width = 27;
			icon.Height = 27;
			icon.Margin = new Windows.UI.Xaml.Thickness(-295, -4, 0, 0);
			grid.Children.Add(icon);


			var slider = new Windows.UI.Xaml.Controls.Slider()
			{
				IsThumbToolTipEnabled = false,
				HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
				VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center,
				Width = 232,
				Height = 36,
				Foreground = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255)),
				Margin = new Windows.UI.Xaml.Thickness(2, 0, 0, 0)
		};
			slider.ValueChanged += (object sender, RangeBaseValueChangedEventArgs e) =>
			{
				value.Text = e.NewValue.ToString();
				icon.Text = e.NewValue >= 50 ? "\xE706" : "\xEC8A";
			};
			grid.Children.Add(slider);
		}

		private void WindowsXamlHost_Loaded(object sender, RoutedEventArgs e)
		{

		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			double dpiFactor = PresentationSource.FromVisual(this).CompositionTarget.TransformToDevice.M11; // если читать в конструкторе - падает
			double pxSize = Math.Round(1 / dpiFactor, 2);
			this.Width = 360 + pxSize;
			this.Height = 100 + pxSize;
			this.BorderThickness = new Thickness(pxSize, pxSize, 0, 0);
			this.BorderBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(127, 127, 127, 127));
			this.Left = SystemParameters.WorkArea.Width - this.Width;
			this.Top = SystemParameters.WorkArea.Height - this.Height - 100;

			this.WindowState = System.Windows.WindowState.Minimized;
			this.nIcon.Icon = new Icon(@"C:\Users\User\Desktop\dp\icon.ico");
			this.nIcon.ShowBalloonTip(5000, "Hi", "This is a BallonTip from Windows Notification", ToolTipIcon.Info);
		}
	}
}
