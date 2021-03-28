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

    public Vector3 pos;
    public List<float> move_len;
    public List<Vector3> move_dir;

    int state = 0;

    public void AddFrame()
    {
        move_dir.Add((head.position - pos).normalized);
        move_len.Add(Vector3.Distance(head.position,pos));
        frames_count = move_dir.Count;
        pos = head.position;
    }
    public void Play()
    {
        state = state == 1 ? 0 : 1;
    }

    void RunFrame()
    {
        head.position += move_dir[frame] * move_len[frame];

        frame++;
        if(frame >= frames_count)
        {
            frame = 0;
            head.position = new Vector3(0,0,4);
        }
    }

    void Start()
    {
        pos = head.position;
        move_dir = new List<Vector3>();
        move_len = new List<float>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            AddFrame();
        }
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
        
        XmlSerializer serializer;
        StreamWriter writer;

        serializer = new XmlSerializer(typeof(Vector3[]));
        writer = new StreamWriter("Assets\\Data\\move_dir.xml");
        serializer.Serialize(writer.BaseStream, move_dir.ToArray());
        
        serializer = new XmlSerializer(typeof(float[]));
        writer = new StreamWriter("Assets\\Data\\move_len.xml");
        serializer.Serialize(writer.BaseStream, move_len.ToArray());

        writer.Close();
    }

    public void Load()
    {
        Stream stream = new MemoryStream();
        XmlSerializer serializer;
        StreamReader reader;

        serializer = new XmlSerializer(typeof(Vector3[]));
        reader = new StreamReader("Assets\\Data\\move_dir.xml");
        Vector3[] dirs = (Vector3[]) serializer.Deserialize(reader.BaseStream);
        move_dir.AddRange(dirs);

        serializer = new XmlSerializer(typeof(float[]));
        reader = new StreamReader("Assets\\Data\\move_len.xml");
        float[] lens = (float[]) serializer.Deserialize(reader.BaseStream);
        move_len.AddRange(lens);

        frames_count = move_dir.Count;

        reader.Close();
    }

    private void OnDrawGizmos() {
        if(frames_count>0){
            Gizmos.color = Color.red;
            Gizmos.DrawLine(head.position,head.position + move_dir[frame] * move_len[frame] * 3);
        }
    }
}
