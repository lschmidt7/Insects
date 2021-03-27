using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseKinematic : MonoBehaviour
{

    public Transform[] childs;

    float d;
    float maxDist;
    float h;
    float dist;
    Vector3 pm = Vector3.zero;

    Vector3 perp;
    Vector3 dir;

    void Start()
    {
        childs = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childs[i] = transform.GetChild(i);
        }

        d = Vector3.Distance(childs[0].position,childs[1].position);
        maxDist = d * 2;
    }

    void Update()
    {
        dist = Vector3.Distance(childs[0].position,childs[2].position);
        dir = (childs[2].position - childs[0].position).normalized;
        if(dist > maxDist){
            childs[2].position = childs[0].position + dir * maxDist;
            dist = maxDist;
        }

        pm = (childs[2].position + childs[0].position) / 2;
        h = Mathf.Sqrt( d * d - (dist/2) * (dist/2) );
        perp = Vector3.Cross(dir,Vector3.right).normalized;
        childs[1].position = pm + perp * h;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        for (int i = 0; i < childs.Length-1; i++)
        {
            Gizmos.DrawLine(childs[i].position,childs[i+1].position);
        }
        Gizmos.DrawCube(pm,Vector3.one/2);
        Gizmos.DrawLine(pm,pm+perp*h);
        
    }

}