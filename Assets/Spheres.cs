using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spheres : MonoBehaviour
{
    /// Initialize variables 
    public GameObject Sphere;
    public bool spheres = true;
    public int amount = 2000;
    public bool limited_lifetime;
    public int lifetime = 300;
    private float loop_start, loop_end, wait_time, sub_factor, diff;
    List<GameObject> spherePool;

    void Start()
    {
        /// Display grid of random spheres if option is selected
        if (spheres)
        {
            spherePool = new List<GameObject>();
            for (int i = 0; i < amount; i++)
            {
                GameObject sp = (GameObject)Instantiate(Sphere, new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-11.0f, 15.0f), Random.Range(-7.0f, 13.0f)), Quaternion.identity);
                spherePool.Add(sp);
            }

            /// Run limited lifetime for spheres
            if (limited_lifetime)
            {

                /// Create file to store lifetime values
                string filename = DateTime.Now.ToString("dd-MM_hh-mm-ss") + "_lifetime_" + lifetime + ".csv";
                StreamWriter sr = File.CreateText(filename);
                string path = "C:\\Users\\hprc-pcl VR\\Desktop\\LimitedLifeTime\\Lifetime\\" + filename;

                /// Set lifetime based on value specified
                switch (lifetime)
                {
                    case 150:
                        //wait_time = 0.011f;
                        wait_time = 0.01105f;
                        break;
                    case 300:
                        //wait_time = 0.023f;
                        wait_time = 0.0223f;
                        break;
                    case 600:
                        //wait_time = 0.055f;
                        wait_time = 0.0555f;
                        break;
                    default:
                        wait_time = 0;
                        break;
                }

                /// If valid lifetime value is specified, run coroutine to implement limited lifetime 
                if (wait_time>0)
                {
                    StartCoroutine(BlinkSpheres(path));
                }
                   
            }
            
        }
    }

    private IEnumerator BlinkSpheres(String path)
    {   
        /// Run until manual interruption
        while (true)
        {
            /// Set lifetime based on value specified
            loop_start = System.DateTime.Now.Millisecond;

            /// Loop for entire set of spheres
            for (int i = 0; i < 10  ; i++)
            {
                /// Loop for every amount/10 spheres
                for (int j = i*(amount/10); j < (i+1)*(amount/10); j++)
                {
                    spherePool[j].SetActive(false);
                    spherePool[j].transform.position = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-11.0f, 15.0f), Random.Range(-7.0f, 13.0f));
                    spherePool[j].SetActive(true);
                }
                /// Wait for pre-decided time
                yield return new WaitForSeconds(wait_time);               
            }

            /// Calculate difference between start and end of first loop (all spheres) 
            /// Roughly equal to the lifetime of each sphere
            diff = System.DateTime.Now.Millisecond - loop_start;
            if(diff < 0)
            {
                diff = diff + 1000;
            }

            //Debug.Log(diff);
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(diff);
            writer.Close();
        }
    }

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
