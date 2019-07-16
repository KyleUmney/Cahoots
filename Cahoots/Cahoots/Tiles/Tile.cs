using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cahoots.Tiles
{
  public class Tile : BaseTile
  {
    public enum TileTypes
    {
      Walkable,
      Placable,
    }

    public TileTypes TileType { get; set; }
    public Color Colour
    {
      get
      {
        switch (TileType)
        {
          case TileTypes.Walkable:
            return Color.White;

          case TileTypes.Placable:
            return Color.Red;

          default:
            throw new Exception("New phone who dis");
        }
      }
    }
  }
}
