using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaWorm : MonoBehaviour
{

    private Vector3 _dir;
    private Vector3 _back;
    float dir;
    bool movingUp;
    private void Start()
    {
        _dir = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        _back = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
    }
    public void Move()
    {

        transform.position = Vector3.MoveTowards(transform.position, _dir, Time.deltaTime);


    }

    public void MoveUpDown()
    {
        if (transform.position.y > -1f)
        {
            movingUp = false;
            
        }
        else if(transform.position.y < -2f)
        {
            movingUp = true;
            
        }
        
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, _dir, Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _back, Time.deltaTime);
        }


    }

    // Update is called once per frame
    void Update()
    {
        MoveUpDown();
    }
}
