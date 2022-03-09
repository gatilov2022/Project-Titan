using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace game
{
     
    internal class ChunkGenerator
    {
        static int ChunkSize = 16;
        static int MaxSpriteSize = 84;
        static int ImageXSize = MaxSpriteSize * ChunkSize;
        static int ImageYSize = MaxSpriteSize * ChunkSize;
        static public Bitmap GenerateChunk(int x, int y) 
        {
            Bitmap chunk_image = new Bitmap(ImageXSize, ImageYSize);
            Graphics g = Graphics.FromImage(chunk_image);

            for (int i = 0; i < ChunkSize; i++)
            {
                for (int j = 0; j < ChunkSize; j++)
                {
                    
                }
            }
            return chunk_image;
        }
    }
}
