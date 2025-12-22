using System;
using UnityEngine;
using UnityEngine.UI;

public class SpriteColorController : MonoBehaviour
{
    public Slider redSlider;
    public Slider greenSlider;
    private PlayerData_SO player;
    public Slider blueSlider;
    public Material spriteMaterial; // Arraste o Material no Inspector
    public Color targetColor = Color.red; // Cor desejada
    void Start()
    {
        player = DadosJogador.Instance_jogador.playerData;
        redSlider.onValueChanged.AddListener(delegate { AtualizarCor(); });
        greenSlider.onValueChanged.AddListener(delegate { AtualizarCor(); });
        blueSlider.onValueChanged.AddListener(delegate { AtualizarCor(); });

        AtualizarCor(); // aplica valor inicial
    }

    public void AtualizarCor()
    {
        player.color = new float[3];
        player.color[0] = redSlider.value;
        player.color[1] = greenSlider.value;
        player.color[2] = blueSlider.value;
        targetColor = new Color(redSlider.value, greenSlider.value, blueSlider.value, 1f);
        spriteMaterial.SetColor("_Color", targetColor);

    }
}