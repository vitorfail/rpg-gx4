using Unity.Burst.Intrinsics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;

    public Arma_ataque ar_at;
    private float timer = 0f;
    private float attackInterval = 10f; // 60 segundos

    void Start()
    {   
        ar_at = FindFirstObjectByType<Arma_ataque>(); 
        // Pega o componente Animator do mesmo objeto
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("⚠️ Nenhum Animator encontrado no objeto Player!");
        }
    }

    void OnMouseDown()
    {
        Ataque();

    }
    void Ataque()
    {
        ar_at.ataque = true;
        Debug.Log("Ataque-1 ativado!");
        // Ativa o bool "ataque-1" como true
        animator.SetBool("ataque-1", true);
        // Reinicia o timer
        timer = 0f;

        // (Opcional) depois de um tempo, volta o bool para false
    }
    // Coroutine opcional para resetar a variável depois de 1 segundo
    private System.Collections.IEnumerator ResetAtaque()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("ataque-1", false);
    }
}
