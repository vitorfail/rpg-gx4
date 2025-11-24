using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PlayerAttribute
{
    Carisma,
    Forca,
    Inteligencia,
    Sabedoria,
    Destreza,
    Constituicao
}
public class Text_atributo : MonoBehaviour
{
    public PlayerAttribute atributo; 
    private TextMeshProUGUI textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        switch (atributo)
        {
            case PlayerAttribute.Carisma:
                textMesh.text = DadosJogador.Instance_jogador.playerData.carisma.ToString();
                break;
            case PlayerAttribute.Forca:
                textMesh.text = DadosJogador.Instance_jogador.playerData.forca.ToString();
                break;
            case PlayerAttribute.Inteligencia:
                textMesh.text = DadosJogador.Instance_jogador.playerData.inteligencia.ToString();
                break;
            case PlayerAttribute.Sabedoria:
                textMesh.text = DadosJogador.Instance_jogador.playerData.sabedoria.ToString();
                break;
            case PlayerAttribute.Destreza:
                textMesh.text = DadosJogador.Instance_jogador.playerData.destreza.ToString();
                break;
            case PlayerAttribute.Constituicao:
                textMesh.text = DadosJogador.Instance_jogador.playerData.contituicao.ToString();
                break;
        }
    }

    private void OnEnable()
    {
        // Registrar no evento do PlayerManager
        DadosJogador.Instance_jogador.OnPlayerStatsChanged += UpdateText;

        // Atualizar imediatamente ao habilitar
        UpdateText();
    }

    private void OnDisable()
    {
        // Desregistrar para evitar erros
        DadosJogador.Instance_jogador.OnPlayerStatsChanged -= UpdateText;
    }

    private void UpdateText()
    {
        switch (atributo)
        {
            case PlayerAttribute.Carisma:
                textMesh.text = DadosJogador.Instance_jogador.playerData.carisma.ToString();
                break;
            case PlayerAttribute.Forca:
                textMesh.text = DadosJogador.Instance_jogador.playerData.forca.ToString();
                break;
            case PlayerAttribute.Inteligencia:
                textMesh.text = DadosJogador.Instance_jogador.playerData.inteligencia.ToString();
                break;
            case PlayerAttribute.Sabedoria:
                textMesh.text = DadosJogador.Instance_jogador.playerData.sabedoria.ToString();
                break;
            case PlayerAttribute.Destreza:
                textMesh.text = DadosJogador.Instance_jogador.playerData.destreza.ToString();
                break;
            case PlayerAttribute.Constituicao:
                textMesh.text = DadosJogador.Instance_jogador.playerData.contituicao.ToString();
                break;
        }
    }
}
