﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Telesto
{

    [StructLayout(LayoutKind.Explicit)]
    internal struct Command : IDisposable
    {

        [FieldOffset(0)]
        private IntPtr p;

        [FieldOffset(8)]
        private ulong unk1;

        [FieldOffset(16)]
        private ulong len;
        
        [FieldOffset(24)]
        private ulong unk2;

        internal Command(string text)
        {
            byte[] b = Encoding.UTF8.GetBytes(text);
            p = Marshal.AllocHGlobal(b.Length + 30);
            Marshal.Copy(b, 0, p, b.Length);
            Marshal.WriteByte(p + b.Length, 0);
            this.len = (ulong)(b.Length + 1);
            this.unk1 = 64;
            this.unk2 = 0;
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(this.p);
        }

    }

}
