using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = System.Diagnostics.Debug;


public class PauseManager : MonoBehaviour
{
    private bool _active = false;
    [SerializeField] GameObject _pauseMenu;
    public void Pause(InputAction.CallbackContext context)
    {
        Active = !Active;
        _pauseMenu.SetActive(Active);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public bool Active // Permet de détecter les changements d'état
    {
        get {return _active;}
        set 
        {
            if (_active != value)
            {
                _active = value;
                { 
                    float boolF = !_active ? 1.0f : 0.0f;
                    Cursor.visible = _active;
                    Time.timeScale = boolF;
                }
            }
        } 
    }
}
