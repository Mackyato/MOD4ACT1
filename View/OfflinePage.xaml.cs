using Module0Exercise0.Services;
namespace Module0Exercise0.View;

public partial class OfflinePage : ContentPage
{
    private readonly IMyService _myService;
    public OfflinePage(IMyService myService)
	{
		InitializeComponent();
        _myService = myService;

        var message = _myService.GetMessage();
        MyLabel.Text = message;
    }

    private void OnExitButtonClicked(object sender, EventArgs e)
    {
        // Exit the application
        System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
    }
}