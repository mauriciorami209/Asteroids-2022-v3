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
            

    }

    private void LoadScene()

    {
        if (GameManager.Lives > 0)
            SceneManager.LoadScene("Asteroids 2022 v2 main");
        else
            SceneManager.LoadScene("Game Over");
    }


    private bool HasCollide(AsteroidController asteroid)
    {
        var shipRadius = ship.Radius;
       // var asteroidPosition = asteroids.transform.position;

        var collisionDistance = asteroid.Radius + shipRadius;

        var currentDistance = Vector3.Distance(asteroid.transform.position, ship.transform.position);

        return (currentDistance < collisionDistance);
       

    }
}
    