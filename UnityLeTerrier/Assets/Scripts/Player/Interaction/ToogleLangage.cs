using UnityEngine;

namespace Player.Interaction
{

    public class ToogleLangage : MonoBehaviour
    {
        [SerializeField] private GameObject _frPanel;
        [SerializeField] private GameObject _enPanel;
        private bool _active = true;
     
        public void doToggleLangage()
        {
            _active = !_active;
            _frPanel.SetActive(_active);
            _enPanel.SetActive(!_active);
        }
    }
}