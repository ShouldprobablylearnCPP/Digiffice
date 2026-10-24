using System.Windows.Interop;
using System.Windows.Media;

namespace Digiffice
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;

            Register registerForm = new Register();
            Login loginForm = new Login();

            registerForm.loginForm = loginForm;
            loginForm.registerForm = registerForm;

            var context = new OpenFormsContext(registerForm);

            Application.Run(context);
        }
    }

    public class OpenFormsContext : ApplicationContext
    {
        public OpenFormsContext(Register regForm)
        {
            regForm.Show();
        }
    }
}