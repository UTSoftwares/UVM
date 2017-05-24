using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;

namespace UVMSDK
{
    class Program
    {

        protected static string ReverseDirectoryChar(string instr)
        {
            return instr.Replace("/", "\\");
        }

        protected static byte[] Encode(byte[] values, string key)
        {
            byte ks = 0;
            for (int i = 0; i < key.Length; i++)
            {
                ks += (byte)key[i];
            }
            byte[] encv = new byte[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                encv[i] = (byte)((int)values[i] + (int)ks);
            }
            return encv;
        }

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
            Console.WriteLine("Usage: uvmsdk [project file] [password] [output path]");
        }

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (File.Exists(Path.GetFullPath(args[0])))
                {
                    try
                    {
                        IniFile ini = new IniFile(Path.GetFullPath(args[0]));
                        string[] files = ini.ReadINI("Files", "CodeFiles").Split("|"[0]);

                        for (int i = 0; i < files.Length; i++)
                        {
                            files[i] = files[i].Replace("./", ReverseDirectoryChar(Path.GetDirectoryName(args[0])) + "\\");
                        }


                        Dictionary<string, string> providerOptions = new Dictionary<string, string>
                        {
                            {"CompilerVersion", "v4.0"}
                        };
                        CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);

                        string outputAssembly = Path.GetFullPath(".\\c.dll");

                        CompilerParameters compilerParams = new CompilerParameters { OutputAssembly = outputAssembly, GenerateExecutable = false };
                        compilerParams.ReferencedAssemblies.Add("System.Core.Dll");
                        compilerParams.ReferencedAssemblies.Add("System.Windows.Forms.Dll");

                        CompilerResults results = provider.CompileAssemblyFromFile(compilerParams, files);


                        Console.WriteLine("Number of errors when compile: {0}", results.Errors.Count);
                        foreach (CompilerError err in results.Errors)
                        {
                            Console.WriteLine("ERROR {0}", err.ErrorText);
                        }

                        Assembly.LoadFile(Path.GetFullPath("./c.dll")).GetType("Program").GetMethod("Main");
                        byte[] encodedData = Encode(File.ReadAllBytes(Path.GetFullPath("./c.dll")), args[1]);
                        File.WriteAllBytes(Path.GetFullPath(args[2]), encodedData);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
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