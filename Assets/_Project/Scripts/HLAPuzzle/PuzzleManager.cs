using UnityEngine;
using UnityEngine.Events;

namespace LNP_Escape_Room.HLAPuzzle
{
    public class PuzzleManager : MonoBehaviour
    {
        [SerializeField] private Transform movable;
        [SerializeField] private Transform[] anchors;
        [SerializeField] private TriggerController[] triggers;
        [SerializeField] private LayerMask layersToRayHit;

        [SerializeField] private UnityEvent puzzleStart;
        [SerializeField] private UnityEvent puzzleEnd;
        
        private void Start()
        {
            puzzleStart?.Invoke();
            enabled = false;
        }

        private void Update()
        {
            ResetAllTriggerStates();
            CastRays();
            HandleTriggers();
            HandleAllTriggersHit();
        }
        
        /// <summary>
        /// Sets the CurrentState of all elements in triggers to NotHit.
        /// </summary>
        private void ResetAllTriggerStates()
        { 
            foreach (var trigger in triggers)
                trigger.CurrentState = State.NotHit;
        }

        /// <summary>
        /// Casts a physics ray from the movable to the given anchor.
        /// When a trigger is hit, change it's CurrentState to Hit, otherwise do nothing.
        /// </summary>
        /// <param name="anchorPosition"></param>
        private void CastRay(Vector3 anchorPosition)
        {
            var origin = movable.transform.position;
            var direction = (anchorPosition - origin).normalized;
            var maxDistance = Vector3.Distance(origin, anchorPosition);
            
            if (Physics.Raycast(origin, direction, out var hit, maxDistance, layersToRayHit))
            {
                hit.transform.gameObject.GetComponent<TriggerController>().CurrentState = State.Hit;
            }
        }
        
        /// <summary>
        /// CastRay for every element in anchors.
        /// </summary>
        private void CastRays()
        { 
            foreach (var anchor in anchors)
                CastRay(anchor.position);
        }
        
        /// <summary>
        /// Invokes trigger events based on it's previous and current state.
        /// </summary>
        private void HandleTriggers()
        {
            foreach (var trigger in triggers)
            {
                // Enters trigger in this frame
                if (trigger.PreviousState == State.NotHit && trigger.CurrentState == State.Hit)
                {
                    trigger.OnHitEnter();
                    continue;
                }
                
                // Leaving trigger in this frame
                if (trigger.PreviousState == State.Hit && trigger.CurrentState == State.NotHit)
                {
                    trigger.OnHitExit();
                    continue;
                }
            }
        }
        
        /// <summary>
        /// Checks if all triggers are hit, if yes then execute on PuzzleEnd().
        /// </summary>
        private void HandleAllTriggersHit()
        {
            foreach (var trigger in triggers)
                if (trigger.CurrentState == State.NotHit) return;
            
            OnPuzzleEnd();
        }
        
        private void OnPuzzleEnd()
        {
            puzzleEnd?.Invoke();
        }
    }
}
