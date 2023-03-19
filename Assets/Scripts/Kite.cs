using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paul
{
    public class Kite : MonoBehaviour
    {
        [SerializeField] float min;
        [SerializeField] float max;
        [SerializeField] float speed;

        void Start()
        {

        }

        void Update()
        {
            transform.position += Vector3.up * Input.GetAxis("Mouse Y") * speed;

            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, min, max), transform.position.z);
        }
    }

}
