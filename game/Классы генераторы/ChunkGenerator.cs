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
        public static int ChunkSize = 16;
        static int MaxSpriteSize = 84;
        static int ImageXSize = MaxSpriteSize * ChunkSize;
        static int ImageYSize = MaxSpriteSize * ChunkSize;
        static Random rand = new Random();
        static public Bitmap GenerateChunk(int x, int y) 
        {
            Bitmap chunk_image = new Bitmap(ImageXSize, ImageYSize);
            Graphics g = Graphics.FromImage(chunk_image);

            int rand_num;
            int coordinate_x, coordinate_y;

            for (int i = 0; i < ChunkSize; i++)
            {
                for (int j = 0; j < ChunkSize; j++)
                {
                    coordinate_x = i;
                    coordinate_y = j;

                    rand_num = rand.Next(0, 100);

                    if (rand_num <= 6)
                    {
                        Ore block = new Ore(coordinate_x, coordinate_y);
                        block.Draw_block(g);
                        Map.Add(block);
                    }
                    else if (rand_num <= 8)
                    {
                        Water block = new Water(coordinate_x, coordinate_y);
                        block.Draw_block(g);
                        Map.Add(block);
                    }
                    else if (rand_num <= 12)
                    {
                        Sand block = new Sand(coordinate_x, coordinate_y);
                        block.Draw_block(g);
                        Map.Add(block);
                    }
                    else
                    {
                        Grass block = new Grass(coordinate_x, coordinate_y);
                        block.Draw_block(g);
                        Map.Add(block);
                    }


                }
            }
            return chunk_image;
        }
    }
}
