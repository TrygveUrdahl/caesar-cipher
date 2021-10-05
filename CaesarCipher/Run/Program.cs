using System;
using System.Collections.Generic;
using System.IO;
using CommandLine;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parse CLI arguments.
            CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);
        }
        static void RunOptions(CommandLineOptions opts)
        {
            string textFileString = File.ReadAllText(opts.InputFile);
            string cipher = CaesarCipher.Run(textFileString, opts.Offset, opts.Decode);

            // Optionally save output to a .txt file, or write to console.
            if (opts.Save != "")
            {
                File.WriteAllText(opts.Save, cipher);
            }
            else
            {
                Console.Write(cipher);
            }
        }
        static void HandleParseError(IEnumerable<Error> errs)
        {
            // If errors parsing arguments the parser prints help. 
            // Don't need to do anything here.
        }
    }
}
