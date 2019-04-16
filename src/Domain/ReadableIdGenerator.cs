using System;

namespace UltimateTicTacToe.Domain
{
    public class ReadableIdGenerator
    {
        public static string NewId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}