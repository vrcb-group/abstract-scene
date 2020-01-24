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
                GameObject sp = (GameObject)Instantiate(Sphere, new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-11.0f, 15.0f), Random.Range(-7.0f, 13.0f)), Quaternion.identity);
                sp.SetActive(true);
                spherePool.Add(sp);
            }
            //StartCoroutine("BlinkSpheres");
        }
    }

    //private IEnumerator BlinkSpheres()
    //{
    //    while(true)
    //    {
    //        for (int i = 0; i < 20; i++)
    //        {
    //            for (int j = i*(amount/20); j < (i+1)*(amount/20); j++)
    //            {
    //                spherePool[j].SetActive(false);
    //                spherePool[j].transform.position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-11.0f, 15.0f), Random.Range(-10.0f, 10.0f));
    //                spherePool[j].SetActive(true);
    //            }
    //            //Debug.Log(System.DateTime.Now);
    //            yield return new WaitForSeconds(0.01f);
    //        }   
    //    }
    //}

}
