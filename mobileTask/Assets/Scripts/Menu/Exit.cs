using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject reloadPanel;
    public PlayerControl player;
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menuPanel.activeInHierarchy)
        {
            menuPanel.SetActive(false);
            //Application.Quit();

        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            Debug.Log("Exit");
            menuPanel.SetActive(true);
        }
        if (!player)
        {
            reloadPanel.SetActive(true);
        }
    }
}
