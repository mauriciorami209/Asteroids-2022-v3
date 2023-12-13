using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Se crea una lista con objetos tipo T que se inicializan en el start y son de tamaño fijo
public class Pool<T> where T : MonoBehaviour
{
    private List<T> m_Pool;

    public Pool(int size, GameObject prefab)
    {
        m_Pool = new List<T>();
        for (var i = 0; i<size; i++)
        {
            var gameObject = GameObject.Instantiate(prefab);
            var poolObject = gameObject.GetComponent<T>();
            gameObject.SetActive(false);

            m_Pool.Add(poolObject);
        }

    }

    public GameObject GetObject()
    {
        for (var i=0; i<m_Pool.Count; i++)
        {
            if (!m_Pool[i].gameObject.activeSelf)
            {
                m_Pool[i].gameObject.SetActive(true);
                return m_Pool[i].gameObject;
            }
        }

        return null;
    }

    public void ReturnObject(T poolObject)
    {
        poolObject.gameObject.SetActive(false);
    }

}
