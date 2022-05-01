using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CraftSurvival
{
    public class Structure : MonoBehaviour
    {
        private bool inited = false;
        public static readonly float destroyY = -10;
        public bool fallDestroy { get; protected set; }

        public virtual void Init ()
        {
            if(inited) return;
            inited = true;

            // set variables
            fallDestroy = true;
        }
        protected virtual void LateUpdate()
        {
            if(this.transform.position.y < destroyY && fallDestroy)
            {
                Destroy(this);
            }
        }
    }
}
