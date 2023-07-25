using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField]
    private KeyCode m_KeyMoveForward;

    private MovementController m_MovementController;

    [SerializeField]
    private KeyCode m_KeyMoveLeft;

    [SerializeField]
    private KeyCode m_KeyMoveRight;

    [SerializeField]
    private KeyCode m_KeyShoot;

    
    [SerializeField]
    private float m_rotationSpeed;

    private Transform _currentPos;
    public GameObject bulletPrefab;
    public float bulletSpeed = 100.0f;
    private float m_SpeedIncrement = 1.0f;

    [SerializeField]
    public float m_Radius;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the Transform component that represents the current position of the space ship atte: Chat GPT
        _currentPos = transform;

       // m_MovementController = this.gameObject.GetComponent<MovementController>();
        m_MovementController = GetComponent<MovementController>();

    }

    public float Radius  // Property
    {
        set => m_Radius = value;
        get => m_Radius;
    }

    // Update is called once per frame
   private void Update()
    {
        if (Input.GetKey(m_KeyMoveForward))
        {
            m_MovementController.speed += m_SpeedIncrement;
        }
        if (Input.GetKey(m_KeyMoveRight))
        {
            Vector3 eulerAngles = new Vector3(0, 1, 0);
            float rotationSpeed = m_rotationSpeed * Time.deltaTime;
            transform.Rotate(eulerAngles * rotationSpeed);
        }
        if (Input.GetKey(m_KeyMoveLeft))
        {
            Vector3 eulerAngles = new Vector3(0, -1, 0);
            float rotationSpeed = m_rotationSpeed * Time.deltaTime;
            transform.Rotate(eulerAngles * rotationSpeed);

        }
        if (Input.GetKeyDown(m_KeyShoot))
        {
            var chumbimba = Instantiate(bulletPrefab, _currentPos.position, _currentPos.rotation);
            //chumbimba.GetComponent<Rigidbody2D>().velocity = _currentPos.up * bulletSpeed * Time.deltaTime;

        }
        
    }
}
