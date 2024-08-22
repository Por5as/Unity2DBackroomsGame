
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

namespace UnityEditor
{
    [CustomEditor(typeof(AdvancedRuleTile))]
    [CanEditMultipleObjects]
    public class AdvancedRuleTileEditor : RuleTileEditor
    {


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

                case AdvancedRuleTile.Neighbor.Top:
                    GUI.DrawTexture(rect, topIcon);
                    return;

                case AdvancedRuleTile.Neighbor.Bottom:
                    GUI.DrawTexture(rect, bottomIcon);
                    return;

                case AdvancedRuleTile.Neighbor.Left:
                    GUI.DrawTexture(rect, leftIcon);
                    return;

                case AdvancedRuleTile.Neighbor.Right:
                    GUI.DrawTexture(rect, rightIcon);
                    return;


                
                case AdvancedRuleTile.Neighbor.NotTop:
                    GUI.DrawTexture(rect, nottopIcon);
                    return;

                case AdvancedRuleTile.Neighbor.NotBottom:
                    GUI.DrawTexture(rect, notbottomIcon);
                    return;

                case AdvancedRuleTile.Neighbor.NotLeft:
                    GUI.DrawTexture(rect, notleftIcon);
                    return;

                case AdvancedRuleTile.Neighbor.NotRight:
                    GUI.DrawTexture(rect, notrightIcon);
                    return;
                
            }

            base.RuleOnGUI(rect, position, neighbor);
        }
    }
}

#endif