using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField]
    private float SpinSpeed;
    [SerializeField]
    private float m_Radius;
    [SerializeField]
    private AsteroidSize m_Size = AsteroidSize.Large;
    [SerializeField]
    private Transform m_child;
    public float Radius => m_Radius;

    public AsteroidSize Size
   {
        get
        {
            return m_Size;
        }
        set
        {
            m_Size = value;
            int sizeIndex = (int)m_Size;
            float asteroidScale = FindObjectOfType<Spawner>().AsteroidSizes[sizeIndex];
            Vector3 newScale = new Vector3(asteroidScale,asteroidScale,asteroidScale);
            transform.localScale = newScale;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        float angle = Random.Range(0, 360);
        SpinSpeed = Random.Range(-50.0f, 50.0f);
        Vector3 eulerAngles = new Vector3(0, angle, 0);
        transform.Rotate(eulerAngles);
        //m_Child = m_Transform.GetChild(0);

    }

    

    // Update is called once per frame
    void Update()
    {
        m_child.Rotate(new Vector3(0, SpinSpeed * Time.deltaTime, 0));

        Vector3 start = transform.position;
        Vector3 end = transform.position + new Vector3(1, 0, 0) * m_Radius;
        Debug.DrawLine(start, end);
    }

    public enum AsteroidSize
    {
        Small,
        Medium,
        Large
    }



}
