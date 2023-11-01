using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    
    SpaceShip ship;
    AsteroidController [] asteroids;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ship = FindObjectOfType<SpaceShip>();
        asteroids = FindObjectsOfType<AsteroidController>();


        if (ship != null)
        {
            for(int i = 0; i < asteroids.Length; i++)
            {
                AsteroidController asteroid = asteroids[i];
            
                 if (HasCollide(asteroid))
            
                {
                    Destroy(ship.gameObject);
                    GameManager.Lives -= 1;
                    Invoke("LoadScene", 2);
                    UIManager canvasManager = FindObjectOfType<UIManager>();
                    canvasManager.HideLive(GameManager.Lives);

                }
            }
        }
        UpdateCollisions();
    }
    
    private void UpdateCollisions()
    {
        var colliders = FindObjectsOfType<CustomCollider>();
        ColliderDebugger.DrawColliders(colliders);
        
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int j = i+1; j< colliders.Length; j++)
            {
                var colliderA = colliders[i];
                var colliderB = colliders[j];

                if (colliderA != colliderB && Vector3.Distance(colliderA.transform.position, colliderB.transform.position)< (colliderA.Radius + colliderB.Radius))
                {
                    if (colliderA.Type == CustomCollider.ColliderType.Ship && colliderB.Type == CustomCollider.ColliderType.Bullet ||
                         colliderA.Type == CustomCollider.ColliderType.Bullet && colliderB.Type == CustomCollider.ColliderType.Ship)
                        continue;
                    if (colliderA.Type == CustomCollider.ColliderType.Asteroid && colliderB.Type == CustomCollider.ColliderType.Asteroid)
                        continue;

                    Debug.Log($"Collision between {colliderA.Type} and {colliderB.Type}");

                }

            }

        }
    }

    private void LoadScene()

    {
        if (GameManager.Lives > 0)
            

        GameManager.LoadScene("Asteroids 2022 v2 main");
        else
            GameManager.LoadScene("Game Over");
    }


    private bool HasCollide(AsteroidController asteroid)
    {
        CustomCollider shipCollider = ship.GetComponent<CustomCollider>();
        CustomCollider asteroidCollider = asteroid.GetComponent<CustomCollider>();

        var collisionDistance = shipCollider.Radius + asteroidCollider.Radius;

        var currentDistance = Vector3.Distance(asteroid.transform.position, ship.transform.position);

        return (currentDistance < collisionDistance);

        /*
        var shipRadius = ship.Radius;

        var collisionDistance = asteroid.Radius + shipRadius;

        var currentDistance = Vector3.Distance(asteroid.transform.position, ship.transform.position);

        return (currentDistance < collisionDistance);
       */

    }
}
    