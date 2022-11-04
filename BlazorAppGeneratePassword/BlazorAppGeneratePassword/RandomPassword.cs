using System;
using System.Linq;

namespace BlazorAppGeneratePassword
{
    public class RandomPassword
    {
        /// <summary>
        /// 数字
        /// </summary>
        private const string ASCII_NUMBER = "0123456789";

        /// <summary>
        /// 英字大文字
        /// </summary>
        private const string ASCII_UPPER_ALPHA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// 英字小文字
        /// </summary>
        private const string ASCII_LOWER_ALPHA = "abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// 記号
        /// </summary>
        private const string ASCII_MARK = "!\"#$%&'()*+-/<=>?@;[]^";

        private readonly Random rng = new Random(); //ランダムクラス

        /// <summary>
        /// ランダムな文字列を生成する。
        /// </summary>
        /// <param name="length">文字列の長さ</param>
        /// <returns>数字、大文字、小文字および記号を１文字以上含むランダムな文字列</returns>
        public string Generate(int length, bool hasUpperAlpha, bool hasLowerAlpha, bool hasNumber, bool hasMark)
        {
            string allSource = "";
            if (hasUpperAlpha)
            {
                allSource += ASCII_UPPER_ALPHA;
            }
            if (hasLowerAlpha)
            {
                allSource += ASCII_LOWER_ALPHA;
            }
            if (hasNumber)
            {
                allSource += ASCII_NUMBER;
            }
            if (hasMark)
            {
                allSource += ASCII_MARK;
            }

            //各文字種を最低１文字含める
            string password = "";
            if (hasUpperAlpha)
            {
                password += Choice(ASCII_UPPER_ALPHA);
            }
            if (hasLowerAlpha)
            {
                password += Choice(ASCII_LOWER_ALPHA);
            }
            if (hasNumber)
            {
                password += Choice(ASCII_NUMBER);
            }
            if (hasMark)
            {
                password += Choice(ASCII_MARK);
            }

            //任意の文字種でランダムな文字を生成
            int cnt = length - password.Length;
            for (int i = 0; i < cnt; i++)
            {
                password += Choice(allSource);
            }

            //生成した文字列をシャッフルして返す
            return string.Join("", password.OrderBy(n => rng.Next()));
        }

        /// <summary>
        /// 指定された文字列ソースからランダムに１文字選択する
        /// </summary>
        /// <param name="source">文字列ソース</param>
        /// <returns>ランダムに選択した文字</returns>
        private string Choice(string source)
        {
            return source[rng.Next(0, source.Length - 1)].ToString();
        }
    }
}