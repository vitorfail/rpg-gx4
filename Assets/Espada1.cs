using UnityEngine;
using UnityEngine.VFX;

public class Espada1 : MonoBehaviour
{
    // Referência ao script que tem a variável Arma_ataque
    private Arma_ataque controlador;

    // Arrays para armazenar todos os efeitos do objeto
    private VisualEffect[] particleSystems;
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
        particleSystems = GetComponentsInChildren<VisualEffect>(true);
        trailRenderers = GetComponentsInChildren<TrailRenderer>(true);

        // Desativa todos os efeitos no início
        foreach (var ps in particleSystems)
        {
            ps.Stop();
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
            if (armaAtiva && ps.aliveParticleCount < 0)
                ps.Play();
            else if (!armaAtiva && ps.aliveParticleCount > 0)
                ps.Stop();
        }

        foreach (var tr in trailRenderers)
        {
            tr.enabled = armaAtiva;
        }
    }
}
