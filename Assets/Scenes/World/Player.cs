using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CraftSurvival.Contents;

namespace CraftSurvival.Scene.WorldScene
{
    public class Player : MonoBehaviour
    {
        public float defaultSpeed = 0.1f, runMultiply = 2f, jump = 3;
        private int iS = 10;
        public int inventorySize {
            get => iS;
            set {

            }
        }
        public List<Item> inventory = new List<Item>();

        private void Update()
        {
            var playerSpeed = defaultSpeed * (Input.GetKey(KeyCode.LeftShift) ? runMultiply : 1);
            transform.Translate(new Vector3(Input.GetAxis("Horizontal") * playerSpeed, 0.0f, Input.GetAxis("Vertical") * playerSpeed));
        
            if(Input.GetKeyDown(KeyCode.Space)) GetComponent<Rigidbody>().AddForce(new Vector3(0, jump, 0));
        }
    }
}