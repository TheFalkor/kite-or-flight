using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paul
{
    public class Player : MonoBehaviour
    {
        [SerializeField] float speed;


        void Update()
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
        }
    }
}
