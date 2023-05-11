using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 2.0f;
    public bool isMovingLeft = true;
    private bool playing = true;
    public float horizontalMovement = 0;
    public int player1_Score = 4;
    public int player2_Score = 4;
    GameObject gameObject1;

    private void Update()
    {
        Direction();
        Boarders();
    }

    void Direction()
    {
        if (playing)
        {
            if (isMovingLeft)
            {
                transform.Translate(new Vector3(-1, horizontalMovement, 0) * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(new Vector3(1, horizontalMovement, 0) * speed * Time.deltaTime);
            }
        }

    }
    
    void Boarders()
    {
        if (transform.position.y >= 4.85)
        {
            transform.position = new Vector3(transform.position.x, 4.81f, 0f);
            horizontalMovement *= -1;
        }
        else if (transform.position.y <= -4.85)
        {
            horizontalMovement *= -1;
            transform.position = new Vector3(transform.position.x, -4.81f, 0f);
        }
        else if (transform.position.x < -9.02)
        {
            transform.position = new Vector3(0, 0, 0);
            gameObject1 = GameObject.Find("Player1Points ("+player1_Score+")");
            Destroy(gameObject1);
            player1_Score--;
            if(player1_Score == 0)
            {
                playing = false;
            }

        }
        else if (transform.position.x > 9.02)
        {
            transform.position = new Vector3(0, 0, 0);
            transform.position = new Vector3(0, 0, 0);
            gameObject1 = GameObject.Find("Player2Points (" + player2_Score + ")");
            Destroy(gameObject1);
            player2_Score--;
            if (player2_Score == 0)
            {
                playing = false;
            }
        }
    }
}
