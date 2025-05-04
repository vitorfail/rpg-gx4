using UnityEngine;
using System.Collections;
using TMPro;

public class Iniciarcena : MonoBehaviour
{
    public GameObject objetoA; // arraste o GameObject que contém o TextMeshPro
    public GameObject objetoB;
    public GameObject objetoC;
    public GameObject objetoD;
    public GameObject objetoE;
    public GameObject objetoF;
    public GameObject objetoG;
    public GameObject objetoH;
    public GameObject objetoI;



    private TextMeshPro textoA;
    private TextMeshPro textoB;
    private TextMeshPro textoC;    
    private TextMeshPro textoD;
    private TextMeshPro textoE;
    private TextMeshPro textoF;   
    private TextMeshPro textoG;
    private TextMeshPro textoH;
    private TextMeshPro textoI;    
 

    public bool iniciar;
    public bool hasiniciar =false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textoA = objetoA.GetComponentInChildren<TextMeshPro>();
        textoB = objetoB.GetComponentInChildren<TextMeshPro>();
        textoC = objetoC.GetComponentInChildren<TextMeshPro>();
        textoD = objetoD.GetComponentInChildren<TextMeshPro>();
        textoE = objetoE.GetComponentInChildren<TextMeshPro>();
        textoF = objetoF.GetComponentInChildren<TextMeshPro>();
        textoG = objetoG.GetComponentInChildren<TextMeshPro>();
        textoH = objetoH.GetComponentInChildren<TextMeshPro>();
        textoI = objetoI.GetComponentInChildren<TextMeshPro>();


        objetoA.transform.localScale = new Vector3(0f, 0f, 0f);
        objetoB.transform.localScale = new Vector3(0f, 0f, 0f);
        objetoC.transform.localScale = new Vector3(0f, 0f, 0f);

        objetoD.transform.localScale = new Vector3(0f, 0f, 0f);
        objetoE.transform.localScale = new Vector3(0f, 0f, 0f);
        objetoF.transform.localScale = new Vector3(0f, 0f, 0f);

        objetoG.transform.localScale = new Vector3(0f, 0f, 0f);
        objetoH.transform.localScale = new Vector3(0f, 0f, 0f);
        objetoI.transform.localScale = new Vector3(0f, 0f, 0f);

        SetAlpha(textoA, 0f);
        SetAlpha(textoB, 0f);
        SetAlpha(textoC, 0f); // Invisível

        SetAlpha(textoD, 0f);
        SetAlpha(textoE, 0f);
        SetAlpha(textoF, 0f); // Invisível

        SetAlpha(textoG, 0f);
        SetAlpha(textoH, 0f);
        SetAlpha(textoI, 0f); // Invisível

  
    }

    // Update is called once per frame
    void Update(){
        if(iniciar && !hasiniciar){
            hasiniciar=true;
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

}
