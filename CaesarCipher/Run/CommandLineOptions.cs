using System;
using CommandLine;

namespace CaesarCipher
{
    // Contains CLI options to run program.
    public class CommandLineOptions
    {
        [Option('f', "file", Required = true, HelpText = "Input file to be encoded/decoded.")]
        public string InputFile { get; set; }

        [Option('o', "offset", Required = true, HelpText = "Cipher offset (i.e. key).")]
        public int Offset { get; set; }

        [Option('d', "decode", Default = false, HelpText = "Set flag to decode instead of encode.")]
        public bool Decode { get; set; }

        [Option('s', "save", Default = "", Required = false, HelpText = "Save output to file, if not set print to console.")]
        public string Save { get; set; }
    }
}