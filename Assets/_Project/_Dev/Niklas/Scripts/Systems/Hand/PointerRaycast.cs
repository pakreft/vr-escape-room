using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerRaycast : MonoBehaviour {

    [SerializeField] UnityEvent<Vector2> OnControllerInput = new UnityEvent<Vector2>();
    [SerializeField] private Transform handTransform; // Hier die Referenz zur Hand einstellen
    public float raycastLength = 5f;
    public LayerMask raycastMask = ~0;

    private RaycastHit hit;

    
    private LineRenderer lineRenderer;

    

    void Start() {
        // Initialisiere den LineRenderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.material = new Material(Shader.Find("Standard"));
        lineRenderer.material.color = Color.red;
        lineRenderer.positionCount = 2; // Setze die Anzahl der Positionen auf 2
    }

    void Update() {
        // Führe den Raycast aus
        
        if (handTransform != null) {
            Ray ray = new Ray(handTransform.position, handTransform.forward);

            if (Physics.Raycast(ray, out hit, raycastLength, raycastMask)) {
                // Zeichne eine rote Linie zwischen der Hand und dem Trefferpunkt
                lineRenderer.SetPosition(0, handTransform.position);
                lineRenderer.SetPosition(1, hit.point);
                OnControllerInput.Invoke(hit.textureCoord);
                //Debug.Log(hit.collider.gameObject.name + " UV " + hit.textureCoord);
            } else {
                // Deaktiviere die Linie, wenn kein Treffer erfolgt
                lineRenderer.SetPosition(0, Vector3.zero);
                lineRenderer.SetPosition(1, Vector3.zero);
            }
        }
    }

    
    
}
