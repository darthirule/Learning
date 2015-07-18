using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids
{
   public class TileGen
    {
       
       private Random random;
       int sX;
       int sY;
       int sH = 60;
       int sW = 60;
       public List<Rectangle> Squares;
       public List<Texture2D> Textures;
       private Texture2D texture;
       bool inter = false;

       private Rectangle GenSquare()
       {
           sX = (int)random.Next(1920);
           sY = (int)random.Next(1080);

           Rectangle rect = new Rectangle(sX, sY, sW, sH);
           
           return rect;
       }

       public void Init()
       {
           Squares = new List<Rectangle>();
           Textures = new List<Texture2D>();
           random = new Random();
       }


       private Texture2D GenTexture(GraphicsDevice graphics)
       {

           Texture2D Texture;

           Color color = new Color(
                (float)random.NextDouble(),
                (float)random.NextDouble(),
                (float)random.NextDouble());

           Color[] colorData = new Color[100 * 100];

           for (int i = 0; i < 10000; i++)
               colorData[i] = color;

           Texture = new Texture2D(graphics, sW, sH);

           Texture.SetData<Color>(colorData);

           return Texture;



       }


       public void Update(GraphicsDevice graphics)
       {
           for (int i = 0; i <= Squares.Count() - 1; i++)
           {
               if (Squares.Count() <= 150)
               {
                   if (!inter)
                   {

                       Squares.Add(GenSquare());
                   }

                   inter = checkInter(i);
               }
           }

           if (Textures.Count() <= 150)
           {
               Textures.Add(GenTexture(graphics));
           }

           texture = GenTexture(graphics);

       }

       public void Draw(SpriteBatch spriteBatch)
       {
           spriteBatch.Begin();
           for (int i = 0; i < Squares.Count(); i++)
           {
                   spriteBatch.Draw(Textures[i], Squares[i], Color.White);
           }
           spriteBatch.End();
       }

       private bool checkInter(int Index)
       {

           bool intersected = false;

           for (int i = 1; i <= Squares.Count() - 1; i++)
           {
               if (Squares[Index].Intersects(Squares[i - 1]))
               {
                   intersected = true;
               }

               else intersected = false;
           }

           return intersected;
       }

    }
}
