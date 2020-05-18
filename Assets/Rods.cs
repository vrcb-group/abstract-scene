using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rods : MonoBehaviour
{
    public GameObject Rod;
    public bool rods = true;
    public bool oscillate = true;
    float[] z_position = {0.7f, 1.6f, 4.1f, 7.3f, 9.3f, 11.0f};

    public float amplitude;
    private float time_period = 2;

    GameObject[] rodPool;

    void Start()
    {
        if(rods)
        {
            Rod.tag = "osc";
            
            for (int j = 0; j < z_position.Length; j++)
            {
                //GameObject r = (GameObject)Instantiate(Rod, new Vector3(10.0f, 0, z_position[j]), Quaternion.identity);
                //rodPool.Add(r);
                //r = (GameObject)Instantiate(Rod, new Vector3(10.0f, 0, -z_position[j]), Quaternion.identity);
                //rodPool.Add(r);
                //r = (GameObject)Instantiate(Rod, new Vector3(-10.0f, 0, z_position[j]), Quaternion.identity);
                //rodPool.Add(r);
                //r = (GameObject)Instantiate(Rod, new Vector3(-10.0f, 0, -z_position[j]), Quaternion.identity);
                //rodPool.Add(r);

                Instantiate(Rod, new Vector3(10.0f, 0, z_position[j]), Quaternion.identity);
                Instantiate(Rod, new Vector3(10.0f, 0, -z_position[j]), Quaternion.identity);
                Instantiate(Rod, new Vector3(-10.0f, 0, z_position[j]), Quaternion.identity);
                Instantiate(Rod, new Vector3(-10.0f, 0, -z_position[j]), Quaternion.identity);
            }
        }

        rodPool = GameObject.FindGameObjectsWithTag("osc");

    }

    void FixedUpdate()
    {
        if (oscillate)
        {
            foreach (GameObject r in rodPool)
            {
                r.transform.position = r.transform.position + new Vector3(Mathf.Sin(((Mathf.PI * 2) / time_period) * Time.time) * amplitude, 0.0f, 0.0f);
            }

        }
    }
}

