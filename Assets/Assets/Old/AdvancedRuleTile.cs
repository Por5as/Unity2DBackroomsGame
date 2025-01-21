using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "VinTools/Custom Tiles/Advanced Rule Tile")]
public class AdvancedRuleTile : RuleTile<AdvancedRuleTile.Neighbor>
{
    public enum Direction
    {
        Top,
        Bottom,
        Left,
        Right
    }

    [Header("Advanced Tile Settings")]
    [Tooltip("Assign sprites for the tile. Sprites will be chosen randomly based on the direction.")]
    public Sprite[] sprites;

    public Direction direction;

    public class Neighbor : RuleTile.TilingRule.Neighbor
    {
        public const int Top = 3;
        public const int Bottom = 4;
        public const int Left = 5;
        public const int Right = 6;

        public const int NotTop = 7;
        public const int NotBottom = 8;
        public const int NotLeft = 9;
        public const int NotRight = 10;
    }

    public override bool RuleMatch(int neighbor, TileBase tile)
    {
        return neighbor switch
        {
            Neighbor.Top => HasDirection(tile, Direction.Top, true),
            Neighbor.Bottom => HasDirection(tile, Direction.Bottom, true),
            Neighbor.Left => HasDirection(tile, Direction.Left, true),
            Neighbor.Right => HasDirection(tile, Direction.Right, true),

            Neighbor.NotTop => HasDirection(tile, Direction.Top, false),
            Neighbor.NotBottom => HasDirection(tile, Direction.Bottom, false),
            Neighbor.NotLeft => HasDirection(tile, Direction.Left, false),
            Neighbor.NotRight => HasDirection(tile, Direction.Right, false),


            _ => base.RuleMatch(neighbor, tile),

        };
    }

    private bool HasDirection(TileBase tile, Direction direction, bool value)
    {
        if (tile is AdvancedRuleTile ruleTile)
            return (ruleTile.direction == direction) == value;

        return false;
    }


    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);


        if (sprites != null && sprites.Length > 0)
        {
            tileData.sprite = sprites[Random.Range(0, sprites.Length)];
        }

    }


}