using System;

namespace UltimateTicTacToe.Domain
{
    public static class ReadableIdGenerator
    {
        private static char[] Characters = "jfdk".ToCharArray();

        public static string NewId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
