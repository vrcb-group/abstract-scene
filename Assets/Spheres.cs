using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spheres : MonoBehaviour
{
    public GameObject Sphere;
    public int amount = 2000;
    List<GameObject> spherePool;

    void Start()
    {
        spherePool = new List<GameObject>();

        for (int i = 0; i < amount; i++)
        {
            GameObject sp = (GameObject)Instantiate(Sphere, new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-11.0f, 15.0f), Random.Range(-10.0f, 10.0f)), Quaternion.identity);
            spherePool.Add(sp);
        }

        InvokeRepeating("MoveSphere", 0f, 3f);
    }

    void MoveSphere()
    {
        for (int i = 0; i < amount; i++)
        {
            spherePool[i].SetActive(false);
            spherePool[i].transform.position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-11.0f, 15.0f), Random.Range(-10.0f, 10.0f));
            spherePool[i].SetActive(true);
        }
    }

}
