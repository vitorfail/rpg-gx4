using UnityEngine;
using UnityEngine.UI; // Necessário para usar o tipo Image
using System.Collections;

public class HP : MonoBehaviour
{
    [Header("Configurações de UI")]
    public GameObject objeto;
    public Image fundo;
    public Image barra;

    [Header("Atributos")]
    public int vida;
    private int vidaMaxima; // Para calcular a proporção
    private float larguraMaximaBarra = 488f;

    private Vector3 posicaoOriginal;
    private RectTransform barraRect;

    void OnEnable()
    {
        // Referências automáticas para o que está dentro deste objeto
        barraRect = barra.GetComponent<RectTransform>();
        posicaoOriginal = objeto.transform.localPosition;
        vidaMaxima = vida;

        // Inicia a animação de movimento
        StartCoroutine(AnimarObjeto());
        
        // Inicializa a barra com o valor atual
        AtualizarInterface(vida); // Passa a vida atual
    }

    // --- MOVIMENTAÇÃO ---
    IEnumerator AnimarObjeto()
    {
        Vector3 destino = posicaoOriginal + new Vector3(-85, 0, 0);

        if (Mathf.Approximately(objeto.transform.eulerAngles.y, 180f))
        {
            destino = posicaoOriginal + new Vector3(85, 0, 0);
        }
        float duracao = 1.0f; // Tempo da animação (1 segundo)
        float tempo = 0;

        objeto.transform.localPosition = posicaoOriginal;

        tempo = 0; // Reseta o tempo para a volta

        // Volta para a posição original
        while (tempo < duracao)
        {
            tempo += Time.deltaTime;
            objeto.transform.localPosition = Vector3.Lerp(destino, posicaoOriginal, tempo / duracao);
            yield return null;
        }
    }

    // --- SISTEMA DE VIDA ---
    public void AumentarVida(int quantidade)
    {
        vida += quantidade;
        // Impede que a vida passe do máximo
        vida = Mathf.Clamp(vida, 0, vidaMaxima);
        AtualizarInterface(vida); // Atualiza com o novo valor
    }

    public void DiminuirVida(int quantidade)
    {
        vida -= quantidade;
        // Impede que a vida seja menor que zero
        vida = Mathf.Clamp(vida, 0, vidaMaxima);
        AtualizarInterface(vida); // Atualiza com o novo valor
    }

    // Método modificado para receber o valor da vida como parâmetro
    public void AtualizarInterface(int novaVida)
    {
        // Atualiza a variável vida com o novo valor
        vida = novaVida;
        
        // Garante que a vida não ultrapasse os limites
        vida = Mathf.Clamp(vida, 0, vidaMaxima);
        
        // Cálculo da proporção: (vida atual / vida total) * largura da barra
        float novaLargura = ((float)vida / vidaMaxima) * larguraMaximaBarra;
        
        // Aplica a nova largura mantendo a altura (y) original
        if (barraRect != null)
        {
            barraRect.sizeDelta = new Vector2(novaLargura, barraRect.sizeDelta.y);
        }
        else
        {
            Debug.LogWarning("barraRect não foi inicializado. Certifique-se de chamar Inicializar() primeiro.");
        }
    }
    
    public void Inicializar(int vidaInicial)
    {
        vidaMaxima = vidaInicial;
        vida = vidaInicial;
        
        // Inicializa a referência do RectTransform se ainda não foi feita
        if (barraRect == null && barra != null)
        {
            barraRect = barra.GetComponent<RectTransform>();
        }
        
        AtualizarInterface(vidaInicial); // Inicializa com o valor máximo
    }
    
    // Sobrecarga do método para manter compatibilidade
    public void AtualizarInterface()
    {
        AtualizarInterface(vida); // Usa o valor atual da vida
    }
}