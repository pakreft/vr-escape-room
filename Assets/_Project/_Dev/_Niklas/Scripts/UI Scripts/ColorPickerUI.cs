using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorPickerUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {


    [Header("UI Element")]
    [SerializeField]    private Graphic uiElement; // UI-Element (Image, Text, etc.)

    [Header("Hover Color")]
    [SerializeField, Range(0f, 1f)]    private float hoverRed = 1f;
    [SerializeField, Range(0f, 1f)]    private float hoverGreen = 1f;
    [SerializeField, Range(0f, 1f)]    private float hoverBlue = 1f;
    [SerializeField, Range(0f, 1f)]    private float hoverAlpha = 1f;

    private Color normalColor; // Ursprüngliche Farbe des UI-Elements
    private Color hoverColor; // Farbe, wenn die Maus darüber schwebt


    void Start() {

        // Speichern der ursprünglichen Farbe
        normalColor = uiElement.color;

        // Setzen der Hover-Farbe basierend auf den Slider-Werten
        hoverColor = new Color(hoverRed, hoverGreen, hoverBlue, hoverAlpha);



    }
   
    

    
    // Wird aufgerufen, wenn die Maus über das Text Element geht
    public void OnPointerEnter(PointerEventData eventData) {


        uiElement.color = hoverColor;
    }

    // Wird aufgerufen, wenn die Maus das Text Element verlässt
    public void OnPointerExit(PointerEventData eventData) {
        // Setze die Farbe auf die ursprüngliche Farbe zurück, wenn die Maus das Element verlässt


        uiElement.color = normalColor;
    }
}
