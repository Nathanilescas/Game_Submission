using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _speed = 5.0f;

    void Update()
    {
        PaddleMovement();
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

    void PaddleMovement()
    {
        // Paddle Movement
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, verticalInput, 0) * _speed * Time.deltaTime);

        // Boarders
        if (transform.position.y >= 5.75)
        {
            transform.position = new Vector3(transform.position.x, - 5.75f, 0);
        }
        else if (transform.position.y <= -5.75)
        {
            transform.position = new Vector3(transform.position.x, 5.75f, 0);
        }

    }
}
