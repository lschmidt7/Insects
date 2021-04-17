using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class Leg : MonoBehaviour
{

    public Transform[] childs;

    void Start() {

    }

    private void OnDrawGizmos() {
        Gizmos.color = new Color(1,0.5f,0);
        if(childs != null)
        {
            for (int i = 0; i < childs.Length-1; i++)
            {
                Gizmos.DrawLine(childs[i].position,childs[i+1].position);
            }
        }
    }
}
