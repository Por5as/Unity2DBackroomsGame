using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;
using System;

[CreateAssetMenu(menuName = "VinTools/Custom Tiles/Advanced Rule Tile")]
public class AdvancedRuleTileOld : RuleTile<AdvancedRuleTile.Neighbor>
{
    [Header("Advanced Tile")]
    [Tooltip("If enabled, the tile will connect to these tiles too when the mode is set to \"This\"")]
    public bool alwaysConnect;
    [Tooltip("Tiles to connect to")]
    public TileBase[] tilesToConnect;

    public TileBase[] topEntrance;
    public TileBase[] bottomEntrance;
    public TileBase[] leftEntrance;
    public TileBase[] rightEntrance;

    /*
    public Sprite B;
    public Sprite L;
    public Sprite R;
    public Sprite T;
    public Sprite Closed;
    */
    /*
    public Sprite Opened;
    public Sprite BL;
    public Sprite BR;
    public Sprite BRL;
    public Sprite RL;
    public Sprite TB;
    public Sprite TBL;
    public Sprite TBR;
    public Sprite TL;
    public Sprite TR;
    public Sprite TRL;
    */


    [Space]
    [Tooltip("Check itseft when the mode is set to \"any\"")]
    public bool checkSelf = true;

    public class Neighbor : RuleTile.TilingRule.Neighbor
    {
        public const int Any = 3;
        public const int Nothing = 4;

        public const int topEntrance = 5;
        public const int bottomEntrance = 6;
        public const int leftEntrance = 7;
        public const int rightEntrance = 8;


        public const int notTopEntrance = 9;
        public const int notBottomEntrance = 10;
        public const int notLeftEntrance = 11;
        public const int notRightEntrance = 12;


        /*
        public const int Opened = 5;
        public const int BL = 6;
        public const int BR = 7;
        public const int BRL = 8;
        public const int RL = 9;
        public const int TB = 10;
        public const int TBL = 11;
        public const int TBR = 12;
        public const int TL = 13;
        public const int TR = 14;
        public const int TRL = 15;
        */

    }

    public override bool RuleMatch(int neighbor, TileBase tile)
    {
        switch (neighbor)
        {
            case Neighbor.This: return Check_This(tile);
            case Neighbor.NotThis: return Check_NotThis(tile);
            case Neighbor.Any: return Check_Any(tile);
            case Neighbor.Nothing: return Check_Nothing(tile);

            case Neighbor.topEntrance: return Check_topEntrance(tile);
            case Neighbor.bottomEntrance: return Check_bottomEntrance(tile);
            case Neighbor.leftEntrance: return Check_leftEntrance(tile);
            case Neighbor.rightEntrance: return Check_rightEntrance(tile);


            case Neighbor.notTopEntrance: return Check_notTopEntrance(tile);
            case Neighbor.notBottomEntrance: return Check_notBottomEntrance(tile);
            case Neighbor.notLeftEntrance: return Check_notLeftEntrance(tile);
            case Neighbor.notRightEntrance: return Check_notRightEntrance(tile);


                /*
                case Neighbor.Opened: return Check_Opened(tile);
                case Neighbor.BL: return Check_BL(tile);
                case Neighbor.BR: return Check_BR(tile);
                case Neighbor.BRL: return Check_BRL(tile);
                case Neighbor.RL: return Check_RL(tile);
                case Neighbor.TB: return Check_TB(tile);
                case Neighbor.TBL: return Check_TBL(tile);
                case Neighbor.TBR: return Check_TBR(tile);
                case Neighbor.TL: return Check_TL(tile);
                case Neighbor.TR: return Check_TR(tile);
                case Neighbor.TRL: return Check_TRL(tile);
                */

        }
        return base.RuleMatch(neighbor, tile);
    }

    /// <summary>
    /// Returns true if the tile is this, or if the tile is one of the tiles specified if always connect is enabled.
    /// </summary>
    /// <param name="tile">Neighboring tile to compare to</param>
    /// <returns></returns>
    bool Check_This(TileBase tile)
    {
        if (!alwaysConnect) return tile == this;
        else return tilesToConnect.Contains(tile) || tile == this;

        //.Contains requires "using System.Linq;"
    }

    /// <summary>
    /// Returns true if the tile is not this.
    /// </summary>
    /// <param name="tile">Neighboring tile to compare to</param>
    /// <returns></returns>
    bool Check_NotThis(TileBase tile)
    {
        if (!alwaysConnect) return tile != this;
        else return !tilesToConnect.Contains(tile) && tile != this;

        //.Contains requires "using System.Linq;"
    }

    /// <summary>
    /// Return true if the tile is not empty, or not this if the check self option is disabled.
    /// </summary>
    /// <param name="tile">Neighboring tile to compare to</param>
    /// <returns></returns>
    bool Check_Any(TileBase tile)
    {
        if (checkSelf) return tile != null;
        else return tile != null && tile != this;
    }


    /// <summary>
    /// Returns true if the tile is empty.
    /// </summary>
    /// <param name="tile">Neighboring tile to compare to</param>
    /// <param name="tile"></param>
    /// <returns></returns>
    bool Check_Nothing(TileBase tile)
    {
        return tile == null;
    }

    /// <summary>
    /// Returns true if the tile is one of the specified tiles.
    /// </summary>
    /// <param name="tile">Neighboring tile to compare to</param>
    /// <returns></returns>

    /*
    bool Check_Opened(TileBase tile) { return tile == Opened; }
    bool Check_BL(TileBase tile) { return tile == BL; }
    bool Check_BR(TileBase tile) {  return tile == BR; }
    bool Check_BRL(TileBase tile) {return tile == BRL; }
    bool Check_RL(TileBase tile) { return tile == RL; }
    bool Check_TB(TileBase tile) { return tile == TB; }
    bool Check_TBL(TileBase tile) { return tile == TBL; }
    bool Check_TBR(TileBase tile) { return tile == TBR; }
    bool Check_TL(TileBase tile) { return tile == TL; }
    bool Check_TR(TileBase tile) { return tile == TR; }
    bool Check_TRL(TileBase tile) { return tile == TRL; }
    */



    //YES
    bool Check_topEntrance(TileBase tile)
    {
        if (checkSelf) return tile != null;
        else return tile != null && tile != this && tile == topEntrance.Contains(tile);
        //return topEntrance.Contains(tile);
        //.Contains requires "using System.Linq;"
    }

    bool Check_bottomEntrance(TileBase tile)
    {
        if (checkSelf) return tile != null;
        else return tile != null && tile != this && tile == bottomEntrance.Contains(tile);
        //return bottomEntrance.Contains(tile);
        //.Contains requires "using System.Linq;"
    }

    bool Check_leftEntrance(TileBase tile)
    {
        if (checkSelf) return tile != null;
        else return tile != null && tile != this && tile == leftEntrance.Contains(tile);
        //return leftEntrance.Contains(tile);
        //.Contains requires "using System.Linq;"
    }

    bool Check_rightEntrance(TileBase tile)
    {
        if (checkSelf) return tile != null;
        else return tile != null && tile != this && tile == rightEntrance.Contains(tile);
        //return rightEntrance.Contains(tile);
        //.Contains requires "using System.Linq;"
    }



    // NOT
    bool Check_notTopEntrance(TileBase tile)
    {
        if (checkSelf) return tile != null;
        else return tile != null && tile != this && tile != topEntrance.Contains(tile);
    }

    bool Check_notBottomEntrance(TileBase tile)
    {
        if (checkSelf) return tile != null;
        else return tile != null && tile != this && tile != bottomEntrance.Contains(tile);
    }

    bool Check_notLeftEntrance(TileBase tile)
    {
        if (checkSelf) return tile != null;
        else return tile != null && tile != this && tile != leftEntrance.Contains(tile);
    }

    bool Check_notRightEntrance(TileBase tile)
    {
        if (checkSelf) return tile != null;
        else return tile != null && tile != this && tile != rightEntrance.Contains(tile);
    }

}