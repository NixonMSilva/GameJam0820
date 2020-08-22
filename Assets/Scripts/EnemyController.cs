using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   [SerializeField]

    private float speed = 5;

    [SerializeField]

    private Transform movePoint;

    [SerializeField]

    private LayerMask obstacleMask;



    void Start() {

        movePoint.parent = null; // Detach partent

    }



    void Update() {

        float movementAmout = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementAmout);


/*
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f) {
            
            if(Input.GetButtonDown("Up")){
                Move(new Vector3(0, 1, 0));
            }
            else if(Input.GetButtonDown("Down")){
                Move(new Vector3(0, -1, 0));
            }
            else if(Input.GetButtonDown("Left")){
                Move(new Vector3(-1, 0, 0));
            }
            else if(Input.GetButtonDown("Right")){
                Move(new Vector3(1, 0, 0));
            }
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {

                Move(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));

            }

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {

                Move(new Vector3(0, Input.GetAxisRaw("Vertical"), 0));

            }
            Debug.Log(Input.GetAxisRaw("Horizontal"));

        }*/

    }



    public void Move(Vector3 direction) {

        Vector3 newPosition = movePoint.position + direction;

        if (!Physics2D.OverlapCircle(newPosition, 0.2f, obstacleMask)) {

            movePoint.position = newPosition;

        }

    }
}
