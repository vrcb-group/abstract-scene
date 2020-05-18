using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spheres : MonoBehaviour
{
    public GameObject Sphere;
    public bool spheres = true;
    public bool oscillate = true;
    public int amount = 2000;

    public float amplitude;
    private float time_period = 2;

    List<GameObject> spherePool;

    void Start()
    {
        if (spheres)
        {
            //Sphere.tag = "osc";
            spherePool = new List<GameObject>();
            for (int i = 0; i < amount; i++)
            {
                GameObject sp = (GameObject)Instantiate(Sphere, new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-11.0f, 15.0f), Random.Range(-7.0f, 13.0f)), Quaternion.identity);
                sp.SetActive(true);
                spherePool.Add(sp);
            }
        }
    }

    void FixedUpdate()
    {
        if (oscillate)
        {
            foreach (GameObject sp in spherePool)
            {
                sp.transform.position = sp.transform.position + new Vector3(Mathf.Sin(((Mathf.PI * 2) / time_period) * Time.time) * amplitude, 0.0f, 0.0f);
            }
            
        }
    }

}
