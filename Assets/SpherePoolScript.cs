using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePoolScript : MonoBehaviour
{
    public GameObject SpherePool;
    public int amount = 100;
    List<GameObject> sphere;

    void Start()
    {
        sphere = new List<GameObject>();

        for(int i=0; i<amount; i++)
        {
            GameObject sph = (GameObject)Instantiate(SpherePool);
            sph.SetActive(false);
            sphere.Add(sph);
        }

    }

    
}
