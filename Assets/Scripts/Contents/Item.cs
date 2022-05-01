using System;

using UnityEngine;

namespace CraftSurvival.Contents
{
    public class Item 
    {
        public virtual string name { get; protected set; }
        public virtual string description { get; protected set; }
        public virtual bool stackable { get; protected set; }
        public virtual Sprite sprite { get; protected set; }
        private int a = 1;
        public virtual int amount 
        {
            get => a;
            set => a = stackable ? value : a;
        }
        public Item (string name, string description, bool stackable, Sprite sprite = null)
        {
            this.name = name;
            this.description = description;
            this.stackable = stackable;
            this.sprite = sprite;
        }
    }
}