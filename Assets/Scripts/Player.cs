using Unity.Burst.Intrinsics;
using UnityEngine;
using System.Collections; // Importante para Coroutines
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
        StartCoroutine(Resetar("ataque-1", 0.5f));
        // Reinicia o timer
        timer = 0f;

        // (Opcional) depois de um tempo, volta o bool para false
    }
    // Coroutine opcional para resetar a variável depois de 1 segundo
    IEnumerator Resetar(string nomeDaVariavel, float tempoDeEspera)
    {
        // 1. **ESPERA**
        // Pausa a Coroutine pelo tempo especificado (o tempo da animação)
        yield return new WaitForSeconds(tempoDeEspera);

        // 2. **RESETA O BOOL**
        // Verifica se a variável ainda está true e a define como false
        if (animator.GetBool(nomeDaVariavel))
        {
            animator.SetBool(nomeDaVariavel, false);
            // (Opcional) Se você usa a variável ar_at.ataque, resete aqui:
            // ar_at.ataque = false; 
            Debug.Log($"Bool '{nomeDaVariavel}' resetado após {tempoDeEspera}s.");
            yield return new WaitForSeconds(tempoDeEspera);
            ar_at.ataque = false;
        }
    }
}
