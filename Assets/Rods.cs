using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rods : MonoBehaviour
{
    public GameObject Rod;
    float[] z_position = {0.7f, 1.6f, 4.1f, 7.3f, 9.3f, 11.0f};

    void Start()
    {
        for (int j = 0; j < z_position.Length; j++)
        {
            Instantiate(Rod, new Vector3(10.0f, 0, z_position[j]), Quaternion.identity);
            Instantiate(Rod, new Vector3(10.0f, 0, -z_position[j]), Quaternion.identity);
            Instantiate(Rod, new Vector3(-10.0f, 0, z_position[j]), Quaternion.identity);
            Instantiate(Rod, new Vector3(-10.0f, 0, -z_position[j]), Quaternion.identity);
        }
    }

}

