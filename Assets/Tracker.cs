using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    Transform cam_transform;
    private String pos_file = DateTime.Now.ToString("dd-MM_hh-mm-ss") + "_POS.csv";
    private String rot_file = DateTime.Now.ToString("dd-MM_hh-mm-ss") + "_ROT.csv";
    String pos_path, rot_path;
    private float startTime;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        cam_transform = this.transform;
        StreamWriter sr_pos = File.CreateText(pos_file);
        StreamWriter sr_rot = File.CreateText(rot_file);
        pos_path = "C:\\Users\\hprc-pcl VR\\Desktop\\CamTracker_Abstract\\" + pos_file;
        rot_path = "C:\\Users\\hprc-pcl VR\\Desktop\\CamTracker_Abstract\\" + rot_file;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        trackpos(pos_path, rot_path);
    }

    void trackpos(String path1, String path2)
    {
        float xpos = cam_transform.position.x;
        float ypos = cam_transform.position.y;
        float zpos = cam_transform.position.z;
        //Debug.Log();
        t = Time.time - startTime;
        var line = t + "," + xpos + "," + ypos + "," + zpos;

        StreamWriter writer1 = new StreamWriter(path1, true);
        //StreamWriter writer2 = new StreamWriter(path2, true);

        //writer1.Write(t);
        writer1.WriteLine(line);

        //writer2.Write(t);
        //writer2.WriteLine(cam_transform.rotation);


        writer1.Close();
        //writer2.Close();
    }
}
