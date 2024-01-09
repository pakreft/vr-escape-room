using UnityEngine;

namespace LNPEscapeRoom.HLAPuzzle
{
    [ExecuteInEditMode]
    public class Helper : MonoBehaviour
    {
        [SerializeField] private Transform endPositionMovable;
        [SerializeField] private Transform trigger;
        [Range(0, 1)]
        [SerializeField] private float distance;
        
        private void Update()
        {
            SetTriggerPosition();
            Debug.DrawLine(transform.position, endPositionMovable.position); // needs Gizmos enabled
        }
        
        private void SetTriggerPosition()
        {
            var anchorPos = transform.position;
            var dir = endPositionMovable.position - anchorPos;
            var final = (dir * distance) + anchorPos;
            
            trigger.transform.position = final;
        }
    }
}
