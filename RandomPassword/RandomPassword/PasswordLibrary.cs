using System;
using System.Linq;
using System.Text;

namespace PasswordLibrary
{
    public class RandomPassword
    {
        private const string ASCII_NUMBER = "0123456789";
        private const string ASCII_UPPER_ALPHA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string ASCII_LOWER_ALPHA = "abcdefghijklmnopqrstuvwxyz";
        private const string ASCII_MARK = "!\"#$%&'()*+-/<=>?@;[]^";

        private readonly Random rng = new Random();

        /// <summary>
        /// ランダムなパスワードを生成します。
        /// </summary>
        /// <param name="length">パスワードの長さ</param>
        /// <param name="hasUpperAlpha">大文字を含むかどうか</param>
        /// <param name="hasLowerAlpha">小文字を含むかどうか</param>
        /// <param name="hasNumber">数字を含むかどうか</param>
        /// <param name="hasMark">記号を含むかどうか</param>
        /// <returns>指定した条件に基づいたランダムなパスワード</returns>
        public string Generate(int length, bool hasUpperAlpha, bool hasLowerAlpha, bool hasNumber, bool hasMark)
        {
            if (length <= 0) throw new ArgumentException("パスワードの長さは正の整数でなければなりません。");
            if (!hasUpperAlpha && !hasLowerAlpha && !hasNumber && !hasMark)
                throw new ArgumentException("少なくとも1つの文字種を選択する必要があります。");

            StringBuilder allSource = new StringBuilder();
            if (hasUpperAlpha) allSource.Append(ASCII_UPPER_ALPHA);
            if (hasLowerAlpha) allSource.Append(ASCII_LOWER_ALPHA);
            if (hasNumber) allSource.Append(ASCII_NUMBER);
            if (hasMark) allSource.Append(ASCII_MARK);

            StringBuilder password = new StringBuilder();
            if (hasUpperAlpha) password.Append(Choice(ASCII_UPPER_ALPHA));
            if (hasLowerAlpha) password.Append(Choice(ASCII_LOWER_ALPHA));
            if (hasNumber) password.Append(Choice(ASCII_NUMBER));
            if (hasMark) password.Append(Choice(ASCII_MARK));

            int cnt = length - password.Length;
            for (int i = 0; i < cnt; i++)
            {
                password.Append(Choice(allSource.ToString()));
            }

            return Shuffle(password.ToString());
        }

        private char Choice(string source)
        {
            return source[rng.Next(0, source.Length)];
        }

        /// <summary>
        /// Fisher-Yatesアルゴリズム
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string Shuffle(string input)
        {
            char[] array = input.ToCharArray();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = rng.Next(0, i + 1);
                char temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return new string(array);
        }
    }
}
