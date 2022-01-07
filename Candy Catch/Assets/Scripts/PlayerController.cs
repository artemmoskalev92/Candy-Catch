using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] float speed;
    [SerializeField] float boundX;

    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }
    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        transform.position += Vector3.right * inputX;
        float xPos = Mathf.Clamp(transform.position.x, -boundX, boundX);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        
    }
}
