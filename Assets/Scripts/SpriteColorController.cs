using System;
using UnityEngine;
using UnityEngine.UI;

public class SpriteColorController : MonoBehaviour
{
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public Material spriteMaterial; // Arraste o Material no Inspector
    public Color targetColor = Color.red; // Cor desejada
    void Start()
    {
        redSlider.onValueChanged.AddListener(delegate { AtualizarCor(); });
        greenSlider.onValueChanged.AddListener(delegate { AtualizarCor(); });
        blueSlider.onValueChanged.AddListener(delegate { AtualizarCor(); });

        AtualizarCor(); // aplica valor inicial
    }

    public void AtualizarCor()
    {
        targetColor = new Color(redSlider.value, greenSlider.value, blueSlider.value, 1f);
        spriteMaterial.SetColor("_Color", targetColor);

    }
}