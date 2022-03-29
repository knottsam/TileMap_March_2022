using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileMap_March_2022
{
    class Tile : Sprite
    {
        public Tile()
        { 
        }

        public Tile(Texture2D inTexture, Vector2 inPosition, Vector2 inSize, Color inColour)
            : base(inTexture, inPosition, inSize, inColour)
        {
        }

        public Vector2 GetTilePosition { get; set; }

        public string TileType { get; set; }
    }
}
