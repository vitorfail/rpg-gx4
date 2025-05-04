using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class Light2DBlinkAndFalloff : MonoBehaviour
{
    [Header("Falloff Oscillation")]
    [Range(0f, 1f)] public float minFalloff = 0.2f;
    [Range(0f, 1f)] public float maxFalloff = 1f;
    public float falloffSpeed = 1f;

    [Header("Blinking Intensity")]
    public float blinkInterval = 1f;

    private Light2D light2D;
    private float blinkTimer = 0f;
    private bool isOn = true;

    void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    void Update()
    {
        // Oscilação suave do Falloff
        float t = Mathf.PingPong(Time.time * falloffSpeed, 1f);
        light2D.falloffIntensity = Mathf.Lerp(minFalloff, maxFalloff, t);

        // Alternância entre 1 e 0 na intensidade
        blinkTimer += Time.deltaTime;
        if (blinkTimer >= blinkInterval)
        {
            isOn = !isOn;
            light2D.intensity = isOn ? 1f : 0f;
            blinkTimer = 0f;
        }
    }
}
