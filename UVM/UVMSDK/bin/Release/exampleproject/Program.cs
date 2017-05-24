using System;
using System.Windows.Forms;

public class Program
{
    [STAThread]
    public static void Main()
    {
        MessageBox.Show("Hello world!");
	Program2.Main();
    }
}