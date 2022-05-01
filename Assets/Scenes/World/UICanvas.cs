using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using CraftSurvival.Contents;

namespace CraftSurvival.Scene.WorldScene
{
    public sealed class UICanvas : MonoBehaviour, 
                            IPointerClickHandler,
                            IPointerDownHandler,
                            IPointerMoveHandler,
                            IPointerUpHandler,
                            IPointerEnterHandler,
                            IPointerExitHandler
    {
        public static bool pointerInCanvas { get; private set; }
        [SerializeField] private Player playerData;
        private GameObject inventoryPannel;
        private bool barClicked = false;

        private void Awake()
        {
            pointerInCanvas = false;
            inventoryPannel = transform.Find("InventoryPannel").gameObject;
        }

        public void OnPointerClick(PointerEventData eventData) 
        {
        }

        private Vector3 pannelC, pointerOC;
        public void OnPointerDown(PointerEventData eventData) 
        {
            var target = eventData.pointerCurrentRaycast.gameObject;
            switch (target.name)
            {
                case "Bar":
                    barClicked = true;
                    pannelC = target.transform.parent.position;
                    pointerOC = Input.mousePosition;
                break;

                default:
                break;
            }
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if(eventData.pointerCurrentRaycast.gameObject == null) return;

            switch (eventData.pointerCurrentRaycast.gameObject.name)
            {
                case "Bar":
                    if(barClicked) 
                    {
                        inventoryPannel.transform.position = pannelC + (Input.mousePosition - pointerOC);
                    }
                break;

                default:
                break;
            }
        }

        public void OnPointerUp (PointerEventData eventData) 
        {
            barClicked = false;
        }

        public void Disable (GameObject obj)
        {
            RefreshInventoryPannel();
            //obj.SetActive(false);
        }
        
        public void OnPointerEnter (PointerEventData eventData) 
        {
            pointerInCanvas = true;
        }

        public void OnPointerExit (PointerEventData eventData) 
        {
            pointerInCanvas = false;
        }

        private static int preISize = 0;
        [SerializeField] private GameObject iVar;
        public void RefreshInventoryPannel ()
        {
            if(preISize != playerData.inventorySize)
            {
                var iVarSize = iVar.transform.childCount;
                var iContainer = iVar.transform.parent;
                var inventory = playerData.inventory;

                foreach(var obj in iContainer.transform)
                {
                    if(typeof(GameObject).IsInstanceOfType(obj))
                    {
                        var bar = obj as GameObject;
                        if(bar.name != "InvBar") Destroy(bar);
                    }
                }

                preISize = playerData.inventorySize;
                for(int i = 0, n = playerData.inventorySize ; i < n; i += 7 )
                {
                    if(i <= n) //휴먼 제가 뭘 하면 될까요 여긴 const 없음????
                    {
                        var bar = Instantiate(iVar, iContainer);
                        bar.SetActive(true);
                        int delSize = n % iVarSize;
                        
                        if(i == 0 && delSize > 0)
                        {
                            for(int l = 0; l < delSize; l++)
                            {
                                Destroy(bar.transform.GetChild(iVarSize - l - 1).gameObject);
                            }
                        }
                    }
                }
            }
        }
    }
}
