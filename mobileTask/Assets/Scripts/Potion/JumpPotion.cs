using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPotion : ParentPotion
{

 
    public PlayerControl player;

    public override void EffectPotion()
    {
        player.JumpValue++;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            EffectPotion();
        }
    }



}
