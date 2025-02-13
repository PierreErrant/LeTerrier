using UnityEngine;
using UnityEngine.UI;

public class ToogleGameObject : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private void Toogle()
    {
        _target.SetActive(!_target.activeSelf);
    } 
}
