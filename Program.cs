using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using Rheometer_Torque.Machine;
using Rheometer_Torque.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Rheometer_Torque.Model;

namespace Rheometer_Torque
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            User userLogin = new User();            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            if (System.Diagnostics.Process.GetProcessesByName("Rheometer").Length <= 1)
            {                
                if (((new FrmLogin(ref userLogin).ShowDialog()) == DialogResult.OK))
                {
                    FrmWelcome frmWelcome = new FrmWelcome(userLogin);
                    frmWelcome.Show();
                    Application.Run();
                }
            }
            else
            {
                MessageBox.Show("流变仪上位机程序已经运行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }
    }
}
