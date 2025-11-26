using UnityEngine;

public class Upar : MonoBehaviour
{
    public GameObject linhasRetas;
    public GameObject Pixels;
    private ParticleSystem _pixels;
    // Cache do ParticleSystem para evitar GetComponent repetido
    private ParticleSystem _particleSystem;
    private ParticleSystem.MainModule _mainModule;
    
    // Cache dos gradientes para evitar criação repetida
    private Gradient _carismaGradient;
    private Gradient _inteligenciaGradient;
    private Gradient _constituicaoGradient;
    private Gradient _sabedoriaDestrezaGradient;

    // Configurações base que se aplicam a todos
    private const float START_SIZE = 0.2f;
    private const float FORCA_LIFETIME = 2.0f;

    private void Awake()
    {
        _pixels = Pixels.GetComponent<ParticleSystem>();
        // Cache do ParticleSystem na inicialização
        _particleSystem = linhasRetas.GetComponent<ParticleSystem>();
        _mainModule = _particleSystem.main;
        
        // Configuração base que aplica a todos
        _mainModule.startSize = START_SIZE;
        
        // Pré-criar os gradientes
        PreparaGradientes();
    }

    private void PreparaGradientes()
    {
        // Gradiente para Carisma
        _carismaGradient = new Gradient();
        _carismaGradient.SetKeys(
            new GradientColorKey[] { 
                new GradientColorKey(Color.yellow, 0.0f), 
                new GradientColorKey(new Color(1f, 0.5f, 0f), 1.0f) 
            },
            new GradientAlphaKey[] { 
                new GradientAlphaKey(1f, 0.0f), 
                new GradientAlphaKey(1f, 1.0f) 
            }
        );

        // Gradiente para Inteligência
        _inteligenciaGradient = new Gradient();
        _inteligenciaGradient.SetKeys(
            new GradientColorKey[] {
                new GradientColorKey(Color.yellow, 0.0f),
                new GradientColorKey(new Color(0.5f, 0f, 0.5f), 1.0f)
            },
            new GradientAlphaKey[] {
                new GradientAlphaKey(1f, 0.0f),
                new GradientAlphaKey(1f, 1.0f)
            }
        );

        // Gradiente para Constituição
        _constituicaoGradient = new Gradient();
        _constituicaoGradient.SetKeys(
            new GradientColorKey[] {
                new GradientColorKey(Color.yellow, 0.0f),
                new GradientColorKey(new Color(0.5f, 0f, 0.5f), 0.6f),
                new GradientColorKey(new Color(1f, 0.4f, 0.8f), 1.0f)
            },
            new GradientAlphaKey[] {
                new GradientAlphaKey(1f, 0.0f),
                new GradientAlphaKey(1f, 1.0f)
            }
        );

        // Gradiente compartilhado para Sabedoria e Destreza
        _sabedoriaDestrezaGradient = new Gradient();
        _sabedoriaDestrezaGradient.SetKeys(
            new GradientColorKey[] {
                new GradientColorKey(Color.yellow, 0.0f),
                new GradientColorKey(Color.green, 0.3f),
                new GradientColorKey(new Color(0.5f, 0f, 0.5f), 0.6f),
                new GradientColorKey(new Color(1f, 0.4f, 0.8f), 1.0f)
            },
            new GradientAlphaKey[] {
                new GradientAlphaKey(1f, 0.0f),
                new GradientAlphaKey(1f, 1.0f)
            }
        );
    }

    private void AtivarLinha()
    {
        StartCoroutine(DelayAtivar());
    }

    private System.Collections.IEnumerator DelayAtivar()
    {
        linhasRetas.SetActive(true);
        Pixels.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        linhasRetas.SetActive(false);
        Pixels.SetActive(false);
    }

    // Método base para configurar propriedades comuns
    private void ConfigurarBase()
    {
        linhasRetas.SetActive(true);
        // Reset para configurações base (caso alguma função tenha modificado)
        _mainModule.startSize = START_SIZE;
        _mainModule.startLifetime = _particleSystem.main.startLifetime.constant; // Volta ao valor original
    }

    public void UpCarisma()
    {
        ConfigurarBase();
        _mainModule.startColor = new ParticleSystem.MinMaxGradient(_carismaGradient);
        var main =_pixels.main; 
        main.startColor = Color.yellow;
        AtivarLinha();
    }

    public void UpForca()
    {
        ConfigurarBase();
        _mainModule.startColor = Color.red;
        _mainModule.startLifetime = FORCA_LIFETIME; // Apenas a Força tem lifetime diferente
        var main =_pixels.main; 
        main.startColor = Color.red;
        AtivarLinha();
    }

    public void UpInteligencia()
    {
        ConfigurarBase();
        _mainModule.startColor = new ParticleSystem.MinMaxGradient(_inteligenciaGradient);
        var main =_pixels.main; 
        main.startColor = new Color(0.5f, 0f, 0.5f);
        AtivarLinha();
    }

    public void UpConstituicao()
    {
        ConfigurarBase();
        _mainModule.startColor = new ParticleSystem.MinMaxGradient(_constituicaoGradient);
        var main =_pixels.main; 
        main.startColor = new Color(1f, 0.4f, 0.8f);
        AtivarLinha();
    }

    public void UpSabedoria()
    {
        ConfigurarBase();
        _mainModule.startColor = new ParticleSystem.MinMaxGradient(_sabedoriaDestrezaGradient);
        var main =_pixels.main; 
        main.startColor = new Color(1f, 0.4f, 0.8f);
        AtivarLinha();
    }

    public void UpDestreza()
    {
        ConfigurarBase();
        _mainModule.startColor = new ParticleSystem.MinMaxGradient(_sabedoriaDestrezaGradient);
        var main =_pixels.main; 
        main.startColor = new Color(1f, 0.4f, 0.8f);
        AtivarLinha();
    }
}