using UnityEngine;

public class MachineGun1 : MonoBehaviour
{
    private Transform _currentPos;
    public GameObject bulletPrefab;
    public float bulletSpeed = 100.0f;

    void Start()
    {
        _currentPos = GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        {
           // var chumbimba = Instantiate(bulletPrefab, _currentPos.position, _currentPos.rotation);
           // chumbimba.GetComponent<Rigidbody>().velocity = _currentPos.up * bulletSpeed * Time.deltaTime;

        }
    }
}