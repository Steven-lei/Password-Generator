namespace Password_Generator
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
            // see https://aka.ms/applicationconfigurati^on.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormGenerator());
        }
    }
}