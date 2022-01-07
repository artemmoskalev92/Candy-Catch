using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.IncrementScore();
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Boundary")
        {
            GameManager.Instance.DecreaseLife();
            Destroy(gameObject);
        }
    }
}
