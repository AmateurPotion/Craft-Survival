using System;

using UnityEngine.Tilemaps;

namespace CraftSurvival.Worlds
{
    public struct Chunk
    {
        public readonly int size;
        private Tile[] tiles; 
        public Chunk(int size)
        {
            this.size = size;
            this.tiles = new Tile[size ^ 2];
        }

        public Chunk(int size, Tile[][] tileData): this(size)
        {

        }
    }
}