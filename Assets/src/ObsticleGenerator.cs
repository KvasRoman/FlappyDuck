using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public static ObstacleGenerator Instance;
    [SerializeField] Obstacle Obstacle;
    [SerializeField] ScoreTriger ScorePointTirger;
    [SerializeField] GameObject TopSpawnAnchor;
    [SerializeField] GameObject BottomSpawnAnchor;

    [SerializeField] float baseSpeed;

    [SerializeField] float obstacleSpawnInterval = 0.3f;
    

    private float baseSafeWindowHeight = 4f;
    private float difficultyLevel = 1;
    private int initObsticlesQuantity = 3;
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("ObstacleGenerator should be only one");
        }
        StartCoroutine(initObstacle());
    }

    public void AddObstacles()
    {
        var firstObstacle = GameObject.Instantiate(Obstacle);
        //flip Obstacle
        firstObstacle.transform.localScale = new Vector3(1, -1, 1);
        var secondObstacle = GameObject.Instantiate(Obstacle);
        var scoreTrigger = GameObject.Instantiate(ScorePointTirger);
        //set Obstacles position;
        var obstaclePivot = (TopSpawnAnchor.transform.position.y - (baseSafeWindowHeight / 2) 
            + BottomSpawnAnchor.transform.position.y - (baseSafeWindowHeight / 2)) * Random.value;
        var fistObstaclePosition = TopSpawnAnchor.transform.position;
        fistObstaclePosition.y = obstaclePivot + ((baseSafeWindowHeight / 2) / difficultyLevel);
        var secondObstaclePosition = BottomSpawnAnchor.transform.position;
        secondObstaclePosition.y = obstaclePivot - ((baseSafeWindowHeight / 2) / difficultyLevel);

        var scoreTrigerPosition = TopSpawnAnchor.transform.position;
        scoreTrigerPosition.y = obstaclePivot;

        scoreTrigger.transform.position = scoreTrigerPosition;

        scoreTrigger.SetVelocity(difficultyLevel * baseSpeed);
        firstObstacle.SetVelocity(difficultyLevel * baseSpeed);
        secondObstacle.SetVelocity(difficultyLevel * baseSpeed);



        firstObstacle.transform.position = fistObstaclePosition;
        secondObstacle.transform.position = secondObstaclePosition;

        difficultyLevel += 0.02f;
    }
    private IEnumerator initObstacle()
    {
        
        for(int i = 0; i < initObsticlesQuantity; i++)
        {
            yield return new WaitForSecondsRealtime(obstacleSpawnInterval);
            AddObstacles();
        }
        yield break;
    }
}
