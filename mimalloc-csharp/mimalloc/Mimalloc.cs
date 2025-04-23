using System.Runtime.InteropServices;
using System.Security;

#pragma warning disable CS1591
#pragma warning disable SYSLIB1054
#pragma warning disable CA1401
#pragma warning disable CA2101

// ReSharper disable ALL

namespace mimalloc
{
    [SuppressUnmanagedCodeSecurity]
    public static unsafe class Mimalloc
    {
        private const string NATIVE_LIBRARY = "mimalloc";

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_malloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_malloc(nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_free(void* ptr);
    }
}