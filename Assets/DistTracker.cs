using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DistTracker : MonoBehaviour
{
    Transform empty_transform;
    private String input_file = DateTime.Now.ToString("dd-MM_hh-mm-ss") + "_input.csv";
    String input_path;
    private float startTime;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        empty_transform = this.transform;
        StreamWriter sr_pos = File.CreateText(input_file);
        input_path = "C:\\Users\\hprc-pcl VR\\Desktop\\CamTracker_Abstract\\" + input_file;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        trackpos(input_path);
    }

    void trackpos(String path)
    {
        //Debug.Log(transform.position.x);

        float xpos = transform.position.x;
        //float ypos = transform.position.y;
        //float zpos = transform.position.z;
        
        t = Time.time - startTime;
        var line = t + "," + xpos;
        //var line = t + "," + zpos;

        StreamWriter writer1 = new StreamWriter(path, true);
        
        writer1.WriteLine(line);
        writer1.Close();
    }
}
