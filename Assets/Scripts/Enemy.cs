using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float rotatioSpeed = 40f;

    [SerializeField]
    private float enemySpeed = 5.0f;

    [SerializeField]
    private float coolDown = 3.0f;


    [SerializeField]
    private float currentTime;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        transform.Rotate(Vector3.up * Random.Range(-rotatioSpeed, rotatioSpeed));

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > coolDown)
        {
            float angleY = Random.Range(-rotatioSpeed, rotatioSpeed);
            transform.Rotate(Vector3.up * angleY);
            Debug.Log(angleY);

    currentTime = 0;
        }
        transform.Translate(transform.forward * enemySpeed * Time.deltaTime);
    }
}
