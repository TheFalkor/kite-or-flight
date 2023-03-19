using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flkr
{ 
    public class Kite : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform topPoint;
        [SerializeField] private Transform bottomPoint;

        [Header("Setup")]
        [SerializeField] private float moveSpeed = 3;


        void Start()
        {
            UpdateRope();
        }
    
        public void MoveUp(float deltaTime)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 4), moveSpeed * deltaTime);
            UpdateRope();
        }

        public void MoveDown(float deltaTime)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -0.5f), moveSpeed * deltaTime);
            UpdateRope();
        }

        private void UpdateRope()
        { 
            float length = (topPoint.position - bottomPoint.position).magnitude;
            float angle = Mathf.Atan2(topPoint.position.y - bottomPoint.position.y, topPoint.position.x - bottomPoint.position.x);
        
            transform.GetChild(0).localScale = new Vector3(0.075f, length);
            transform.GetChild(0).position = (topPoint.position + bottomPoint.position) / 2;
            transform.GetChild(0).localEulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg - 47);
        }
    }
}
