using UnityEngine;
using System;
using UnityEngine.UI;
public class AgregarCor : MonoBehaviour
{
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public Color corAtual;

    public delegate void CorAlteradaDelegate(Color novaCor);
    public event CorAlteradaDelegate OnCorAlterada;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        redSlider.onValueChanged.AddListener(delegate { AtualizarCor(); });
        greenSlider.onValueChanged.AddListener(delegate { AtualizarCor(); });
        blueSlider.onValueChanged.AddListener(delegate { AtualizarCor(); });

        AtualizarCor(); // aplica valor inicial
    }

    public void AtualizarCor()
    {
        corAtual = new Color(24.0f, 48.0f, 80.0f, 1f);
        OnCorAlterada?.Invoke(corAtual);
    }
}
