using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;

namespace CraftSurvival.Contents
{
    [Serializable] public class StringTileDictionary : SerializableDictionary<string, Tile> {};
    [Serializable] public class StringItemDictionary : SerializableDictionary<string, Item> {};
    public class ContentLoader : MonoBehaviour
    {
        [SerializeField] private StringTileDictionary initTiles;
        [SerializeField] private GameObject cube;
        private void Awake() {
            foreach(var set in initTiles)
            {
                set.Value.gameObject = cube;
                Vars.tiles.TryAdd(set.Key, set.Value);
            }
        }

        public void Load ()
        {
            //아 그래서 뭘 하면 되죠 제가
            //Vars.items.Add("")
            Vars.items.Add("아이템 이름", new Item("아이템 이름", "아이템 설명", true, null));
        }
    }
}
