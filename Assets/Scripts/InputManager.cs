using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event OnKeyPressed OnShootKeyPressed; // Event declared
    public static event OnKeyPressed OnMoveKeyPressed;
    public static event OnRotateKeyPressed OnRotateKeyPressed;
    


    [SerializeField]
    public KeyCode m_ShootKey = KeyCode.Space;

    [SerializeField]
    public KeyCode m_MoveKey = KeyCode.UpArrow;

    [SerializeField]
    public KeyCode m_MoveRight = KeyCode.RightArrow;

    [SerializeField]
    public KeyCode m_Moveleft = KeyCode.LeftArrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(OnShootKeyPressed != null) // valida si el evento no ha sido subscrito todavia
               OnShootKeyPressed(); // se llama el evento como si fuera un metodo ejecute los metodos que se subscribieron
        }

        if (Input.GetKey(m_MoveKey))
        {
            if (OnMoveKeyPressed != null) // valida si el evento no ha sido subscrito todavia
                OnMoveKeyPressed();
        }

        if (Input.GetKey(m_MoveRight))
        {
            if (OnRotateKeyPressed != null) // valida si el evento no ha sido subscrito todavia
                OnRotateKeyPressed(1);
        }

        if (Input.GetKey(m_Moveleft))
        {
            if (OnRotateKeyPressed != null) // valida si el evento no ha sido subscrito todavia
                OnRotateKeyPressed(-1);
        }
    }
}

public delegate void OnKeyPressed(); // muestra el tipo de metodo que cabe dentro de este evento
public delegate void OnRotateKeyPressed( int dir);
