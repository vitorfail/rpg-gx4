using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Script : MonoBehaviour
{
    public GameObject Roller;
    public DiceRoller objeto_dado_Player;
    public DiceRoller Objeto_dado_iniciativa1;
    public GameObject DadoIniciativa1;
    public GameObject BackgroundIniciativa1;
    public DiceRoller Objeto_dado_iniciativa2;
    public GameObject DadoIniciativa2;
    public GameObject BackgroundIniciativa2;

     public GameObject Dados_iniciativa;
    public static Tutorial_Script variaveis_tutorial;
    public GameObject header_iniciativa;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Iniciar_tutorial()
    {
        StartCoroutine(AtivarComFade(header_iniciativa, 0.5f, 0.1f));
        Roller.SetActive(true);
        StartCoroutine(AtivarComFade(Dados_iniciativa, 0.5f, 1.0f));
        StartCoroutine(Rolar_Iniciativa(1.5f));

    }
    IEnumerator Delay(float f)
    {
        yield return new WaitForSeconds(f); // outro delay, se quiser
    }
    IEnumerator Rolar_Iniciativa( float f)
    {
         yield return new WaitForSeconds(f);
        string result = Objeto_dado_iniciativa1.Rolar();
        string result2 = Objeto_dado_iniciativa2.Rolar();
        yield return new WaitForSeconds(3.7f);
        if(int.Parse(result)> int.Parse(result2))
        {
            StartCoroutine(EscalarSuavemente(DadoIniciativa1, 1.1f, 0.5f));
            var back = BackgroundIniciativa1.GetComponent<UnityEngine.UI.Image>();
            back.color = Color.red;
            
        }
        else
        {
            StartCoroutine(EscalarSuavemente(DadoIniciativa2, 1.1f, 0.5f));
            var back = BackgroundIniciativa2.GetComponent<UnityEngine.UI.Image>();
            back.color = Color.red;

        }
   
    }
    // Método para ativar objeto com fade-in usando CanvasGroup
    IEnumerator AtivarComFade(GameObject obj, float duracaoFade, float f)
    {
        if (obj == null) yield break;
        
        yield return new WaitForSeconds(f); // outro delay, se quiser

        obj.SetActive(true);
        
        // Tenta pegar CanvasGroup, se não existir, cria um
        CanvasGroup canvasGroup = obj.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = obj.AddComponent<CanvasGroup>();
        
        // Fade-in
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
    IEnumerator EscalarSuavemente(GameObject objeto, float fatorEscala, float duracao)
    {
        if (objeto == null) yield break;
        
        Vector3 escalaInicial = objeto.transform.localScale;
        Vector3 escalaFinal = escalaInicial * fatorEscala;
        
        float tempo = 0f;
        
        while (tempo < duracao)
        {
            tempo += Time.deltaTime;
            float progresso = tempo / duracao;
            // Usando EaseOutBack para um efeito mais "elástico" (opcional)
            progresso = Mathf.Sin(progresso * Mathf.PI * 0.5f); // EaseOutSine
            objeto.transform.localScale = Vector3.Lerp(escalaInicial, escalaFinal, progresso);
            yield return null;
        }
        
        objeto.transform.localScale = escalaFinal;
    }
}
