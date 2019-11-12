using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera playerDirection;
    private Rigidbody playerMove;
    private Animator playerAnimations;
    public float speed;
    public float sensitivity;
    private float xAxisClamp = 0f;

    void Start()
    {
        playerMove = GetComponent<Rigidbody>();
    }

    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        xAxisClamp += mouseY;

        if(xAxisClamp > 90){
            xAxisClamp = 90;
            mouseY = 0;
        }
        else if(xAxisClamp < -90){
            xAxisClamp = -90;
            mouseY = 0;
        }

        transform.Rotate(0,mouseX,0);
        playerDirection.transform.Rotate(-mouseY,0,0);

        Walk();

    }

    private void Walk()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        playerMove.velocity = playerDirection.transform.right * horizontalMovement * speed;
        playerMove.velocity = playerDirection.transform.forward * verticalMovement * speed;
    }

}
