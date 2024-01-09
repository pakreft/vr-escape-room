using UnityEngine;
using UnityEngine.Events;

namespace LNP_Escape_Room.HLAPuzzle
{
    public enum State
    {
        Hit,
        NotHit
    }
    
    [RequireComponent(typeof(MeshRenderer))]
    public class TriggerController : MonoBehaviour
    {
        [SerializeField] private Material hitMaterial;
        [SerializeField] private Material notHitMaterial;
        [SerializeField] private UnityEvent hitEnter;
        [SerializeField] private UnityEvent hitExit;

        /// <summary>
        /// State in current frame
        /// </summary>
        [HideInInspector] public State CurrentState;

        /// <summary>
        /// State in previous frame
        /// </summary>
        [HideInInspector] public State PreviousState;
        
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            PreviousState = State.NotHit;
            CurrentState = State.NotHit;
            
            _meshRenderer = GetComponent<MeshRenderer>();
            _meshRenderer.material = notHitMaterial;
        }

        public void OnHitEnter()
        {
            PreviousState = CurrentState;
            _meshRenderer.material = hitMaterial;
            hitEnter?.Invoke();
        }
        
        public void OnHitExit()
        {
            PreviousState = CurrentState;
            _meshRenderer.material = notHitMaterial;
            hitExit?.Invoke();
        }
    }
}
