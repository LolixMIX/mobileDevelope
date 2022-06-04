using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthImg;
    public PlayerControl Player;

    private void HealthFiller()
    {
        healthImg.fillAmount = Player.HealthPoints / Player.MaxHealth;

    }

    private void Start()
    {
        
    }
    private void Update()
    {
        HealthFiller();
    }

    
}
