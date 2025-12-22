using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Utils: MonoBehaviour
{
    public GameObject[] botoes;
    public Camera cam;
    public static Utils Instance;
    void Awake()
    {
        Instance = this;
        cam = Camera.main;
        foreach (GameObject botao in botoes)
        {
            CanvasGroup b = botao.GetComponent<CanvasGroup>();
            b.alpha =0.0f;

        }
    }
    public static int CalcularModificador(int atributo)
    {
        return (atributo - 10) / 2;
    }
    public Coroutine MoverBotao(
        Vector3 posicaoInicial,
        float duracaoMovimento,
        float duracaoFade,
        float delay)
    {
        return StartCoroutine(MoverBotaoRoutine(
            posicaoInicial,
            duracaoMovimento,
            duracaoFade,
            delay
        ));
    }

    private IEnumerator MoverBotaoRoutine(
        Vector3 posicaoInicial,
        float duracaoMovimento,
        float duracaoFade,
        float delay)
    {
        if (delay > 0f)
            yield return new WaitForSeconds(delay);

        foreach (GameObject botao in botoes)
        {
            if (botao == null)
                continue;

            // Guarda a posição original (posição final do movimento)
            Vector3 posicaoOriginal = botao.transform.position;

            // Coloca o botão na posição inicial
            botao.transform.position = posicaoInicial;
            botao.SetActive(true);

            // CanvasGroup para fade
            CanvasGroup canvasGroup = botao.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
                canvasGroup = botao.AddComponent<CanvasGroup>();

            canvasGroup.alpha = 0f;

            // Inicia a animação individual
            StartCoroutine(AnimarBotao(
                botao,
                canvasGroup,
                posicaoInicial,
                posicaoOriginal,
                duracaoMovimento,
                duracaoFade
            ));
        }
    }
    private IEnumerator AnimarBotao(
        GameObject botao,
        CanvasGroup canvasGroup,
        Vector3 posicaoInicial,
        Vector3 posicaoFinal,
        float duracaoMovimento,
        float duracaoFade)
    {
        float tempo = 1.0f;

        while (tempo < Mathf.Max(duracaoMovimento, duracaoFade))
        {
            tempo += Time.deltaTime;

            // Fade In
            if (duracaoFade > 0f)
                canvasGroup.alpha = Mathf.Clamp01(tempo / duracaoFade);

            // Movimento
            if (duracaoMovimento > 0f)
            {
                float t = Mathf.Clamp01(tempo / duracaoMovimento);
                botao.transform.position = Vector3.Lerp(
                    posicaoInicial,
                    posicaoFinal,
                    t
                );
            }

            yield return null;
        }

        // Garantias finais
        canvasGroup.alpha = 1f;
        botao.transform.position = posicaoFinal;
    }


    public Coroutine ZoomEmObjeto(
        Transform alvo,
        float tamanhoZoom,
        float duracao)
    {
        return StartCoroutine(ZoomEmObjetoRoutine(
            alvo,
            tamanhoZoom,
            duracao
        ));
    }

    private IEnumerator ZoomEmObjetoRoutine(
        Transform alvo,
        float tamanhoZoom,
        float duracao)
    {
        if (cam == null || alvo == null) yield break;

        float zoomInicial = cam.orthographicSize;
        Vector3 posicaoInicial = cam.transform.position;

        // Limite mínimo para o eixo Y
        float yLimitado = Mathf.Max(alvo.position.y, -10f);

        Vector3 posicaoFinal = new Vector3(
            alvo.position.x+1.39f,
            yLimitado,
            posicaoInicial.z-1.3f // mantém o Z
        );

        float tempo = 0f;

        while (tempo < duracao)
        {
            tempo += Time.deltaTime;
            float t = tempo / duracao;

            // EaseOut
            t = Mathf.Sin(t * Mathf.PI * 0.5f);

            cam.orthographicSize = Mathf.Lerp(zoomInicial, tamanhoZoom, t);
            cam.transform.position = Vector3.Lerp(posicaoInicial, posicaoFinal, t);

            yield return null;
        }

        cam.orthographicSize = tamanhoZoom;
        cam.transform.position = posicaoFinal;
    }
}