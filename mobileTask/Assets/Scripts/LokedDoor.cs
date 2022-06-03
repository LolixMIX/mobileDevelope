using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LokedDoor : MonoBehaviour
{
    public GameObject Door;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetComponent<PlayerControl>().Key == true)
        {
            Destroy(Door);
        }
    }
}
