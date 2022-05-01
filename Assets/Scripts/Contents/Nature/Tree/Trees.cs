using UnityEngine;

using CraftSurvival.Contents;

namespace CraftSurvival.Contents.Nature
{
    public class Trees : Structure
    {
        public override void Init()
        {
            base.Init();
            
            // Set variables
            fallDestroy = true;
        }

        public static GameObject Get(TreeType treeType)
        {
            var prefab = Resources.Load<GameObject>("Tree_" + (
                treeType == TreeType.normal ? "normal" :
                treeType == TreeType.ice ? "ice" :
                treeType == TreeType.glow ? "glow" :
                /* TreeType.fire */"fire"
            ));
            return Instantiate(prefab);
        }

    }
    public enum TreeType
    {
        normal, ice, glow, fire
    }
}