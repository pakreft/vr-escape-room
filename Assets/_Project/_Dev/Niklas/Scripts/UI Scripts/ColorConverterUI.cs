using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorConverterUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    [SerializeField] Image imageComponent;
    [SerializeField] TextMeshProUGUI textComponent;

    private Color textOriginalColor;
    private Color colorbgOriginalColor;

    void Start() {
        // Stelle sicher, dass das Game Object ein Text Component hat

        InputRelaySink.Instance.OnRaycastResult += InputRelaySink_OnRaycastResult;

        textOriginalColor = textComponent.color;
        colorbgOriginalColor = imageComponent.color;
        
    }

    private void InputRelaySink_OnRaycastResult(object sender, InputRelaySink.OnRaycastResultEventArgs e) {

        List<string> raycastResultStrings = new List<string>();
        
        foreach (var result in e.raycastResults) {
            raycastResultStrings.Add(result.gameObject.name);
            //Debug.Log(result.gameObject.name);
        }
        while (raycastResultStrings.Count > 10) {
            raycastResultStrings.RemoveAt(0); // Entferne das älteste Element
        }
        // Debug.Log(raycastResultStrings.Count);
        if (raycastResultStrings.Contains(imageComponent.gameObject.name)) {
            ConvertColor();
        } else if (!raycastResultStrings.Contains(imageComponent.gameObject.name)) {
            ConvertColorToOriginal();
        }
        
        
    }
    
    // Wird aufgerufen, wenn die Maus über das Text Element geht
    public void OnPointerEnter(PointerEventData eventData) {
        // Invertiere die Farbe, wenn die Maus darüber schwebt
        if (textComponent != null) {
            textComponent.color = new Color(0, 0, 0, textOriginalColor.a);
        }
        if (imageComponent != null) {
            imageComponent.color = new Color(0, 1, 0, colorbgOriginalColor.a);
        }
    }
    
    private void ConvertColor() {

        if (textComponent != null) {
            textComponent.color = new Color(0, 0, 0, textOriginalColor.a);
        }
        if (imageComponent != null) {
            imageComponent.color = new Color(0, 1, 0, colorbgOriginalColor.a);
        }
    }
    
    private void ConvertColorToOriginal() {

        imageComponent.color = colorbgOriginalColor;
        textComponent.color = textOriginalColor;
    }
     
    // Wird aufgerufen, wenn die Maus das Text Element verlässt
    public void OnPointerExit(PointerEventData eventData) {
        // Setze die Farbe auf die ursprüngliche Farbe zurück, wenn die Maus das Element verlässt
        if (textComponent != null) {
            textComponent.color = textOriginalColor;
        }

        if (imageComponent != null) {
            imageComponent.color = colorbgOriginalColor;
        }
    }
     
}
