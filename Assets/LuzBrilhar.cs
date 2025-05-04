using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class Light2DFalloffOscillator : MonoBehaviour
{
    [Header("Falloff Range")]
    [Range(0f, 1f)] public float minFalloff = 0.2f;
    [Range(0f, 1f)] public float maxFalloff = 1f;

    [Header("Oscillation Speed")]
    public float speed = 1f;

    private Light2D light2D;

    void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1f);
        float falloff = Mathf.Lerp(minFalloff, maxFalloff, t);
        light2D.falloffIntensity = falloff;
    }
}
