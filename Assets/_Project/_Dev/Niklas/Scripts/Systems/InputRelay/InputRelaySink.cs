using Autohand;
using Autohand.Demo;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputRelaySink : MonoBehaviour {

    public static InputRelaySink Instance { get; private set; }

    [SerializeField] RectTransform CanvasTransform;
    

    public event EventHandler<OnRaycastResultEventArgs> OnRaycastResult;

    public class OnRaycastResultEventArgs : EventArgs {
        public List<RaycastResult> raycastResults;
    }

    List<RaycastResult> results = new List<RaycastResult>();

    Vector3 simulatedMousePosition = Vector3.zero;
    PointerEventData mouseEvent = new PointerEventData(EventSystem.current);




    private void Awake() {
        
        Instance = this;
        
        if(OpenXRHandControllerLink.Instance) {

            OpenXRHandControllerLink.Instance.OnTriggerPressed += ControllerLink_OnTriggerPressed;
            OpenXRHandControllerLink.Instance.OnTest += ControllerLink_OnTest;
        }
       
        
    }

    private void ControllerLink_OnTest(object sender, EventArgs e) {
        Debug.Log("Test gedrückt");
    }

    private void ControllerLink_OnTriggerPressed(object sender, EventArgs e) {
        
        PointerEventData controllerEvent = new PointerEventData(EventSystem.current);
        controllerEvent.position = simulatedMousePosition;
        //Debug.Log(results.Count);
        foreach (var result in results) {
            
            controllerEvent.pointerPressRaycast = result;
            controllerEvent.pointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(controllerEvent.pointerPressRaycast.gameObject);
            
            ExecuteEvents.Execute(result.gameObject, mouseEvent, ExecuteEvents.pointerDownHandler);
            ExecuteEvents.Execute(result.gameObject, mouseEvent, ExecuteEvents.pointerUpHandler);
            ExecuteEvents.Execute(result.gameObject, mouseEvent, ExecuteEvents.pointerClickHandler);


        }

        
        //Debug.Log("Trigger gedrückt");
    }

    public void OnReceiveTriggerInputAction() {

        PointerEventData controllerEvent = new PointerEventData(EventSystem.current);
        controllerEvent.position = simulatedMousePosition;
        Debug.Log(results.Count);
        foreach (var result in results) {

            controllerEvent.pointerPressRaycast = result;
            controllerEvent.pointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(controllerEvent.pointerPressRaycast.gameObject);

            ExecuteEvents.Execute(result.gameObject, mouseEvent, ExecuteEvents.pointerDownHandler);
            ExecuteEvents.Execute(result.gameObject, mouseEvent, ExecuteEvents.pointerUpHandler);
            ExecuteEvents.Execute(result.gameObject, mouseEvent, ExecuteEvents.pointerClickHandler);


        }


        //Debug.Log("Trigger gedrückt");
    }

    GraphicRaycaster Raycaster;
    // Start is called before the first frame update
    void Start()
    {
        Raycaster = GetComponent<GraphicRaycaster>();
    }

    private void Update() {
       
        

        
    }


    public void OnCursorInput(Vector2 normalisedPosition) {

        //Berechne die Position im Canvas
        simulatedMousePosition = new Vector3(CanvasTransform.sizeDelta.x * normalisedPosition.x, CanvasTransform.sizeDelta.y * normalisedPosition.y, 0f);



        //Debug.Log(simulatedMousePosition);

        //Pointer Event
        
        mouseEvent.position = simulatedMousePosition;      
               
        //führe einen Raycast aus mit dem graphics raycaster
        
        Raycaster.Raycast(mouseEvent, results);

        while (results.Count > 10) {
            results.RemoveAt(0);
        }
        OnRaycastResult?.Invoke(this, new OnRaycastResultEventArgs { raycastResults = results });

        bool sendMouseDown = Input.GetMouseButtonDown(0);
        bool sendMouseUp = Input.GetMouseButtonUp(0);      
        
            // Verarbeite Raycast results
        foreach (var result in results){
            // Debug.Log(result.gameObject.name);        
            
            if (sendMouseDown) {
                
                ExecuteEvents.Execute(result.gameObject, mouseEvent, ExecuteEvents.pointerDownHandler);
                
            }
            else if (sendMouseUp) {
                ExecuteEvents.Execute(result.gameObject, mouseEvent, ExecuteEvents.pointerUpHandler);
                ExecuteEvents.Execute(result.gameObject, mouseEvent, ExecuteEvents.pointerClickHandler);
                
            }
            
        }
        
    }
    /*
    private void Press(RaycastResult result, Vector3 simulatedMousePosition) {

        

        // Überprüfe, ob der Trigger gedrückt wurde
        bool triggerDown = false;

        //if (controllerEvent.pointerPress != null) {
            // Füge hier deine Debug-Ausgabe hinzu
            
            triggerDown = true;
        }
        
            GameObject pointerRelease = ExecuteEvents.GetEventHandler<IPointerClickHandler>(controllerEvent.pointerPressRaycast.gameObject);

        ExecuteEvents.Execute(controllerEvent.pointerPress, controllerEvent, ExecuteEvents.pointerDownHandler);

        

        if (controllerEvent.pointerPress == pointerRelease) {
            ExecuteEvents.Execute(controllerEvent.pointerPress, controllerEvent, ExecuteEvents.pointerUpHandler);
            ExecuteEvents.Execute(controllerEvent.pointerPress, controllerEvent, ExecuteEvents.pointerClickHandler);
        }
        */
}

