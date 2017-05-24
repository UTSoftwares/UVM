using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace UVM
{
    class Program
    {

        protected static byte[] Decode(byte[] values, string key)
        {
            byte ks = 0;
            for (int i = 0; i < key.Length; i++)
            {
                ks += (byte)key[i];
            }
            byte[] encv = new byte[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                encv[i] = (byte)((int)values[i] - (int)ks);
            }
            return encv;
        }

        static void WriteHelp()
        {
            MessageBox.Show("Usage: uvm [input path] [program key]\nor\nuvm [input path]\nor just add an association of the \"uapp\" format to the UVM program","Help");
        }

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args.Length == 2)
                {
                    if (File.Exists(Path.GetFullPath(args[0])))
                    {
                        try
                        {
                            byte[] decodedData = Decode(File.ReadAllBytes(Path.GetFullPath(args[0])), args[1]);
                            File.WriteAllBytes(Path.GetFullPath("./c.dll"), decodedData);
                            Assembly assembly = Assembly.LoadFile(Path.GetFullPath("./c.dll"));
                            assembly.GetType("Program").GetMethod("Main").Invoke(null, null);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("The password is wrong or file is corrupted", "Failed to run the app");
                        }
                    }
                }
                else if (args.Length == 1)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    PasswordDialog pdlg = new PasswordDialog();
                    if (pdlg.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            byte[] decodedData = Decode(File.ReadAllBytes(Path.GetFullPath(args[0])), pdlg.Password);
                            File.WriteAllBytes(Path.GetFullPath("./c.dll"), decodedData);
                            Assembly assembly = Assembly.LoadFile(Path.GetFullPath("./c.dll"));
                            assembly.GetType("Program").GetMethod("Main").Invoke(null, null);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("The password is wrong or file is corrupted","Failed to run the app");
                        }
                    }
                }
            }
            else
            {
                WriteHelp();
            }
        }
    }
}