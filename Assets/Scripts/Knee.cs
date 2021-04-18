using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knee : MonoBehaviour
{

    public bool right;

    public Transform body;

    public Transform start;
    public Transform end;

    float d;
    float d_max;
    float d_cur;

    Vector3 dir;
    Vector3 mean;

    // Start is called before the first frame update
    void Start()
    {
        d = Vector3.Distance(transform.position,start.position);
        d_max = d * 2;
    }

    // Update is called once per frame
    void Update()
    {
        d_cur = GetCurrentDistance();
        dir = GetCurrentDir();
        mean = GetMeanPoint();

        float h = Math.Hypotenuse(d, d_cur/2, true);
        Vector3 fwd = body.forward;
        if(right){
            fwd = -fwd;
        }
        Vector3 perp = Math.Perpendicular(dir,fwd);

        transform.position = mean + perp * h;
    }

    Vector3 GetCurrentDir()
    {
        return (end.position - start.position).normalized;
    }

    Vector3 GetMeanPoint()
    {
        return (end.position + start.position) / 2;
    }

    float GetCurrentDistance()
    {
        return Vector3.Distance(start.position, end.position);
    }
}
