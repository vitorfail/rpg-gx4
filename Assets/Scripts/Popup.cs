using System.Collections;
using UnityEngine;


public class Popup : MonoBehaviour
{
    private static Popup _instancia;

    public static Popup Instancia
    {
        get
        {
            if (_instancia == null)
            {
                GameObject go = new GameObject("[GLOBAL EFFECTS]");
                _instancia = go.AddComponent<Popup>();
                DontDestroyOnLoad(go);
            }
            return _instancia;
        }
    }

    // ---------------------------- //
    //        FUNÇÃO DE FADE        //
    // ---------------------------- //
    public Coroutine AtivarComFade(GameObject obj, float duracaoFade, float delay = 0f)
    {
        return StartCoroutine(FadeRoutine(obj, duracaoFade, delay));
    }

    private IEnumerator FadeRoutine(GameObject obj, float duracaoFade, float delay)
    {
        if (obj == null) yield break;

        if (delay > 0) 
            yield return new WaitForSeconds(delay);

        obj.SetActive(true);

        CanvasGroup canvasGroup = obj.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = obj.AddComponent<CanvasGroup>();

        float tempo = 0f;
        canvasGroup.alpha = 0f;

        while (tempo < duracaoFade)
        {
            tempo += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, tempo / duracaoFade);
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }

    // ---------------------------- //
    //     FUNÇÃO DE ESCALONAR     //
    // ---------------------------- //
    public Coroutine EscalarSuavemente(GameObject objeto, float fatorEscala, float duracao)
    {
        return StartCoroutine(EscalaRoutine(objeto, fatorEscala, duracao));
    }

    private IEnumerator EscalaRoutine(GameObject objeto, float fatorEscala, float duracao)
    {
        if (objeto == null) yield break;

        Vector3 escalaInicial = objeto.transform.localScale;
        Vector3 escalaFinal = escalaInicial * fatorEscala;

        float tempo = 0f;

        while (tempo < duracao)
        {
            tempo += Time.deltaTime;
            float progresso = tempo / duracao;

            // EaseOutSine
            progresso = Mathf.Sin(progresso * Mathf.PI * 0.5f);

            objeto.transform.localScale = Vector3.Lerp(escalaInicial, escalaFinal, progresso);
            yield return null;
        }

        objeto.transform.localScale = escalaFinal;
    }
}