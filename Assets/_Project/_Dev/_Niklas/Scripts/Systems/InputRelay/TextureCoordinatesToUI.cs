using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextureCoordinatesToUI : MonoBehaviour {
    GraphicRaycaster raycaster;
    Canvas canvas;
    [SerializeField] private RectTransform canvasTransform;

    // Diese Funktion wird von einer anderen Funktion aufgerufen und erh�lt die Texture Coordinates
    public void ProcessTextureCoordinates(Vector2 textureCoordinates) {
        
        // Hole die ben�tigten Komponenten
        if (raycaster == null)
            raycaster = GetComponent<GraphicRaycaster>();

        if (canvas == null)
            canvas = GetComponent<Canvas>();

        // Konvertiere Texture Coordinates zu Viewport Coordinates
        Vector2 viewportCoordinates = TextureToViewportCoordinates(textureCoordinates);

        // Konvertiere Viewport Coordinates zu Screen Coordinates
        Vector2 screenCoordinates = ViewportToScreenCoordinates(viewportCoordinates);

        // F�hre einen Raycast aus
        RaycastAndInteract(viewportCoordinates);
    }

    // Funktion zur Konvertierung von Texture Coordinates zu Viewport Coordinates
    private Vector2 TextureToViewportCoordinates(Vector2 textureCoordinates) {

        textureCoordinates = new Vector2(canvasTransform.sizeDelta.x * textureCoordinates.x, canvasTransform.sizeDelta.y * textureCoordinates.y);
        // Hier musst du die Logik f�r die Konvertierung implementieren
        // Beachte, dass dies von der Art und Weise abh�ngt, wie die Texture Coordinates generiert wurden
        // Annahme: textureCoordinates ist im Bereich von (0,0) bis (1,1)
        return textureCoordinates;
    }

    // Funktion zur Konvertierung von Viewport Coordinates zu Screen Coordinates
    private Vector2 ViewportToScreenCoordinates(Vector2 viewportCoordinates) {
        // Konvertiere Viewport Coordinates zu Screen Coordinates
        Vector2 screenCoordinates = new Vector2(
            viewportCoordinates.x * Screen.width,
            viewportCoordinates.y * Screen.height
        );
        return screenCoordinates;
    }

    // F�hre einen Raycast aus und interagiere mit UI-Elementen
    private void RaycastAndInteract(Vector2 screenCoordinates) {
        // Erstelle PointerEventData f�r den Raycast
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = screenCoordinates;

        // Erstelle eine Liste f�r Ergebnisse des Raycasts
        List<RaycastResult> results = new List<RaycastResult>();

        // F�hre den Raycast aus
        raycaster.Raycast(pointerEventData, results);

        // Iteriere durch die Ergebnisse des Raycasts
        foreach (RaycastResult result in results) {
            // Hier kannst du mit den Ergebnissen arbeiten, z.B. Events ausl�sen
            Debug.Log("Hit: " + result.gameObject.name);

            // F�ge hier die gew�nschten Aktionen hinzu, basierend auf dem getroffenen UI-Element
        }
    }
}