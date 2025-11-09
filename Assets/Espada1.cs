using UnityEngine;

public class Espada1 : MonoBehaviour
{
    // Referência ao script que tem a variável Arma_ataque
    private Arma_ataque controlador;

    // Arrays para armazenar todos os efeitos do objeto
    private ParticleSystem[] particleSystems;
    private TrailRenderer[] trailRenderers;

    void Start()
    {
        // Procura automaticamente o controlador na cena
        controlador = Object.FindFirstObjectByType<Arma_ataque>();
        if (controlador == null)
        {
            Debug.LogWarning("Nenhum objeto com 'SeuScript' encontrado na cena!");
            return;
        }

        // Pega todos os ParticleSystems e TrailRenderers dentro deste GameObject e filhos
        particleSystems = GetComponentsInChildren<ParticleSystem>(true);
        trailRenderers = GetComponentsInChildren<TrailRenderer>(true);

        // Desativa todos os efeitos no início
        foreach (var ps in particleSystems)
        {
            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }

        foreach (var tr in trailRenderers)
        {
            tr.enabled = false;
        }
    }
    void Ativar()
    {
        if (controlador == null) return;

        bool armaAtiva = controlador.ataque;

        // Ativa ou desativa efeitos dependendo da variável
        foreach (var ps in particleSystems)
        {
            if (armaAtiva && !ps.isPlaying)
                ps.Play();
            else if (!armaAtiva && ps.isPlaying)
                ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }

        foreach (var tr in trailRenderers)
        {
            tr.enabled = armaAtiva;
        }
    }
}
