using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string[] scenesToLoad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadSceneList(scenesToLoad);
        
    }

    // Update is called once per frame
    private void LoadSceneList(string[] _list)
    {
        foreach (string name in _list) 
        { 
            SceneManager.LoadScene(name, LoadSceneMode.Additive);
        }
    }
}
