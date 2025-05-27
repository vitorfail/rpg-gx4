using UnityEngine;

public class Cores : MonoBehaviour
{
    private SpriteRenderer sprite;
    public float r;
    public float g;
    public float b;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    public void MudarCor()
    {
        sprite.color = new Color(r, g, b, sprite.color.a);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
