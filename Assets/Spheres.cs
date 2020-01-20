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

        InvokeRepeating("MoveSphere", 0f, lifetime);
        //InvokeRepeating("RefreshTags", 0f, 3f);
    }

    void MoveSphere()
    {
        for (int i = 1; i < amount/100; i++)
        {
            x = amount % (Random.Range(1, amount));
            spherePool[x].SetActive(false);
            spherePool[x].transform.position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-11.0f, 15.0f), Random.Range(-10.0f, 10.0f));
            spherePool[x].SetActive(true);
        }
    }

}
