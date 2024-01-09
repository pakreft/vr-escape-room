using UnityEngine;

namespace LNP_Escape_Room.HLAPuzzle
{
    /// <summary>
    /// Responsible for setting the point with index 1 of the LineRenderer with the target position.
    /// Doing this in Application.onBeforeRender.
    /// </summary>
    [RequireComponent(typeof(LineRenderer))]
    public class UpdateLineRendererEndPosition : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.SetPosition(0, transform.position);
        }
        
        private void OnEnable() => Application.onBeforeRender += SetEndPosition;
        
        private void OnDisable() => Application.onBeforeRender -= SetEndPosition;

        private void SetEndPosition() => _lineRenderer.SetPosition(1, targetTransform.position);
    }
}
