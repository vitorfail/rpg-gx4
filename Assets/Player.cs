using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private float timer = 0f;
    private float attackInterval = 10f; // 60 segundos

    void Start()
    {
        // Pega o componente Animator do mesmo objeto
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("⚠️ Nenhum Animator encontrado no objeto Player!");
        }
    }

    void Update()
    {
        // Conta o tempo
        timer += Time.deltaTime;

        // Quando chegar a 60 segundos...
        if (timer >= attackInterval)
        {
            // Ativa o bool "ataque-1" como true
            animator.SetBool("ataque-1", true);

            Debug.Log("Ataque-1 ativado!");

            // Reinicia o timer
            timer = 0f;

            // (Opcional) depois de um tempo, volta o bool para false
            StartCoroutine(ResetAtaque());
        }
    }

    // Coroutine opcional para resetar a variável depois de 1 segundo
    private System.Collections.IEnumerator ResetAtaque()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("ataque-1", false);
    }
}
