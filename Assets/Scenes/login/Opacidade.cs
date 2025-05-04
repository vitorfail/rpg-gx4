using UnityEngine;
using System.Collections;

public class Opacidade : MonoBehaviour
{
    public float fadeSpeed = 1f; // Velocidade da transição (quanto maior, mais rápido)
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public bool diminuir;

    public float duration = 0.2f;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Color color = spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.color = color;
        if (spriteRenderer == null)
        {
            Debug.LogError("Nenhum SpriteRenderer encontrado neste GameObject.");
            enabled = false;
            return;
        }
        originalColor = spriteRenderer.color;
    }
    public void Opacity(){
        diminuir= true;
    }
    void Update()
    {
        if(diminuir){
            if (spriteRenderer.color.a < 1f)
            {
                Vector3 vector = new Vector3(1f, 1f, 1f);
                Color color = spriteRenderer.color;
                color.a += fadeSpeed * Time.deltaTime;
                color.a = Mathf.Clamp01(color.a); // Garante que o alfa fique entre 0 e 1
                spriteRenderer.color = color;
            }
        }
    }
}
