using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Script : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject quem_ganhou;
    public TextMeshProUGUI quem_ganhou_text;
    public TextMeshProUGUI bonus1;
    public TextMeshProUGUI bonus2;
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
    void Start()
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
        int modificador1 = Utils.CalcularModificador(RenderPlayer.player_1.playerData.destreza);
        string result = Objeto_dado_iniciativa1.Rolar();
        string result2 = Objeto_dado_iniciativa2.Rolar();
        if (modificador1 < 0){
            bonus1.text ="<color=red>" +Utils.CalcularModificador(RenderPlayer.player_1.playerData.destreza).ToString()+"</color>";
        }
        if (modificador1 > 0){
            bonus1.text ="<color=green>" +Utils.CalcularModificador(RenderPlayer.player_1.playerData.destreza).ToString()+"</color>";
        }
        if (modificador1 == 0){
            bonus1.text ="<color=yellow>" +Utils.CalcularModificador(RenderPlayer.player_1.playerData.destreza).ToString()+"</color>";
        }
        yield return new WaitForSeconds(3.7f);
        
        if(int.Parse(result)+modificador1> int.Parse(result2))
        {
            Popup.Instancia.EscalarSuavemente(DadoIniciativa1, 1.1f, 0.5f);
            var back = BackgroundIniciativa1.GetComponent<UnityEngine.UI.Image>();
            back.color = Color.red;
            Popup.Instancia.AtivarComFade(quem_ganhou, 0.5f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            quem_ganhou_text.text = "Você Começa";
            yield return new WaitForSeconds(1.1f);
            quem_ganhou.SetActive(false);
            DadoIniciativa1.SetActive(false);
            DadoIniciativa2.SetActive(false);
            if (player1)
            {
                Utils.Instance.ZoomEmObjeto(player1.transform, 3.1f, 0.6f, 1.47f);
                //yield return new WaitForSeconds(0.6f);
                Vector3 p_inicial = new Vector3(-621.0f,-284.0f,0.0f);
                Utils.Instance.MoverBotao(p_inicial,1.0f, 1.0f, 1.0f);
                header_iniciativa.SetActive(false);
            }
        }
        else
        {
            Popup.Instancia.EscalarSuavemente(DadoIniciativa2, 1.1f, 0.5f);
            var back = BackgroundIniciativa2.GetComponent<UnityEngine.UI.Image>();
            back.color = Color.red;
            Popup.Instancia.AtivarComFade(quem_ganhou, 0.5f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            quem_ganhou_text.text = "Inimigo Começa";
                        yield return new WaitForSeconds(1.1f);
            DadoIniciativa1.SetActive(false);
            DadoIniciativa2.SetActive(false);
            quem_ganhou.SetActive(false);
            Utils.Instance.ZoomEmObjeto(player2.transform, 3.1f, 1.0f, -1.39f);
            header_iniciativa.SetActive(false);
        }
    }
}
