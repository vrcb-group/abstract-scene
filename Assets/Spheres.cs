using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spheres : MonoBehaviour
{
    public GameObject Sphere;
    public bool spheres = true;
    public int amount = 2000;
    public bool limited_lifetime;
    public int lifetime = 300;
    private float loop_start, loop_end, wait_time, sub_factor, diff;
    List<GameObject> spherePool;

    void Start()
    {
        if(spheres)
        {
            spherePool = new List<GameObject>();
            for (int i = 0; i < amount; i++)
            {
                GameObject sp = (GameObject)Instantiate(Sphere, new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-11.0f, 15.0f), Random.Range(-7.0f, 13.0f)), Quaternion.identity);
                spherePool.Add(sp);
            }
            if(limited_lifetime)
            {
                switch(lifetime)
                {
                    case 150:
                        wait_time = 0.011f;
                        break;
                    case 300:
                        wait_time = 0.023f;
                        break;
                    case 600:
                        wait_time = 0.055f;
                        break;
                    default:
                        wait_time = 0;
                        break;
                }
                if(wait_time>0)
                {
                    StartCoroutine("BlinkSpheres");
                }               
            }
            
        }
    }

    private IEnumerator BlinkSpheres()
    {
        while(true)
        {
            loop_start = System.DateTime.Now.Millisecond;
            for (int i = 0; i < 10  ; i++)
            {
                //loop_start = System.DateTime.Now.Millisecond;
                for (int j = i*(amount/10); j < (i+1)*(amount/10); j++)
                {
                    spherePool[j].SetActive(false);
                    spherePool[j].transform.position = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-11.0f, 15.0f), Random.Range(-7.0f, 13.0f));
                    spherePool[j].SetActive(true);
                    //if(j==300)
                    //{
                    //    Debug.Log(System.DateTime.Now.Millisecond);
                    //}
                }

                //loop_end = System.DateTime.Now.Millisecond;

                //Debug.Log(loop_end - loop_start);

                //wait_time = (sub_factor - (loop_end - loop_start)) / 1000;

                //if (wait_time > sub_factor/1000)
                //{
                //    wait_time = wait_time - 1;
                //}

                //Debug.Log(time_now);
                //Debug.Log(System.DateTime.Now.Millisecond);
                //Debug.Log(wait_time);   

                yield return new WaitForSeconds(wait_time);
                                   
            }

            diff = System.DateTime.Now.Millisecond - loop_start;
            if(diff < 0)
            {
                diff = diff + 1000;
            }
            Debug.Log(diff);
        }
    }

}
