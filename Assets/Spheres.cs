using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spheres : MonoBehaviour
{
    public GameObject Sphere;
    public bool spheres = true;
    public int amount = 2000;
    List<GameObject> spherePool;

    void Start()
    {
        if(spheres)
        {
            spherePool = new List<GameObject>();
            for (int i = 0; i < amount; i++)
            {
                GameObject sp = (GameObject)Instantiate(Sphere, new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(0.5f, 8.0f), Random.Range(-7.0f, 7.0f)), Quaternion.identity);
                sp.SetActive(true);
                spherePool.Add(sp);
            }
        }
    }

}
