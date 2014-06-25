// <copyright file="Program.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace FileSplicer
{
    using System;
    using System.IO;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists(args[0]))
            {
                throw new Exception("This directory doesn't exist. Example call is FileSplicer c:/temp c:/temp/OUTPUT_FILE.log");
            }

            if (File.Exists(args[1]))
            {
                throw new Exception("The output file exists. Choose a different output file. Example call is FileSplicer c:/temp c:/temp/OUTPUT_FILE.log");
            }

            StringBuilder sb = new StringBuilder();
            foreach (var file in Directory.GetFiles(args[0]))
            {
                sb.Append(string.Join("", File.ReadAllLines(file)));
            }

            File.WriteAllText(args[1], sb.ToString());
        }
    }
}
