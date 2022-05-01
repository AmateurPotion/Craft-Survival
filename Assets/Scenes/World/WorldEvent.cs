using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

using CraftSurvival.Contents.Nature;

namespace CraftSurvival.Scene.WorldScene
{
    public class WorldEvent : MonoBehaviour
    {
        [SerializeField] private GameObject player, structures;
        [SerializeField] private Tilemap map;

        private void Awake() {
        }

        private void Start() {
            this.SetTiles(-10, 10, -10, 10, "leaf_1");
            
            //Spawn(5, 5, Trees.Get(TreeType.normal), false);
        }

        private float ch = 10;
        private void LateUpdate () {
            var ppos = player.transform.position;
            Camera.main.transform.position = new Vector3(ppos.x, ppos.y + ch, ppos.z);

            if(Input.GetAxis("Mouse ScrollWheel") != 0 && !UICanvas.pointerInCanvas)
            {
                ch -= Input.GetAxis("Mouse ScrollWheel");
            }
        }

        public void SetTiles (int startX, int endX, int startY, int endY, string tileName)
        {
            this.SetTiles(startX, endX, startY, endY, Vars.tiles.ContainsKey(tileName) ? Vars.tiles[tileName] : Vars.tiles["stone"]);
        }
        public void SetTiles (int startX, int endX, int startY, int endY, TileBase tile)
        {
            for(int y = startY; y < endY; y++)
            {
                for(int x = startX; x < endX; x++)
                {
                    this.SetTile(x, y, tile);
                }
            }
        }

        public void SetTile (int x, int y, string tileName)
        {
            this.SetTile(x, y, Vars.tiles.ContainsKey(tileName) ? Vars.tiles[tileName] : Vars.tiles["stone"]);
        }

        public void SetTile (int x, int y, TileBase tile)
        {
            this.map.SetTile(new Vector3Int(x, y), tile);
        }

        public GameObject Spawn (int x, int y, GameObject obj, bool clone = true)
        {
            var spawned = clone ? Instantiate(obj, structures.transform) : obj;
            spawned.transform.position = new Vector3(x, 0.1f, y);
            return spawned;
        }
    }
}
