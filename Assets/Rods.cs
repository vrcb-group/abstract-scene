using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rods : MonoBehaviour
{
    public GameObject Rod;
    public bool rods = true;
    float[] z_position = {0.7f, 1.6f, 4.1f, 7.3f, 9.3f, 11.0f};

    void Start()
    {
        if (rods)
        {
            for (int j = 0; j < z_position.Length; j++)
            {
                GameObject r1 = (GameObject)Instantiate(Rod, new Vector3(10.0f, 0, z_position[j]), Quaternion.identity);
                GameObject r2 = (GameObject)Instantiate(Rod, new Vector3(10.0f, 0, -z_position[j]), Quaternion.identity);
                GameObject r3 = (GameObject)Instantiate(Rod, new Vector3(-10.0f, 0, z_position[j]), Quaternion.identity);
                GameObject r4 = (GameObject)Instantiate(Rod, new Vector3(-10.0f, 0, -z_position[j]), Quaternion.identity);

                //r1.transform.parent = GameObject.Find("Main Camera").transform;
                //r2.transform.parent = GameObject.Find("Main Camera").transform;
                //r3.transform.parent = GameObject.Find("Main Camera").transform;
                //r4.transform.parent = GameObject.Find("Main Camera").transform;
            }
        }
    }
}

