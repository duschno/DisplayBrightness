using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		NotifyIcon nIcon = new NotifyIcon();
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			double dpiFactor = PresentationSource.FromVisual(this).CompositionTarget.TransformToDevice.M11; // если читать в конструкторе - падает
			double pxSize = Math.Round(1 / dpiFactor, 2);
			this.Width = 360 + pxSize;
			this.Height = 100 + pxSize;
			this.BorderThickness = new Thickness(pxSize, pxSize, 0, 0);
			this.BorderBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(127, 127, 127, 127));
			this.Left = SystemParameters.WorkArea.Width - this.Width;
			this.Top = SystemParameters.WorkArea.Height - this.Height;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = System.Windows.WindowState.Minimized;
			this.nIcon.Icon = new Icon(@"C:\Users\User\Desktop\dp\icon.ico");
			this.nIcon.ShowBalloonTip(5000, "Hi", "This is a BallonTip from Windows Notification", ToolTipIcon.Info);

		}
	}
}