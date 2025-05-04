using UnityEngine;
using System.Collections;

public class Diminuir : MonoBehaviour
{
    public Opacidade op;
    public Vector3 targetScale = new Vector3(1f, 1f, 1f); // Tamanho final
    public Vector3 initialScale =new Vector3(8f,8f,8f);
    public float duration = 3f; // Tempo total para reduzir
    public float delayBeforeStart = 1f; // Delay inicial antes de começar
    public AnimationCurve smoothCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    public bool diminuir;

    private bool hasStarted = false;

    void Start()
    {
        transform.localScale = initialScale;
    }
    void Update()
    {
        if(diminuir && !hasStarted)
        {
             hasStarted = true;
            Vector3 vector = new Vector3(1f, 1f, 1f);
            StartCoroutine(ReduceScale()); 
            op.Opacity();     
        }
    }
    public void Aumentar_Barbaro(){
        diminuir= true;
        op.Opacity();
    }
    public void Aumentar_dragao(){
        diminuir= true;
        op.Opacity();
    }

    IEnumerator ReduceScale()
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = smoothCurve.Evaluate(elapsed / duration); // Suaviza a curva de transição
            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
