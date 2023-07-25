using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundChecker : MonoBehaviour
{
    private Transform m_Transform;
    [SerializeField]
    private float m_Toplimit;
    [SerializeField]
    private float m_BottomLimit;
    [SerializeField]
    private float m_leftLimit;
    [SerializeField]
    private float m_rightLimit;
    // Start is called before the first frame update
    void Start()
    {
        m_Transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        var newPosition = m_Transform.position;
        if (m_Transform.position.z > m_Toplimit)
        {
            newPosition.z = m_BottomLimit;
        }
        else if (m_Transform.position.z < m_BottomLimit)
        {
            newPosition.z = m_Toplimit;
        }

        if (m_Transform.position.x > m_rightLimit)
        {
            newPosition.x = m_leftLimit;
        }
        else if (m_Transform.position.x < m_leftLimit)
        {
            newPosition.x = m_rightLimit;
        }

        m_Transform.position = newPosition;
    }
}
