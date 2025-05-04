using UnityEngine;
using System.Collections;

public class MoverQ2 : MonoBehaviour
{
    public float scale = 2f;     // Altura que o objeto vai subir
    public float moveSpeed = 2f;      // Velocidade da subida
    private Vector3 postition_q1;
    public bool shouldMove = true;
    public float duration = 0.2f;

    void Start()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        postition_q1 = transform.position; // Posição inicial
    }

    void Update()
    {
        if (shouldMove)
        {
            Vector3 vector = new Vector3(1f, 1f, 1f);
           StartCoroutine(ScaleOverTime(vector, duration));      
        }
        else{
            transform.localScale = new Vector3(0f, 0f, 0f);           
        }
    }
    IEnumerator ScaleOverTime(Vector3 target, float time)
    {
        Vector3 initialScale = transform.localScale;
        float elapsed = 0f;

        while (elapsed < time)
        {
            transform.localScale = Vector3.Lerp(initialScale, target, elapsed / time);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = target;
    }
}
