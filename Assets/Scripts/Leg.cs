using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class Leg : MonoBehaviour
{

    public float delay;
    public int frames_count = 0;
    public int frame = 0;
    public float time;

    public Transform head;

    public List<Vector3> anim;

    int state = 0;

    public void AddFrame()
    {
        anim.Add(head.position);
        frames_count = anim.Count;
    }
    public void Play()
    {
        state = state == 1 ? 0 : 1;
    }

    void RunFrame()
    {
        head.position = anim[frame];

        frame++;
        if(frame >= anim.Count)
            frame = 0;
    }

    void Start()
    {
        anim = new List<Vector3>();
    }


    void Update()
    {
        if(state == 1)
        {
            if((time += Time.unscaledDeltaTime) > delay)
            {
                RunFrame();
                time = 0;
            }
        }
    }


    public void Save()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Vector3[]));
        StreamWriter writer = new StreamWriter("Assets\\Data\\anim.xml");
        serializer.Serialize(writer.BaseStream, anim.ToArray());
        writer.Close();
    }

    public void Load()
    {
        Stream stream = new MemoryStream();
        var xmlSerializer = new XmlSerializer(typeof(Vector3[]));
        
        XmlSerializer serializer = new XmlSerializer(typeof(Vector3[]));
        StreamReader reader = new StreamReader("Assets\\Data\\anim.xml");
        
        Vector3[] pos = (Vector3[]) serializer.Deserialize(reader.BaseStream);
        anim.AddRange(pos);

        frames_count = anim.Count;

        reader.Close();
    }
}
