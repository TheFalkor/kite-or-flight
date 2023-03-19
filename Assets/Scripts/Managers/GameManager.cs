using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flkr
{
    public class GameManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject obstaclePrefab;
        [SerializeField] private List<Ground> groundList = new List<Ground>();
        [SerializeField] private Player player;

        [Header("Variables")]
        private float spawnSpeed = 0;

        [Header("Runtime Variables")]
        private List<MovingObstacle> obstacles = new List<MovingObstacle>();
        [SerializeField] private float speed = 8;
        

        void Start()
        {
            foreach (Ground g in groundList)
                g.SetSpeed(speed);
        }

        void Update()
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                if (obstacles[i] == null)
                {
                    obstacles.RemoveAt(i);
                    i--;
                }    
            }

            player.Tick(Time.deltaTime);

            foreach (Ground g in groundList)
                g.MoveGround(Time.deltaTime);

            speed += 0.5f * Time.deltaTime;

            foreach (Ground g in groundList)
                g.SetSpeed(speed);

            spawnSpeed -= Time.deltaTime;

            if (spawnSpeed <= 0)
            {
                spawnSpeed = 1.5f;
                SpawnObstacle();
            }
        }

        private void SpawnObstacle()
        {
            MovingObstacle obs = Instantiate(obstaclePrefab, new Vector2(10, Random.Range(-0.5f, 4f)), Quaternion.identity).GetComponent<MovingObstacle>();
            obstacles.Add(obs);

            obs.SetSpeed(Random.Range(0.5f, 1f) * speed);
        }
    }
}