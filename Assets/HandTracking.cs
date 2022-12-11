using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    //link the script file
    public UDPReceive udpReceive;
    // Start is called before the first frame update
    public GameObject[] handPoints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get data from udpReciev script
        string data = udpReceive.data;
        //remove brackets from data
        data = data.Remove(0, 1);
        data = data.Remove(data.Length-1, 1);
        print(data);

        //split into numbers, create a list of strings
        string[] points = data.Split(',');

        //check if we are getting a single point or not
        print(points[0]);

        //send them to handPoints
        for(int i = 0; i < 21; i++)
        {
            //to go from x1 to x2, y1 to y2 ...
            //0   +1     1*3
            //x1, y2, z1, x2, y2, z2  
            float x = float.Parse(points[i*3])/100;
            float y = float.Parse(points[i*3 + 1])/100;
            float z = float.Parse(points[i*3 + 2])/100;
            //apply points to landmark
            handPoints[i].transform.localPosition = new Vector3(x,y,z);
             
        }

    }
}
