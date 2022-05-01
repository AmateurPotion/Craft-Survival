using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace CraftSurvival.Scene.WorldScene
{
    public class InventoryScroll : ScrollRect
    {
        private bool canDrag = true;
        public override void OnBeginDrag(PointerEventData eventData) 
        {
            base.OnBeginDrag(eventData);
            canDrag = eventData.pointerCurrentRaycast.gameObject == null || eventData.pointerCurrentRaycast.gameObject.name != "Checkmark";
        }
        public override void OnDrag(PointerEventData eventData)
        {
            if(canDrag) base.OnDrag(eventData);
        }
        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);
        }
    }

}