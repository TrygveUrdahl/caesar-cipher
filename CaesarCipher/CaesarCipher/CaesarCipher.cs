using System;
using System.Collections.Generic;

namespace CaesarCipher
{
    public static class CaesarCipher
    {
        // Define all letters in the alphabet that are encoded/decoded.
        private static List<char> alphabet = new List<char>()
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z', 'æ', 'ø', 'å', ' ',
        };
        public static string Run(string InputText, int Offset, bool Decode)
        {
            // To decode, set offset to -offset
            int offset = Decode ? -Offset : Offset;

            string output = string.Empty;
            foreach (char c in InputText.ToLower())
            {
                // Inefficient to concat to string, change to StringBuilder for better performance.
                output += Cipher(c, offset);
            }
            return output;
        }
        private static char Cipher(char c, int offset)
        {
            // Preserve newlines, ignore endcoding/decoding any letters not in the defined alphabet.
            if (!alphabet.Contains(c))
            {
                return c;
            }
            // Return character at index + offset in alphabet, and use modulo to wrap around. 
            int index = alphabet.IndexOf(c);
            return alphabet[(index + offset + alphabet.Count) % alphabet.Count];
        }
    }
}