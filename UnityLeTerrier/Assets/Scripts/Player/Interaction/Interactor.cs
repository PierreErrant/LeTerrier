using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Interaction
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private LayerMask interactableLayer;
        private Transform _transform;
        public bool _hit;
        private InteractableObject _hitObject;
        private RaycastHit _raycastHit;
        private void Awake()
        {
            _transform = transform;
        }

        private void LateUpdate()
        {
            if (Physics.Raycast(_transform.position + (Vector3.up * 0.3f) + (_transform.forward * 0.2f),
                    _transform.forward, out var raycastHit, 1.5f))
            {
                if (raycastHit.transform.TryGetComponent(out InteractableObject interactable))
                {
                    _hitObject = interactable;
                    Hit = true;
                }
                
            }
            else
            {
                Hit = false;
            }
            
        }
        public void DoInteract(InputAction.CallbackContext context)
        {   
            if(!context.started) return;
            if (!Hit) return;
            _hitObject.Interact();
        }
        public bool Hit
        {
            get {return _hit;}
            set 
            {
                if (_hit != value)
                {
                    _hit = value;
                    { 
                        _hitObject.readyToInteract();
                    }
                }
            } 
        }


    }
}
