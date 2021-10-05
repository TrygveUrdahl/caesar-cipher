import pytest
from caesarcipher import CaesarCipher


class TestCaesarCipher:
    @pytest.mark.parametrize("test_input, expected, offset",
                             [
                                 ("", "", 1),
                                 ("a", "d", 3),
                                 ("a z", "fea", 5),
                                 ("a", "a", 0),
                             ], ids=[
                                 "empty string",
                                 "single character",
                                 "small string with rotation around alphabet",
                                 "no offset",
                             ])
    def test_encodeString(self, test_input: str, expected: str, offset: int):
        assert(CaesarCipher.run(test_input, offset) == expected)

    @pytest.mark.parametrize("test_input, expected, offset",
                             [
                                 ("", "", 1),
                                 ("d", "a", 3),
                                 ("fea", "a z", 5),
                                 ("a", "a", 0),
                             ], ids=[
                                 "empty string",
                                 "single character",
                                 "small string with rotation around alphabet",
                                 "no offset",
                             ])
    def test_decodeString(self, test_input: str, expected: str, offset: int):
        assert(CaesarCipher.run(test_input, offset, True) == expected)

    def test_encodeTestFile(self):
        with open("plaintext.txt", "r", encoding="utf-8") as plain, \
                open("ciphertext-shift-7.txt", "r", encoding="utf-8") as cipher:
            assert(CaesarCipher.run(plain.read(), 7) == cipher.read())

    def test_decodeTestFile(self):
        with open("plaintext.txt", "r", encoding="utf-8") as plain, \
                open("ciphertext-shift-7.txt", "r", encoding="utf-8") as cipher:
            assert(CaesarCipher.run(cipher.read(), 7, True) == plain.read())
