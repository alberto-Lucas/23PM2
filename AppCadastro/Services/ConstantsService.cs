using System.Reflection;

namespace AppCadastro.Services
{
    public static class ConstantsService
    {
        public static string GetPathApp()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static string GetNameApp()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }
    }
}
