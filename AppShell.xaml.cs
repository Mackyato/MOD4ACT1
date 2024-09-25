using Module0Exercise0.View;
namespace Module0Exercise0
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(EmployeePage), typeof(EmployeePage));
        }
    }
}
