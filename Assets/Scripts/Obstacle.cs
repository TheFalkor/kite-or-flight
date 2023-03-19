using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paul
{
    public class Obstacle : MonoBehaviour
    {
        void Start()
        {

        }

        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Kite"))
            {
                GameManager.Quit();
                Debug.Log("dog");

            }
        }
    }
}
