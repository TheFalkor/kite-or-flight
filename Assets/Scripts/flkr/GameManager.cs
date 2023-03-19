using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flkr
{
    public class GameManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private List<Ground> groundList = new List<Ground>();
        [SerializeField] private Player player;

        [Header("Runtime Variables")]
        [SerializeField] private float speed = 8;


        void Start()
        {
            foreach (Ground g in groundList)
                g.SetSpeed(speed);
        }

        void Update()
        {
            player.Tick(Time.deltaTime);

            foreach (Ground g in groundList)
                g.MoveGround(Time.deltaTime);

            speed += 0.5f * Time.deltaTime;

            foreach (Ground g in groundList)
                g.SetSpeed(speed);
        }
    }
}