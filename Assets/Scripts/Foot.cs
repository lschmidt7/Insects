using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{

    public Transform articulacao;

    Vector3 target_vector;

    Vector3 target_pos;

    Vector3 move_vector = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        target_vector = transform.position - articulacao.position;
    }

    // Update is called once per frame
    void Update()
    {
        target_pos = articulacao.position + new Vector3(
            (target_vector.x * articulacao.right).x, 
            (target_vector.y * articulacao.up).y, 
            (target_vector.z * articulacao.forward).z
            );

        if(Vector3.Distance(transform.position,target_pos) > 0.3)
        {
            move_vector = target_pos - transform.position;
            transform.position = target_pos;
        }
        else
        {
            move_vector = Vector3.zero;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        if(move_vector!=Vector3.zero)
        {
            Gizmos.DrawLine(transform.position,transform.position + move_vector);
        }
    }
}
