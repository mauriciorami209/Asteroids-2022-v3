using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float m_lifetime = 1.0f;
    [SerializeField]
    private float m_Radius;
    // Start is called before the first frame update
    void OnEnable()
    {
        //  Destroy(this.gameObject, m_lifetime);
        Invoke("ReturnBullet", m_lifetime);
        
    }

    public void ReturnBullet()
    {
        GameManager.BulletPool.ReturnObject(this);
    }

    // Update is called once per frame
    void Update()
    {
        
      //  var Radius = 0f;
     

        // {Asteroid1, Asteroid2,....AsteroidN}
        var asteroids = FindObjectsOfType<AsteroidController>();
        

        for (int i = 0; i < asteroids.Length; i++)
        {
            var asteroid = asteroids[i];
            if (HasCollide(asteroid))
            {
                GameManager.BulletPool.ReturnObject(this);
                Vector3 position = asteroid.transform.position;
                
               // AsteroidController asteroide = GetComponent<AsteroidController>();
               // asteroid.Size = AsteroidController.AsteroidSize.Large;

                Spawner asteroidSpawner = FindObjectOfType<Spawner>();
                asteroidSpawner.SpawnChildAsteroids(position, asteroid.Size);
                //     FindObjectOfType<Spawner>();

                GameManager.Score += 300;
                Destroy(asteroid.gameObject);
            }
              
        }

        // For testing
        var enemy = FindObjectsOfType<Enemy>();

        for (int j = 0; j < enemy.Length; j++)
        {
            var Enemy = enemy[j];
            if (HasCollide2(Enemy))
            {
                Destroy(gameObject);
                Destroy(Enemy.gameObject);
                GameManager.Score += 100;

            }
        }
        // For testing
    }
    private bool HasCollide(AsteroidController asteroid)
    {
        var asteroidRadius = asteroid.Radius;
        var asteroidPosition = asteroid.transform.position;
        var bulletPosition = transform.position;

        var collisionDistance = asteroidRadius + m_Radius;

        var currentDistance = Vector3.Distance(asteroidPosition, bulletPosition);

        return (currentDistance < collisionDistance);
       // if (currentDistance < collisionDistance)
       //  {
       //    return true;
       //}
       // return false;

    }

    //For testing
    private bool HasCollide2(Enemy enemy)
    {
        var enemyRadius = enemy.Radius;
        var enemyPosition = enemy.transform.position;
        var bulletPosition = transform.position;

        var collisionDistance = enemyRadius + m_Radius;

        var currentDistance = Vector3.Distance(enemyPosition, bulletPosition);

        return (currentDistance < collisionDistance);

      

    }
    //For testing

}
