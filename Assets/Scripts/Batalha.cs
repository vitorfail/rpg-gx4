using System.Collections;
using UnityEngine;

public class Batalha : MonoBehaviour
{
    public float targetSize = 4.77f;
    public Vector3 targetPosition = new Vector3(0f, 0f, -10f);
    public float transitionSpeed = 2f;
    public Camera cam;
    public void Ataque_1()
    {
        Debug.Log(RenderPlayer.player_1.Classes);
        if (RenderPlayer.player_1.Classes=="Guerreiro")
        {
            StartCoroutine(TransitionCamera());
        }
    }
    IEnumerator TransitionCamera()
    {
        float startSize = cam.orthographicSize;
        Vector3 startPosition = cam.transform.position;

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * transitionSpeed;

            cam.orthographicSize = Mathf.Lerp(startSize, targetSize, t);
            cam.transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            yield return null;
        }

        cam.orthographicSize = targetSize;
        cam.transform.position = targetPosition;
    }
}
