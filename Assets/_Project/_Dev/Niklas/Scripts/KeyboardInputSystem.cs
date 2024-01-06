using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;
using UnityEngine.InputSystem;
using System;
using System.IO;

[RequireComponent(typeof(ConfigurableJoint))]
public class KeyboardInputSystem : MonoBehaviour {

    public static KeyboardInputSystem Instance {  get; private set; }

    
    public UnityEvent <String> OnPerformKey;

    public string Key; //enter = Enter, back =  Backspace
    

    private ConfigurableJoint joint;
    private float maxPositionThreshold = 0.01f; // Schwellenwert für Positionsveränderung
    private float startPositionThreshold = 0.0001f; // Erlaubte Abweichung von der Startposition zum erneuten Auslösen des Events, notwendig, da Joint in der Regel nicht haargenau an Ursprung zurückkehrt

    float startPosition;
    bool canInvokeEvent = true; // Schaltet Event An und Aus

    private void Awake() {
        Instance = this;
    }
    private void Start() {
        joint = GetComponent<ConfigurableJoint>();
        startPosition = joint.transform.position.y; // Speichert die Startposition
    }

    private void Update() {
        LogJointPosition();

        // Überprüfen, ob der Joint sich kurz vor seiner maximalen Position auf der Y-Achse befindet.
        if (joint != null) {

            float currentPosition = joint.transform.position.y;

            if (startPosition - currentPosition >= maxPositionThreshold && canInvokeEvent) {
                
                canInvokeEvent = false; // Event kann zunächst nicht erneut ausgelöst werden
                PerformKeyboardInput(Key);

            } else if (startPosition - currentPosition <= startPositionThreshold && !canInvokeEvent) {
                canInvokeEvent = true; // Erlaubt das erneute Auslösen des Events, wenn der Joint an seine Startposition zurückkehrt.
            }
        }
    }

    private void PerformKeyboardInput(string Key) {

        OnPerformKey.Invoke(Key);

    }
        

    private void LogJointPosition() {
        if (joint == null) {
            Debug.LogError("ConfigurableJoint not found.");
            return;
        }

        Vector3 jointPosition = joint.transform.position;

        // Debug.Log($"Joint Position:  {jointPosition.y}");

    }
}