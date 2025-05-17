
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

namespace UnityEditor
{
    [CustomEditor(typeof(AdvancedRuleTileOld))]
    [CanEditMultipleObjects]
    public class AdvancedRuleTileEditorOld : RuleTileEditor
    {

        // public Texture2D AnyIcon;
        // public Texture2D NothingIcon;

        /*
        public Texture2D Opened_Icon;
        public Texture2D BL_Icon;
        public Texture2D BR_Icon;
        public Texture2D BRL_Icon;
        public Texture2D RL_Icon;
        public Texture2D TB_Icon;
        public Texture2D TBL_Icon;
        public Texture2D TBR_Icon;
        public Texture2D TL_Icon;
        public Texture2D TR_Icon;
        public Texture2D TRL_Icon;
        */

        public Texture2D topIcon;
        public Texture2D bottomIcon;
        public Texture2D leftIcon;
        public Texture2D rightIcon;


        public Texture2D nottopIcon;
        public Texture2D notbottomIcon;
        public Texture2D notleftIcon;
        public Texture2D notrightIcon;


        public override void RuleOnGUI(Rect rect, Vector3Int position, int neighbor)
        {
            switch (neighbor)
            {

                case AdvancedRuleTileOld.Neighbor.topEntrance:
                    GUI.DrawTexture(rect, topIcon);
                    return;

                case AdvancedRuleTileOld.Neighbor.bottomEntrance:
                    GUI.DrawTexture(rect, bottomIcon);
                    return;

                case AdvancedRuleTileOld.Neighbor.leftEntrance:
                    GUI.DrawTexture(rect, leftIcon);
                    return;

                case AdvancedRuleTileOld.Neighbor.rightEntrance:
                    GUI.DrawTexture(rect, rightIcon);
                    return;



                case AdvancedRuleTileOld.Neighbor.notTopEntrance:
                    GUI.DrawTexture(rect, nottopIcon);
                    return;

                case AdvancedRuleTileOld.Neighbor.notBottomEntrance:
                    GUI.DrawTexture(rect, notbottomIcon);
                    return;

                case AdvancedRuleTileOld.Neighbor.notLeftEntrance:
                    GUI.DrawTexture(rect, notleftIcon);
                    return;

                case AdvancedRuleTileOld.Neighbor.notRightEntrance:
                    GUI.DrawTexture(rect, notrightIcon);
                    return;


                    /*
                    case AdvancedRuleTile.Neighbor.Any:
                        GUI.DrawTexture(rect, AnyIcon);
                        return;

                    case AdvancedRuleTile.Neighbor.Nothing:
                        GUI.DrawTexture(rect, NothingIcon);
                        return;
                    */

                    /*
                    case AdvancedRuleTile.Neighbor.Opened:
                        GUI.DrawTexture(rect, Opened_Icon);
                        return;

                    case AdvancedRuleTile.Neighbor.BL:
                        GUI.DrawTexture(rect, BR_Icon);
                        return;

                    case AdvancedRuleTile.Neighbor.BR:
                        GUI.DrawTexture(rect, BRL_Icon);
                        return;

                    case AdvancedRuleTile.Neighbor.BRL:
                        GUI.DrawTexture(rect, TB_Icon);
                        return;

                    case AdvancedRuleTile.Neighbor.RL:
                        GUI.DrawTexture(rect, RL_Icon);
                        return;

                    case AdvancedRuleTile.Neighbor.TB:
                        GUI.DrawTexture(rect, TB_Icon);
                        return;

                    case AdvancedRuleTile.Neighbor.TBL:
                        GUI.DrawTexture(rect, TBL_Icon);
                        return;

                    case AdvancedRuleTile.Neighbor.TBR:
                        GUI.DrawTexture(rect, TBR_Icon);
                        return;

                    case AdvancedRuleTile.Neighbor.TL:
                        GUI.DrawTexture(rect, TL_Icon);
                        return;

                    case AdvancedRuleTile.Neighbor.TR:
                        GUI.DrawTexture(rect, TR_Icon);
                        return;

                    case AdvancedRuleTile.Neighbor.TRL:
                        GUI.DrawTexture(rect,TRL_Icon);
                        return;
                    */
            }

            base.RuleOnGUI(rect, position, neighbor);
        }
    }
}

#endif
