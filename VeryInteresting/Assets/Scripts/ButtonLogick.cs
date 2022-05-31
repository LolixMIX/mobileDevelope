using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLogick : MonoBehaviour
{
    [SerializeField] private InputField _input1, _input2, _input3;
    [SerializeField] private CubeController CubeController;

    public void Set()
    {
        if (_input1.text != null && _input2.text != null && _input3.text != null)
        {
            CubeController.arr[0] = float.Parse(_input1.text);
            CubeController.arr[1] = float.Parse(_input2.text);
            CubeController.arr[2] = float.Parse(_input3.text);
        }
        CubeController.SetAPoint(CubeController.arr);

    }
}
