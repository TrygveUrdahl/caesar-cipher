using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CaesarCipherTest
{
    using CaesarCipher;

    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestEmptyStringEncode()
        {
            string rawString = "";
            string encodedString = "";
            int offset = 3;

            string encoded = CaesarCipher.Run(rawString, offset, false);
            Assert.AreEqual(encodedString, encoded);
        }

        [TestMethod]
        public void TestEmptyStringDecode()
        {
            string rawString = "";
            string decodedString = "";
            int offset = 3;

            string decoded = CaesarCipher.Run(rawString, offset, true);
            Assert.AreEqual(decodedString, decoded);
        }

        [TestMethod]
        public void TestNoOffsetEncode()
        {
            string rawString = "a";
            string encodedString = "a";
            int offset = 0;

            string encoded = CaesarCipher.Run(rawString, offset, false);
            Assert.AreEqual(encodedString, encoded);
        }

        [TestMethod]
        public void TestNoOffsetDecode()
        {
            string rawString = "a";
            string decodedString = "a";
            int offset = 0;

            string decoded = CaesarCipher.Run(rawString, offset, true);
            Assert.AreEqual(decodedString, decoded);
        }

        [TestMethod]
        public void TestSingleCharacterEncode()
        {
            string rawString = "a";
            string encodedString = "d";
            int offset = 3;

            string encoded = CaesarCipher.Run(rawString, offset, false);
            Assert.AreEqual(encodedString, encoded);
        }

        [TestMethod]
        public void TestSingleCharacterDecode()
        {
            string rawString = "d";
            string decodedString = "a";
            int offset = 3;

            string decoded = CaesarCipher.Run(rawString, offset, true);
            Assert.AreEqual(decodedString, decoded);
        }

        [TestMethod]
        public void TestEncodeFile()
        {
            string plainTextFile = "../../../../plaintext.txt";
            string encodedTextFile = "../../../../ciphertext-shift-7.txt";
            int offset = 7;

            string plainText = File.ReadAllText(plainTextFile).ToLower();
            string encodedText = File.ReadAllText(encodedTextFile).ToLower();

            string encoded = CaesarCipher.Run(plainText, offset, false);

            Assert.AreEqual(encodedText, encoded);
        }

        [TestMethod]
        public void TestDecodeFile()
        {
            string plainTextFile = "../../../../plaintext.txt";
            string encodedTextFile = "../../../../ciphertext-shift-7.txt";
            int offset = 7;

            string plainText = File.ReadAllText(plainTextFile).ToLower();
            string encodedText = File.ReadAllText(encodedTextFile).ToLower();

            string decoded = CaesarCipher.Run(encodedText, offset, true);

            Assert.AreEqual(plainText, decoded);
        }
    }
}
