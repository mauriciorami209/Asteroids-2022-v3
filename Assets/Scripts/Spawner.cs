using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AsteroidController;

public class Spawner : MonoBehaviour
{
    // Reference to the asteroid prefab
    [SerializeField]
    private GameObject m_AsteroidePrefab;

    // The maximum number of asteroids that should be spawned
    [SerializeField]
    private int m_MaxAsteroids;

    [SerializeField]
    private float[] m_AsteroidSizes;

    [SerializeField]
    private float SpawnInterval = 2.0f;

    // Keeps track of the number of asteroids that have been spawned
    private int AsteroidNumber = 0;

    public float [] AsteroidSizes
    {
        get
        {
            return m_AsteroidSizes;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Invokes the Spawn method repeatedly, with an initial delay of 2 seconds, and a repeating interval of 2 seconds
        InvokeRepeating("Spawn", SpawnInterval, SpawnInterval);

    }

   // nameof(Spawn)
    private void Spawn()
    {
        // If we haven't spawned the maximum number of asteroids yet
        if (AsteroidNumber < m_MaxAsteroids)
        {
            // Get a random position within a certain range
            Vector3 randomPosition = new Vector3(Random.Range(-15.0f, 15.0f), 0, Random.Range(-5.0f, 5.0f));
            // Get a random rotation on the Y axis
            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            // Instantiate the asteroid at the random position and rotation
            Instantiate(m_AsteroidePrefab, randomPosition, randomRotation);
            // Increment the number of asteroids that have been spawned
            AsteroidNumber++;
        }
        else
        {
            // If we have spawned the maximum number of asteroids, stop invoking the Spawn method
            CancelInvoke("Spawn");
        }
    }

    public void SpawnChildAsteroids(Vector3 asteroidPosition, AsteroidSize size)
    {
        int max_Clones = 2;
        if (size == AsteroidSize.Small)
        {
            Debug.Log("found a small astoroid");
            return;
        }
            

        AsteroidSize newSize = AsteroidSize.Large;
        float scale = 1;


        if (size == AsteroidSize.Large)
        {
            newSize = AsteroidSize.Medium;
            max_Clones = 2;
           // scale = m_AsteroidSizes[1];
        }
        else if (size == AsteroidSize.Medium)
        {
            newSize = AsteroidSize.Small;
            max_Clones = 1;
          //  scale = m_AsteroidSizes[0];
        }

        scale = m_AsteroidSizes[(int)newSize];


        for (int i = 0; i < max_Clones; i++)
        {
            GameObject copy = Instantiate(m_AsteroidePrefab);
            copy.transform.position = asteroidPosition;
            copy.GetComponent<AsteroidController>().Size = newSize;
            

        }


    }
}
