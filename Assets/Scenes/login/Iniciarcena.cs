using UnityEngine;
using System.Collections;
using TMPro;

public class Iniciarcena : MonoBehaviour
{
    public AudioLoading loading;
    public AudioTheme theme;
    public AudioLetras letras;
    public GameObject objetoA, objetoB, objetoC, objetoD, objetoE, objetoF, objetoG, objetoH, objetoI;

    private RectTransform objA;
    private RectTransform objB;
    private RectTransform objC;
    private RectTransform objD;
    private RectTransform objE;
    private RectTransform objF;
    private RectTransform objG;
    private RectTransform objH;
    private RectTransform objI; 

    public bool iniciar;
    public bool hasiniciar =false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objA = ProcessarObjeto(objetoA);
        objB = ProcessarObjeto(objetoB);
        objC = ProcessarObjeto(objetoC);
        objD = ProcessarObjeto(objetoD);
        objE = ProcessarObjeto(objetoE);

        RectTransform[] objs= new RectTransform[] {objA,objB,objC, objD, objE};
        DiminuirTodos(objs);
  
    }

    // Update is called once per frame
    public void DiminuirTodos(RectTransform[] objetos)
    {
        foreach (RectTransform objeto in objetos)
        {
            objeto.localScale = new Vector3(0f,0f,0f);
        }
    }
    void Update(){
        if(iniciar && !hasiniciar){
            hasiniciar=true;
            Iniciar();
        }
    }
    public RectTransform ProcessarObjeto(GameObject objeto)
    {
        var rect = objeto.GetComponent<RectTransform>();
        if (rect == null)
        {
            return null;
        }
        else{
            return rect;
        }
    }
    public void SetAlpha(TextMeshPro texto, float alpha)
    {
        if (texto != null)
        {
            Color corAtual = texto.color;
            corAtual.a = Mathf.Clamp01(alpha); // Garante valor entre 0 e 1
            texto.color = corAtual;
        }
    }
    void Iniciar(){
        loading.play = true;
        theme.play = true;
        Aumentar(objA, 7f);
        Aumentar(objB,3f);
        Aumentar(objC,3f);

    }
    IEnumerator FuncaoComDelay(float f)
    {
        yield return new WaitForSeconds(f); // Delay de 2 segundos
    }
    public void Aumentar(RectTransform rect, float f){
        FuncaoComDelay(f);
        rect.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        letras.play= true;
    }

}
