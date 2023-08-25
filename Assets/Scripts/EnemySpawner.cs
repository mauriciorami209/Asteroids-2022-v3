using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject fastEnemyPrefab;

    [SerializeField]
    private Vector3 spawnPos;

    [SerializeField]
    private float spawnScore;

    [SerializeField]
    private float currentScore;

    private int countEnemy;


    // Start is called before the first frame update
    void Start()
    {
        countEnemy = 1;
        currentScore = spawnScore;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Score >= currentScore)
        {
            Instantiate(enemyPrefab, spawnPos, new Quaternion());
            currentScore = spawnScore * ++countEnemy;
            Instantiate(fastEnemyPrefab, spawnPos, new Quaternion());



        }
    }
}
