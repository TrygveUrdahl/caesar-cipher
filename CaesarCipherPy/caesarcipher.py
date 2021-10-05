import argparse


class CaesarCipher:
    alphabet = [
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
        'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
        'u', 'v', 'w', 'x', 'y', 'z', 'æ', 'ø', 'å', ' ',
    ]

    @staticmethod
    def run(input: str, offset: int, decode: bool = False) -> str:
        offset = -offset if decode else offset
        cipher = ""
        for c in input:
            if c in CaesarCipher.alphabet:
                cipher += CaesarCipher.alphabet[((CaesarCipher.alphabet.index(
                    c) + offset + len(CaesarCipher.alphabet)) % len(CaesarCipher.alphabet))]
            else:
                cipher += c
        return cipher


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("textFile", type=str,
                    help="path to txt file containing cipher")
    ap.add_argument("offset", type=int, help="cipher offset (i.e. key).")
    ap.add_argument("-d", "--decrypt", action="store_true",
                    help="decrypt code (default encrypt)")
    ap.add_argument("-s", "--save", type=str,
                    help="save output to file, if not set print to console")
    args = ap.parse_args()

    if not args.textFile.endswith(".txt"):
        raise argparse.ArgumentTypeError("textFile must be of type .txt")
    if args.save and not args.save.endswith(".txt"):
        raise argparse.ArgumentTypeError("output file must be of type .txt")

    with open(args.textFile, "r", encoding="utf-8") as f:
        cipher = CaesarCipher.run(f.read(), args.offset, args.decrypt)

    if (args.save):
        with open(args.save, "w", encoding="utf-8") as f:
            f.write(cipher)
    else:
        print(cipher, end="")


if __name__ == "__main__":
    main()
