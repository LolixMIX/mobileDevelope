using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //public Transform CubeTransform;

    [SerializeField] private Vector3 _currentPoint;
    [SerializeField] private Vector3 _startPoint;

    private Vector3 EndPoint = new Vector3();
    [SerializeField] private bool _loop = false;

    public float[] arr = new float[3] { 1, 2, 3 };
    float speed = 2f;



    public Vector3 SetAPoint(float[] dirPoint)
    {

        try
        {
            EndPoint = new Vector3(dirPoint[0], dirPoint[1], dirPoint[2]);
        }
        catch (System.Exception e)
        {

            Debug.LogError(e);
        }
        return EndPoint;
    }
    public void MoveToPoint()
    {
        if (transform.position != EndPoint)
        {
            transform.position = Vector3.MoveTowards(_currentPoint, EndPoint, speed * Time.deltaTime);
        }
        else if (_loop && transform.position != EndPoint)
        {
            transform.position = Vector3.MoveTowards(_currentPoint, EndPoint, speed * Time.deltaTime);
        }
        else if (_loop && transform.position == EndPoint)
        {
            InversePoint(ref _startPoint, ref EndPoint);
        }

    }
    private Vector3 InversePoint(ref Vector3 start, ref Vector3 end)
    {
        Vector3 temp = end;

        end = start;
        Debug.Log("end " + end);
        start = temp;
        Debug.Log("start " + start);
        return end;
    }

    private void Start()
    {
        _startPoint = transform.position;
        SetAPoint(arr);
    }
    void Update()
    {
        _currentPoint = transform.position;
        if (Input.GetKeyDown(KeyCode.D))
        {
            _loop = !_loop;
        }
        if (Input.GetKeyDown(KeyCode.F) && EndPoint == _currentPoint)
        {
            SetAPoint(arr);
            _startPoint = transform.position;
        }
        MoveToPoint();


    }
}
