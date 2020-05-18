using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSine : MonoBehaviour
{
    private Vector3 _startPosition;
    public float amplitude;
    private float time_period = 2;
    private float startTime;
    private float t;

    private GameObject[] objects;

    //List<GameObject> move_object;

    void Start()
    {
        //move_object = new List<GameObject>();

        //if (objects == null)
        //{
        //    objects = GameObject.FindGameObjectsWithTag("osc");
        //}

        _startPosition = transform.position;
        //startTime = Time.time;
    }

    void FixedUpdate()
    {
        //t = Time.time - startTime;

        transform.position = _startPosition + new Vector3(Mathf.Sin(((Mathf.PI*2)/time_period)*Time.time) * amplitude, 0.0f, 0.0f);

        //transform.position = _startPosition + new Vector3(0.0f, 0.0f, Mathf.Sin(((Mathf.PI * 2) / time_period) * Time.time) * amplitude);

        //Debug.Log(frequency * Time.time);
    }
}
