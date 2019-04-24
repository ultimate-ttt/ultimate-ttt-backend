using System;

namespace UltimateTicTacToe.Domain
{
    public static class ReadableIdGenerator
    {
        private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVQXYZabcdefghijklmnopqrstuvwxyz";
        private const int IdLength = 7;

        public static string NewId()
        {
            Random random = new Random();
            int characterAmount = Characters.Length;
            char[] id = new char[IdLength];

            for (int i = 0; i < IdLength; i++)
            {
                int index = random.Next(0,characterAmount);
                id[i] = Characters[index];
            }

            return new string(id);
        }
    }
}
