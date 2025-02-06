using UnityEngine;
using UnityEngine.Events;

namespace Player.Interaction
{
    public class InteractableObject : MonoBehaviour, IInteractor
    {
        [SerializeField] private UnityEvent _OnInteract;
        [SerializeField] private UnityEvent _ToInteract;
        [SerializeField] private UnityEvent _NotInteract;
       
        UnityEvent IInteractor.onInteract
        {
            get => _OnInteract;
            set => _OnInteract = value;
        }

        UnityEvent IInteractor.toInteract
        {
            get => _ToInteract;
            set => _ToInteract = value;
        }
        
        UnityEvent IInteractor.notInteract
        {
            get => _NotInteract;
            set => _NotInteract = value;
        }

        public void Interact() => _OnInteract.Invoke();
        public void readyToInteract() => _ToInteract.Invoke();
        
        public void notReadyInteract() => _NotInteract.Invoke();

    }
}
