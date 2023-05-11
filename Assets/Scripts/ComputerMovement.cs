using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerMovement : MonoBehaviour
{
    GameObject gameOb;

    private void Start()
    {
        gameOb = GameObject.Find("Ball");
        
    }


    private void Update()
    {
        transform.position = new Vector3(transform.position.x, gameOb.transform.position.y *.72f, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ball" && this.gameObject.name != "Opponent")
        {
            collision.gameObject.GetComponent<Ball>().isMovingLeft = false;
            collision.gameObject.GetComponent<Ball>().horizontalMovement = Random.Range(0.0f, 1);
        }
        else
        {
            collision.gameObject.GetComponent<Ball>().isMovingLeft = true;
            collision.gameObject.GetComponent<Ball>().horizontalMovement = Random.Range(0.0f, 1);

        }
    }
}
