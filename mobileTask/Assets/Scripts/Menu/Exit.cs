using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject menuPanel;
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
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
    }
}
