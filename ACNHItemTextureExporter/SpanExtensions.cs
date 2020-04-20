﻿using System;

namespace ACNHItemTextureExporter
{
    public static class SpanExtensions
    {
        public static short GetInt16(this ReadOnlySpan<byte> data, int address)
        {
            return (short) (data[address + 0] << 0 | data[address + 1] << 8);
        }

        public static int GetInt32(this ReadOnlySpan<byte> data, int address)
        {
            return
                data[address + 0] << 0 |
                data[address + 1] << 8 |
                data[address + 2] << 16 |
                data[address + 3] << 24;
        }
    }
}