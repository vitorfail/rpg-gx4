using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class Ocilacao : MonoBehaviour
{
    [Header("Falloff Oscillation")]
    [Range(0f, 1f)] public float minFalloff = 0.2f;
    [Range(0f, 1f)] public float maxFalloff = 1f;

    [Header("Intensity Oscillation")]
    public float minIntensity = 0.5f;
    public float maxIntensity = 2f;

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

        // Oscila a intensidade e o falloff
        light2D.falloffIntensity = Mathf.Lerp(minFalloff, maxFalloff, t);
        light2D.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
    }
}
