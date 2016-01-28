using System;
using System.Linq;

namespace ExtenCiv.Tests.Utilities
{
    public static class GuidUtilities
    {
        public static Guid Id(int id) { return new Guid(id, 0, 0, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }); }

        public static int ReverseId(Guid id) { return BitConverter.ToInt32(id.ToByteArray().Take(4).ToArray(), 0); }
    }
}
