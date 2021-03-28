using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseKinematic : MonoBehaviour
{

    public Transform[] childs;

    float point_distance;
    float max_distance;
    float h;
    float current_distance;

    Vector3 mean_point = Vector3.zero;
    Vector3 perp;
    Vector3 dir;

    void Start()
    {
        childs = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            childs[i] = transform.GetChild(i);

        point_distance = Vector3.Distance(childs[0].position,childs[1].position);
        max_distance = point_distance * 2;
    }

    void Update()
    {
        current_distance = GetCurrentDistance();
        dir = GetCurrentDir();
        if(current_distance > max_distance){
            childs[2].position = childs[0].position + dir * max_distance;
            current_distance = max_distance;
        }

        mean_point = GetMeanPoint();
        h = Math.Hypotenuse(point_distance, current_distance/2, true);
        perp = Math.Perpendicular(dir,Vector3.right);
        childs[1].position = mean_point + perp * h;
    }

    float GetCurrentDistance()
    {
        return Vector3.Distance(childs[2].position, childs[0].position);
    }

    Vector3 GetCurrentDir()
    {
        return (childs[2].position - childs[0].position).normalized;
    }

    Vector3 GetMeanPoint()
    {
        return (childs[2].position + childs[0].position) / 2;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        for (int i = 0; i < childs.Length-1; i++)
        {
            Gizmos.DrawLine(childs[i].position,childs[i+1].position);
        }
        Gizmos.DrawCube(mean_point,Vector3.one/2);
        Gizmos.DrawLine(mean_point,mean_point+perp*h);
        
    }

}