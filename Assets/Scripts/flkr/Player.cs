using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flkr
{
    public class Player : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Kite kite;


        void Start()
        {

        }

        public void Tick(float deltaTime)
        {
            if (Input.GetKey(KeyCode.W))
                kite.MoveUp(deltaTime);

            if (Input.GetKey(KeyCode.S))
                kite.MoveDown(deltaTime);
        }
    }
}