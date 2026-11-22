using StudentSystem.Mobile.Views;

namespace StudentSystem.Mobile;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(StudentDetailPage), typeof(StudentDetailPage));
	}
}
