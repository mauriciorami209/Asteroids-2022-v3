using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    
    [SerializeField]
    private float fastSpeed = 10.0f;

    // Sobrescribir el método Update para un movimiento más rápido
    void Update()
    {
        // Lógica de movimiento más rápido para los FastEnemy
        transform.Translate(Vector3.forward * fastSpeed * Time.deltaTime);
    }
}


