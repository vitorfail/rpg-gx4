using UnityEngine;
using System.Collections;
using TMPro;
using Unity.VisualScripting;

public class Iniciarcena : MonoBehaviour
{
    public AudioLoading loading;
    public AudioTheme theme;
    public AudioLetras letras;
    public GameObject objetoA, objetoB, objetoC, objetoD, 
    objetoE, objetoF, objetoG, objetoH, objetoI, objetoJ, objetoK, objetoL, objetoM,objetoN,objetoO,objetoP, objetoQ, objetoR;
    public bool iniciar;
    public bool hasiniciar =false;
    public int proximo =0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] objs= new GameObject[] {objetoA,objetoB,objetoC, objetoD, objetoE};
        DiminuirTodos(objs);
  
    }

    // Update is called once per frame
    public void DiminuirTodos(GameObject[] objetos)
    {
        foreach (GameObject objeto in objetos)
        {
            RectTransform rect = objeto.GetComponent<RectTransform>();
            rect.localScale = new Vector3(10f,10f,10f);
            TextMeshProUGUI  cor =objeto.GetComponent<TextMeshProUGUI>();
            Color novaCor = cor.color;     // copia o valor da cor
            novaCor.a = 0f;                // modifica o alpha
            cor.color = novaCor;        
        }
    }
    void Update(){
        if(iniciar && !hasiniciar){
            hasiniciar=true;
            Iniciar();
        }
    }
    void Iniciar(){
        loading.play = true;
        theme.play = true;
        GerenciarCena();
    }
    public void PularTexto(){
        proximo= proximo +1;
        GerenciarCena();
    }
    public void GerenciarCena(){
        if(proximo ==0){
            StartCoroutine(Aumentar(objetoA, 2f));
            StartCoroutine(Aumentar(objetoB,3.5f));
            StartCoroutine(Aumentar(objetoC,4.5f));
            StartCoroutine(Aumentar(objetoD,5.5f));
            StartCoroutine(Aumentar(objetoE,6.5f));
        }
        if(proximo ==1){
            StartCoroutine(Aumentar(objetoF, 2f));
            StartCoroutine(Aumentar(objetoG,4.5f));
            StartCoroutine(Aumentar(objetoH,7.5f));
            StartCoroutine(Aumentar(objetoI,8.5f));
            StartCoroutine(Aumentar(objetoJ,9.5f));
            StartCoroutine(Aumentar(objetoK,10.5f));
            StartCoroutine(Aumentar(objetoL,11.5f));
            StartCoroutine(Aumentar(objetoM,12.5f));
            StartCoroutine(Aumentar(objetoN,13.5f));
            StartCoroutine(Aumentar(objetoO,14.5f));
            StartCoroutine(Aumentar(objetoP,15.5f));
            StartCoroutine(Aumentar(objetoQ,16.5f));
            StartCoroutine(Aumentar(objetoR,17.5f));
        }
    }
    IEnumerator Aumentar(GameObject r, float f){
        yield return new WaitForSeconds(f);
        RectTransform rect = r.GetComponent<RectTransform>();
        rect.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        TextMeshProUGUI cor =r.GetComponent<TextMeshProUGUI>();
        Color novaCor = cor.color;     // copia o valor da cor
        float duracao = 0.5f; // duração do fade em segundos
        float t = 0f;

        while (t < duracao)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, t / duracao);
            novaCor.a = alpha;
            cor.color = novaCor;
            yield return null;
        }

        // Garante que o alpha chegue a 1
        novaCor.a = 1f;
        cor.color = novaCor;
        letras.play= true;
    }

}
