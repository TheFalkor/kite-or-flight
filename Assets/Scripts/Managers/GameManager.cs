using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private Transform obstacleParent;
    [Space]
    private List<Ground> groundList = new List<Ground>();
    [SerializeField] private Player player;

    [Header("Variables")]
    [SerializeField] private float maxSpeed = 25;
    [SerializeField] private float speedIncrease = 0.1f;
    private float spawnSpeed = 0;

    [Header("Runtime Variables")]
    private List<Obstacle> obstacles = new List<Obstacle>();
    [SerializeField] private float speed = 8;


    private void Awake()
    {
        ServiceLocator.Register(GetComponent<AudioCore>());
    }

    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ground"))
            groundList.Add(go.GetComponent<Ground>());

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

        if (speed < maxSpeed)
            speed += speedIncrease * Time.deltaTime;

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
        Obstacle obs = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)], new Vector2(20, Random.Range(-0.5f, 4f)), Quaternion.identity, obstacleParent).GetComponent<Obstacle>();
        obstacles.Add(obs);

        obs.SetSpeed(speed);
    }
}
