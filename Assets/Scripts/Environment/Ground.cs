using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flkr
{
    public class Ground : MonoBehaviour
    {
        [Header("Runtime Variables")]
        private float speed;


        void Start()
        {

        }

        public void MoveGround(float deltaTime)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-20, -4), speed * deltaTime);

            if (transform.position == new Vector3(-20, -4))
            {
                transform.position = new Vector2(20, -4);
            }
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }
    }
}