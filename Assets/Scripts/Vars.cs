using System;
using System.Collections.Generic;

using UnityEngine.Tilemaps;

using CraftSurvival.Contents;

namespace CraftSurvival
{
    public static class Vars
    {
        public readonly static Dictionary<string, Tile> tiles = new Dictionary<string, Tile>();
        public readonly static Dictionary<string, Item> items = new Dictionary<string, Item>();
        private static bool inited = false;
        public static void Init ()
        {
            if(!inited)
            {
                inited = true;
            }
        }
    }    
}