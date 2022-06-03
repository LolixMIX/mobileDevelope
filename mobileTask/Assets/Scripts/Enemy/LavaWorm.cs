using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaWorm : MonoBehaviour
{

    public Vector3 start;
    public Vector3 dir;

    private void Start()
    {
        start = transform.position;
        dir = transform.position;
    }
    public void Move()
    {
        transform.position = Vector3.MoveTowards(start, transform.position - dir, 0.1f );
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
