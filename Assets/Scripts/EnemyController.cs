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

    [SerializeField]

    private LayerMask victoryMask;

    [SerializeField]

    private LayerMask mudMask;

    private bool isStuck;

    void Start() {

        movePoint.parent = null; // Detach partent
        isStuck = false;
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

        if (!Physics2D.OverlapCircle(newPosition, 0.01f, obstacleMask)) 
        {
            // If the enemy isn't stuck, then move, after moving, check if the enemy hasn't stepped into mud
            if (!isStuck)
            {
                movePoint.position = newPosition;
                isStuck = CheckMud(movePoint.position);
            }
            else
            {
                isStuck = false;
            }
        }

        // Check if the enemy has reached a victory point
        if (CheckVictory(movePoint.position))
        {
            Debug.Log("Enemey reached victory point!");
            LoseRound();
        }
    }

    private bool CheckVictory (Vector3 position)
    {
        Vector3 offset = new Vector3(0f, -0.5f, 0f);
        //Debug.Log("Position [ENEMY]:" + position + offset);
        if (Physics2D.OverlapCircle(position + offset, 0.01f, victoryMask))
            return true;
        return false;
    }

    private bool CheckMud (Vector3 position)
    {
        Vector3 offset = new Vector3(0f, -0.5f, 0f);
        if (Physics2D.OverlapCircle(position + offset, 0.1f, mudMask))
        {
            return true;
        }
        return false;
    }

    private void LoseRound ()
    {

    }
}
