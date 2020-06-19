using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MoveSine : MonoBehaviour
{
    // stim characteristics
    public float amplitude;
    private float time_period = 2;
    public bool ML = true;
    public bool AP = false;

    private Vector3 newPosition;
    private Vector3 _startPosition;
    private float startTime;
    private float t;

    // output file
    private String res_file = DateTime.Now.ToString("dd-MM_hh-mm-ss") + "_POS.csv";
    String desktop_path;
    String file_path;

    // record resp
    Transform cam_transform;
    private float xpos, ypos, zpos;

    // record stim
    GameObject tracker_obj;
    Transform tracker;
    private float tracker_xpos, tracker_ypos, tracker_zpos;

    void Start()
    {
        // start position of object
        _startPosition = transform.position;

        // set camera transform
        cam_transform = Camera.main.transform;

        // create output file
        StreamWriter sr_pos = File.CreateText(res_file);
        file_path = "C:\\Users\\hprc-pcl VR\\Desktop\\CamTracker_Abstract\\" + res_file;
        //desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //file_path = desktop_path + "\\" + res_file;
        //Debug.Log(file_path);

        // track tracker object for stim signal
        tracker_obj = GameObject.FindWithTag("obj_tracking");
        if (tracker_obj == null)
        {
            Debug.Log("Tracker object is disabled / not found");
        }
        else
        {
            Debug.Log("Tracker object found");
            tracker = tracker_obj.transform;
        }           
 
        startTime = Time.time;
    }

    void FixedUpdate()
    {
        if (ML)
        {
            transform.position = _startPosition + new Vector3(Mathf.Sin(((Mathf.PI * 2) / time_period) * Time.time) * amplitude, 0.0f, 0.0f);
        }

        if (AP)
        {
            transform.position = _startPosition + new Vector3(0.0f, 0.0f, Mathf.Sin(((Mathf.PI * 2) / time_period) * Time.time) * amplitude);
        }

        if (this.gameObject.tag == "obj_tracking" && tracker_obj != null)
        {
            trackpos(file_path);
        }
    }

    void trackpos(String path)
    {
        xpos = cam_transform.position.x;
        ypos = cam_transform.position.y;
        zpos = cam_transform.position.z;

        tracker_xpos = tracker.position.x;
        tracker_zpos = tracker.position.z;

        var line = "";

        t = Time.time - startTime;

        if (ML)
        {
            line = t + "," + tracker_xpos + "," + xpos + "," + ypos + "," + zpos;
        }

        if (AP)
        {
            line = t + "," + tracker_zpos + "," + xpos + "," + ypos + "," + zpos;
        }

        if (ML && AP)
        {
            line = t + "," + tracker_xpos + "," + tracker_zpos + "," + xpos + "," + ypos + "," + zpos;
        }

        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(line);
        writer.Close();
    }

}
