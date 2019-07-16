using Cahoots.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cahoots
{
  public class Grid
  {
    private int[,] map = new int[,]
    {
      {1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
      {1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
      {1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
      {1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
      {1,1,1,1,1,0,0,0,0,0,0,1,0,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1},
      {1,1,1,1,1,0,1,1,1,1,0,1,0,1,1,0,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1},
      {1,1,1,1,1,0,1,1,1,1,0,1,0,1,1,0,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1},
      {1,1,1,1,1,0,1,1,1,1,0,1,0,1,1,0,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1},
      {1,1,1,1,1,0,1,1,1,1,0,0,0,1,1,0,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1},
      {1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,0,0,0,0,0,0,0,0,0,1,1,0,0,0},
      {1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,0,1,1,0,1,1},
      {1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,0,1,1,0,1,1},
      {1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,0,1,1,0,1,1},
      {1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,0,1,1,0,1,1},
      {1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,0,1,1,0,1,1},
      {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,1,1,0,0,0,0,1,1},
      {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1},
      {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    };

    public List<Tile> Tiles { get; set; }

    public void Draw(SpriteBatch sb)
    {
      foreach (var item in Tiles)
      {
        sb.Draw(item.Texture, item.Rectangle, item.Colour);
      }
    }

    public void PopulateTiles(Texture2D texture)
    {
      Tiles = new List<Tile>();
      var width = map.GetLength(1);
      var height = map.GetLength(0);

      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          var value = map[y, x];
          Tiles.Add(new Tile()
          {
            Rectangle = new Rectangle(x * texture.Width, y * texture.Height,texture.Width, texture.Height),
            TileType = value == 0 ? Tile.TileTypes.Walkable : Tile.TileTypes.Placable,
            Texture = texture,
          });
        }
      }
    }
  }
}

