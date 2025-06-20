using System;
using System.IO;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new DataView());
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.ToString());
                MessageBox.Show("Erro ao iniciar o aplicativo. Verifique o log.txt.");
            }
        }
    }
}
