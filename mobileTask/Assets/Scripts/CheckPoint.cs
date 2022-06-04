using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Player"))
        //{
        //    PlayerPrefs.SetFloat("xPos", collision.transform.position.x);
        //    PlayerPrefs.SetFloat("yPos", collision.transform.position.y);
        //    PlayerPrefs.SetFloat("zPos", collision.transform.position.z);
        //    Debug.Log("Чекпоинт");
        //}
    }
}
