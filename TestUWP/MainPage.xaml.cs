using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestUWP
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
			var uiSettings = new Windows.UI.ViewManagement.UISettings();
			var rgba = uiSettings.GetColorValue(Windows.UI.ViewManagement.UIColorType.Accent);

		}

		private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
		{
			tb.Text = e.NewValue.ToString();
			icon.Text = e.NewValue >= 50 ? "\xE706" : "\xEC8A";
		}

		private void icon_GettingFocus(UIElement sender, GettingFocusEventArgs args)
		{
		}
	}
}
