using System;

namespace UltimateTicTacToe.Domain
{
    public static class ReadableIdGenerator
    {
        private const string Characters =
            "ABCDEFGHIJKLMNOPQRSTUVQXYZabcdefghijklmnopqrstuvwxyz123456789";

        private const int IdLength = 7;

        public static string NewId()
        {
            var random = new Random();
            var characterAmount = Characters.Length;
            var id = new char[IdLength];

            for (var i = 0; i < IdLength; i++)
            {
                var index = random.Next(0, characterAmount);
                id[i] = Characters[index];
            }

            return new string(id);
        }
    }
}
