using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spheres : MonoBehaviour
{
    public GameObject Sphere;

    void Start()
    {
        //for (int x= -10; x<10; x++)
        //{
        //    for (int y = -10; y < 10; y++)
        //    {
        //        for (int z = -10; z < 10; z++)
        //        {
        //            Instantiate(Sphere, new Vector3(x, y, z), Quaternion.identity);
        //        }
        //    }
        //}

        for (int i = 0; i < 2000; i++)
        {
            Instantiate(Sphere, new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-11.0f, 15.0f), Random.Range(-10.0f, 10.0f)), Quaternion.identity);
        } 
    }

    void Update()
    {
        
    }
}
