// Extensions that wrap common methods from the System.Security.Cryptography namespace.

// MIT License

// Copyright (C) 2015-2018 Owain Williams owain@giftcloud.com
// Invitation Digital Ltd, Merchants House, Wapping Road, Bristol, BS1 4RW

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace IDL.Security.Cryptography
{
    public static class CryptographyExtensions
    {
        /// <summary>
        /// Computes the hash value using the specified algorithm for the specified <see cref="System.Text.StringBuilder" /> using UTF-8 character encoding.
        /// </summary>
        /// <param name="value">The input to compute the hash code for.</param>
        /// <param name="algorithm">The cryptographic hash algorithm to use.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeHash(this StringBuilder value, HashAlgorithm algorithm)
        {
            return ComputeHash(value.ToString(), algorithm, Encoding.UTF8);
        }

        /// <summary>
        /// Computes the hash value using the specified algorithm for the specified <see cref="System.Text.StringBuilder" /> using the specified character encoding.
        /// </summary>
        /// <param name="value">The input to compute the hash code for.</param>
        /// <param name="algorithm">The cryptographic hash algorithm to use.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeHash(this StringBuilder value, HashAlgorithm algorithm, Encoding encoding)
        {
            return ComputeHash(value.ToString(), algorithm, encoding);
        }

        /// <summary>
        /// Computes the hash value using the specified algorithm for the specified string using UTF-8 character encoding.
        /// </summary>
        /// <param name="value">The input to compute the hash code for.</param>
        /// <param name="algorithm">The cryptographic hash algorithm to use.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeHash(this string value, HashAlgorithm algorithm)
        {
            return ComputeHash(value, algorithm, Encoding.UTF8);
        }

        /// <summary>
        /// Computes the hash value using the specified algorithm for the specified string using the specified character encoding.
        /// </summary>
        /// <param name="value">The input to compute the hash code for.</param>
        /// <param name="algorithm">The cryptographic hash algorithm to use.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeHash(this string value, HashAlgorithm algorithm, Encoding encoding)
        {
            return ComputeHash(encoding.GetBytes(value), algorithm);
        }

        /// <summary>
        /// Computes the hash value using the specified algorithm for the specified byte array.
        /// </summary>
        /// <param name="byteArray">The input to compute the hash code for.</param>
        /// <param name="algorithm">The cryptographic hash algorithm to use.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeHash(this byte[] byteArray, HashAlgorithm algorithm)
        {
            return algorithm.ComputeHash(byteArray);
        }

        /// <summary>
        /// Computes the hash value using the specified algorithm for the specified byte stream.
        /// </summary>
        /// <param name="stream">The input to compute the hash code for.</param>
        /// <param name="algorithm">The cryptographic hash algorithm to use.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeHash(this Stream stream, HashAlgorithm algorithm)
        {
            return algorithm.ComputeHash(stream);
        }

        /// <summary>
        /// Computes the keyed hash value using the specified algorithm and key for the specified <see cref="System.Text.StringBuilder" /> using UTF-8 character encoding.
        /// </summary>
        /// <param name="value">The input to compute the keyed hash code for.</param>
        /// <param name="algorithm">The keyed hash algorithm to use.</param>
        /// <param name="key">The key to use in the keyed hash algorithm.</param>
        /// <returns>The computed keyed hash code.</returns>
        public static byte[] ComputeKeyedHash(this StringBuilder value, KeyedHashAlgorithm algorithm, byte[] key)
        {
            return ComputeKeyedHash(value.ToString(), algorithm, key, Encoding.UTF8);
        }

        /// <summary>
        /// Computes the keyed hash value using the specified algorithm and key for the specified <see cref="System.Text.StringBuilder" /> using the specified character encoding.
        /// </summary>
        /// <param name="value">The input to compute the keyed hash code for.</param>
        /// <param name="algorithm">The keyed hash algorithm to use.</param>
        /// <param name="key">The key to use in the keyed hash algorithm.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <returns>The computed keyed hash code.</returns>
        public static byte[] ComputeKeyedHash(this StringBuilder value, KeyedHashAlgorithm algorithm, byte[] key, Encoding encoding)
        {
            return ComputeKeyedHash(value.ToString(), algorithm, key, encoding);
        }

        /// <summary>
        /// Computes the keyed hash value using the specified algorithm and key for the specified string using UTF-8 character encoding.
        /// </summary>
        /// <param name="value">The input to compute the keyed hash code for.</param>
        /// <param name="algorithm">The keyed hash algorithm to use.</param>
        /// <param name="key">The key to use in the keyed hash algorithm.</param>
        /// <returns>The computed keyed hash code.</returns>
        public static byte[] ComputeKeyedHash(this string value, KeyedHashAlgorithm algorithm, byte[] key)
        {
            return ComputeKeyedHash(value, algorithm, key, Encoding.UTF8);
        }

        /// <summary>
        /// Computes the keyed hash value using the specified algorithm and key for the specified string using the specified character encoding.
        /// </summary>
        /// <param name="value">The input to compute the keyed hash code for.</param>
        /// <param name="algorithm">The keyed hash algorithm to use.</param>
        /// <param name="key">The key to use in the keyed hash algorithm.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <returns>The computed keyed hash code.</returns>
        public static byte[] ComputeKeyedHash(this string value, KeyedHashAlgorithm algorithm, byte[] key, Encoding encoding)
        {
            return ComputeKeyedHash(encoding.GetBytes(value), algorithm, key);
        }

        /// <summary>
        /// Computes the keyed hash value using the specified algorithm and key for the specified byte array.
        /// </summary>
        /// <param name="byteArray">The input to compute the keyed hash code for.</param>
        /// <param name="algorithm">The keyed hash algorithm to use.</param>
        /// <param name="key">The key to use in the keyed hash algorithm.</param>
        /// <returns>The computed keyed hash code.</returns>
        public static byte[] ComputeKeyedHash(this byte[] byteArray, KeyedHashAlgorithm algorithm, byte[] key)
        {
            algorithm.Key = key;
            return algorithm.ComputeHash(byteArray);
        }

        /// <summary>
        /// Computes the keyed hash value using the specified algorithm and key for the specified byte array.
        /// </summary>
        /// <param name="stream">The input to compute the keyed hash code for.</param>
        /// <param name="algorithm">The keyed hash algorithm to use.</param>
        /// <param name="key">The key to use in the keyed hash algorithm.</param>
        /// <returns>The computed keyed hash code.</returns>
        public static byte[] ComputeKeyedHash(this Stream stream, KeyedHashAlgorithm algorithm, byte[] key)
        {
            algorithm.Key = key;
            return algorithm.ComputeHash(stream);
        }

        /// <summary>
        /// Converts the numeric value of each element of a specified array of bytes to its equivalent hexadecimal string representation.
        /// </summary>
        /// <param name="byteArray">An array of bytes.</param>
        /// <returns>
        /// A string of hexadecimal pairs, where each pair represents the corresponding
        /// element in <paramref name="byteArray" />; for example, "7f2c4a00".
        /// </returns>
        public static string ToHex(this byte[] byteArray)
        {
            return byteArray.ToHex(x => x.ToLower());
        }

        /// <summary>
        /// Converts the numeric value of each element of a specified array of bytes to its equivalent hexadecimal string representation.
        /// </summary>
        /// <param name="byteArray">An array of bytes.</param>
        /// <param name="selector">A transform function to apply to the hexadecimal string</param>
        /// <returns>
        /// A string of hexadecimal pairs, where each pair represents the corresponding
        /// element in <paramref name="byteArray" />; for example, "7F2C4A00".
        /// </returns>
        /// <example>
        /// The following code example demonstrates how to use ToHex(byte[], Func&lt;string, string$gt;) to convert a
        /// byte array its hexadecimal representation and then transform the resulting string to uppercase characters.
        /// <code>
        /// byte[] byteArray = { 0x7F, 0x2C, 0x4A, 0x0 };
        /// 
        /// string hexString = byteArray.ToHex(x => x.ToUpper());
        /// 
        /// Console.WriteLine(hexString);
        /// 
        /// /*
        ///  This code produces the following output:
        ///  7F2C4A00
        /// */
        /// </code>
        /// </example>
        public static string ToHex(this byte[] byteArray, Func<string, string> selector)
        {
            return selector(BitConverter.ToString(byteArray).Replace("-", string.Empty));
        }
    }
}
