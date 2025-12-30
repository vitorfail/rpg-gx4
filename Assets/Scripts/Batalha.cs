using System.Collections;
using UnityEngine;

public class Batalha : MonoBehaviour
{
    public float targetSize = 4.77f;
    public Vector3 targetPosition = new Vector3(0f, 0f, -10f);
    public float transitionSpeed = 2f;
    public GameObject menus;
    public GameObject player1;
    public GameObject player2;
    public float speed = 2f;
    public Camera cam;
    public void Ataque_1(int i)
    {
        if (RenderPlayer.player_1.Classes=="Guerreiro")
        {
            StartCoroutine(TransitionCamera());
            menus.SetActive(false);
            //Move(m);
            if (i == 1)
            {
                Move(MoveOption.Player1ToPlayer2);   
                StartCoroutine(SelecionarAcao(player1));
            }
            if (i == 2)
            {
                Move(MoveOption.Player2ToPlayer1);   
            }
        }
        if (RenderPlayer.player_1.Classes=="Barbaro")
        {
            StartCoroutine(TransitionCamera());
            menus.SetActive(false);
            //Move(m);
            if (i == 1)
            {
                Move(MoveOption.Player1ToPlayer2);   
                StartCoroutine(SelecionarAcao(player1));
            }
            if (i == 2)
            {
                Move(MoveOption.Player2ToPlayer1);   
            }
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

    IEnumerator SelecionarAcao(GameObject g)
    {
        yield return new WaitForSeconds(0.5f);
        RenderPlayer play = g.GetComponent<RenderPlayer>();
        play.Ataque();
    }
    public enum MoveOption
    {
        Player1ToPlayer2,
        Player2ToPlayer1
    }
    public void Move(MoveOption option)
    {
        switch (option)
        {
            case MoveOption.Player1ToPlayer2:
                StartCoroutine(MoveHorizontal(player1, player2));
                break;

            case MoveOption.Player2ToPlayer1:
                StartCoroutine(MoveHorizontal(player2, player1));
                break;
        }
    }
    IEnumerator MoveHorizontal(GameObject from, GameObject to)
    {
        Vector3 startPos = from.transform.position;
        Vector3 targetPos = new Vector3(
            to.transform.position.x-3.0f, // move só no X
            startPos.y,
            startPos.z
        );

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            from.transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        from.transform.position = targetPos;
        yield return new WaitForSeconds(0.01f);
    }
}
