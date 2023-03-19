using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flkr
{
    public class MovingObstacle : MonoBehaviour
    {
        private float speed;


        void Start()
        {

        }

        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-20, transform.position.y), speed * Time.deltaTime);
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("collider");
            Destroy(gameObject);
        }
    }
}
