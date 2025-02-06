namespace Player.Interaction
{
    using UnityEngine.Events;

    public interface IInteractor
    {
        public UnityEvent onInteract { get; protected set; }
        public void Interact();        
        public UnityEvent toInteract { get; protected set; }
        public void readyToInteract();
        
        public UnityEvent notInteract { get; protected set; }
        
        public void notReadyInteract();
    }

}