﻿using ImpromptuNinjas.ZStd;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ACNHItemTextureExporter
{
    class ZstdDecompressor
    {
        public static byte[] Decompress(ReadOnlySpan<byte> compressedFrame)
        {
            // create a context
            var decompressor = new ZStdDecompressor();

            // figure out about how big of a buffer you need
            var decompressBufferSize = ZStdDecompressor.GetUpperBound(compressedFrame);

            var decompressBuffer = new byte[decompressBufferSize];

            // actually perform the decompression operation
            var decompressedSize = decompressor.Decompress(decompressBuffer, compressedFrame);

            // retrieve your decompressed frame
            return new ArraySegment<byte>(decompressBuffer, 0, (int)decompressedSize).ToArray();
        }

        public static Stream DecompressToStream(ReadOnlySpan<byte> compressedFrame)
        {
            var stream = new MemoryStream();
            stream.Write(Decompress(compressedFrame));
            return stream;
        }
    }
}
