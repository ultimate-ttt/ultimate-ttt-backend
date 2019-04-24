using System;

namespace UltimateTicTacToe.Domain
{
    public static class ReadableIdGenerator
    {
        private static string[] Characters = new string[]{"🧙"};

        public static string NewId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
