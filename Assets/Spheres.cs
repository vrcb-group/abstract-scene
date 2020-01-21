using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spheres : MonoBehaviour
{
    public GameObject Sphere;
    public int amount = 2000;
    public float lifetime = 0.3f;
    public int x;
    List<GameObject> spherePool;

    void Start()
    {
        spherePool = new List<GameObject>();

        for (int i = 0; i < amount; i++)
        {
            GameObject sp = (GameObject)Instantiate(Sphere, new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-11.0f, 15.0f), Random.Range(-10.0f, 10.0f)), Quaternion.identity);
            spherePool.Add(sp);
        }

        InvokeRepeating("MoveSphere1", 0, 0.3f);
        InvokeRepeating("MoveSphere2", 0.5f, 0.5f);
    }

    void MoveSphere1()
    {
        for (int i = 1; i < amount/2; i++)
        {
            spherePool[i].SetActive(false);
            spherePool[i].transform.position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-11.0f, 15.0f), Random.Range(-10.0f, 10.0f));
            spherePool[i].SetActive(true);
        }
    }

    void MoveSphere2()
    {
        for (int i = amount/2; i < amount; i++)
        {
            spherePool[i].SetActive(false);
            spherePool[i].transform.position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-11.0f, 15.0f), Random.Range(-10.0f, 10.0f));
            spherePool[i].SetActive(true);
        }
    }

}
