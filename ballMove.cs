using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System;

public class Bone
{
    public int boneID; // the id can be 0~31
    public double[] coord = new double[3]; // means [x,y,z] 
}
public class Body
{
    public Bone[] bone = new Bone[32];
}
public class ballMove : MonoBehaviour
{
    // Start is called before the first frame update

    string path = @"F:\code\python\project\AR_project\data.txt";
    void Start()
    {
        transform.position = new Vector3((float)-0.334, (float)4, (float)-7.839);
    }

    // Update is called once per frame
    void Update()
    {
        float a, b, c;
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (StreamReader r = new StreamReader(fs))
        {
            string json = r.ReadToEnd();
            //Console.WriteLine(json);
            var bones = JsonConvert.DeserializeObject<List<Bone>>(json);
            /*foreach (Bone bone in bones)
            {
                //Console.WriteLine("{0},{1},{2},{3}\n", bone.boneID, bone.coordinate[0], bone.coordinate[1], bone.coordinate[2]);
                //this.transform.position = new Vector3((float)bones.coordinate[0], (float)bones.coordinate[1], (float)bones.coordinate[2]);
                //Debug.Log(bone);
            }*/
            //this.transform.position = new Vector3((float)bones[0].coord[0], (float)bones[0].coord[1], (float)bones[0].coord[2]);
            a = (float)bones[0].coord[0];
            b = (float)bones[0].coord[1];
            c = (float)bones[0].coord[2];
            this.transform.position = new Vector3(a,b,c);
            //this.transform.position = this.transform.position + new Vector3((float)bones[0].coordinate[0], (float)bones[0].coordinate[1], (float)bones[0].coordinate[2]);
            //this.transform.position = new Vector3((float)1, (float)1, (float)1);
            //Console.WriteLine("{0},{1},{2},{3}\n", bones.boneID, bones.coordinate[0], bones.coordinate[1], bones.coordinate[2]);
        }

        Thread.Sleep(10);

        
    }
}
