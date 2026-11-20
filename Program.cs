namespace EdenDelivery
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmLogin()); // o sistema começa pelo login
        }
    }
}
