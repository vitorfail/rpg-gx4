using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Script : MonoBehaviour
{
    public GameObject quem_ganhou;
    public TextMeshProUGUI quem_ganhou_text;
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
        Popup.Instancia.AtivarComFade(header_iniciativa, 0.5f, 0.1f);
        Popup.Instancia.AtivarComFade(Dados_iniciativa, 0.5f, 1.0f);
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
            Popup.Instancia.EscalarSuavemente(DadoIniciativa1, 1.1f, 0.5f);
            var back = BackgroundIniciativa1.GetComponent<UnityEngine.UI.Image>();
            back.color = Color.red;
            Popup.Instancia.AtivarComFade(quem_ganhou, 0.5f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            quem_ganhou_text.text = "Você Começa";

        }
        else
        {
            Popup.Instancia.EscalarSuavemente(DadoIniciativa2, 1.1f, 0.5f);
            var back = BackgroundIniciativa2.GetComponent<UnityEngine.UI.Image>();
            back.color = Color.red;
            Popup.Instancia.AtivarComFade(quem_ganhou, 0.5f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            quem_ganhou_text.text = "Você Começa";
        }
   
    }
}
