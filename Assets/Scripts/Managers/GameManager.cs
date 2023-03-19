using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform obstacleParent;
    [Space]
    private List<Ground> groundList = new List<Ground>();
    [SerializeField] private Player player;

    [Header("Variables")]
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

        speed += 0.2f * Time.deltaTime;

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
        Obstacle obs = Instantiate(obstaclePrefab, new Vector2(10, Random.Range(-0.5f, 4f)), Quaternion.identity, obstacleParent).GetComponent<Obstacle>();
        obstacles.Add(obs);

        obs.SetSpeed(Random.Range(0.5f, 1f) * speed);
    }
}
