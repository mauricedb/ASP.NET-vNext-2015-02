using System.Text;

namespace WebDemo.Formatters
{
    internal static class Encodings
    {
        /// <summary>
        /// Returns UTF8 Encoding without BOM and throws on invalid bytes.
        /// </summary>
        public static readonly Encoding UTF8EncodingWithoutBOM
            = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

        /// <summary>
        /// Returns UTF16 Encoding which uses littleEndian byte order with BOM and throws on invalid bytes.
        /// </summary>
        public static readonly Encoding UTF16EncodingLittleEndian = new UnicodeEncoding(bigEndian: false,
            byteOrderMark: true,
            throwOnInvalidBytes: true);
    }
}