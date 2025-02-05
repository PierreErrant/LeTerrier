using System;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;


public class PauseManager : MonoBehaviour
{
    private bool active = false;
    [SerializeField] GameObject pauseMenu;
    
    public void Pause(InputAction.CallbackContext context)
    {
        active = !active;
        pauseMenu.SetActive(active);
        if (active) Time.timeScale = 0.0f;
        else Time.timeScale =  1;
    }

    public void Quit()
    {
        Application.Quit();
        UnityEngine.Debug.Log("Quit");
    }
}
