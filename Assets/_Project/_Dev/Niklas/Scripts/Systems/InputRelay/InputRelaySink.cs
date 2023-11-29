using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputRelaySink : MonoBehaviour {

    public static InputRelaySink Instance { get; private set; }

    [SerializeField] RectTransform CanvasTransform;
    public event EventHandler<OnRaycastResultEventArgs> OnRaycastResult;
    public class OnRaycastResultEventArgs : EventArgs {
        public List<RaycastResult> raycastResults;
    }

    private void Awake() {
        Instance = this;
    }

    GraphicRaycaster Raycaster;
    // Start is called before the first frame update
    void Start()
    {
        Raycaster = GetComponent<GraphicRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCursorInput(Vector2 normalisedPosition) {

        //Berechne die Position im Canvas
        Vector3 mousePosition = new Vector3(CanvasTransform.sizeDelta.x * normalisedPosition.x, CanvasTransform.sizeDelta.y * normalisedPosition.y, 0f);
        Debug.Log(mousePosition);


        
        //Pointer Event
        PointerEventData mouseEvent = new PointerEventData(EventSystem.current);
        mouseEvent.position = mousePosition;

        //führe einen Raycast aus mit dem graphics raycaster
        List<RaycastResult> results = new List<RaycastResult>();
        Raycaster.Raycast(mouseEvent, results);

        OnRaycastResult?.Invoke(this, new OnRaycastResultEventArgs { raycastResults = results });

        bool sendMouseDown = Input.GetMouseButtonDown(0);
        bool sendMouseUp = Input.GetMouseButtonUp(0);

        // Verarbeite Raycast results
        foreach (var result in results){
            //Debug.Log(result.gameObject.name);
            
            if (sendMouseDown) {
                ExecuteEvents.Execute(result.gameObject, mouseEvent, ExecuteEvents.pointerDownHandler);
            }
            else if (sendMouseUp) {
                ExecuteEvents.Execute(result.gameObject, mouseEvent, ExecuteEvents.pointerUpHandler);
                ExecuteEvents.Execute(result.gameObject, mouseEvent, ExecuteEvents.pointerClickHandler);
            }
        }
        
    }
}
