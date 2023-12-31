using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Transform m_transform;
    [SerializeField]
    private Vector3 m_direccion;
    [SerializeField]
    private float m_speed;
    [SerializeField]
    private float m_MaxSpeed;
    [SerializeField]
    private bool m_Isaccelerated = false;
    [SerializeField]
    private float m_Damping = 0.5f;

    // Start is called before the first frame update


    public Vector3 direction
    {
        get { return m_direccion.normalized; }
        set { m_direccion = value; }
    }

    public float speed
    {
        get { return m_speed; }
        set { m_speed = value; }
    }
    void Start()
    {
        m_transform = transform;
       // m_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Isaccelerated)
        {
            m_speed = m_speed - m_Damping;
            if (m_speed < 0)
            {
                m_speed = 0;
            }
            if(m_speed >= m_MaxSpeed)
            {
                m_speed = m_MaxSpeed;
            }

            // Estructura matematica para reemplazar los ifs
            //m_speed = Mathf.Clamp(m_speed, 0, m_MaxSpeed);
        }
        m_transform.Translate(m_direccion * speed * Time.deltaTime);

    }
}
