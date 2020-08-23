using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
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

    private EnemyController enemy;
    private Vector3 direction;

    private bool isStuck;

    void Start() 
    {

        movePoint.parent = null; // Detach partent
        isStuck = false;
    }

    void Awake()
    {
        enemy = transform.parent.GetComponentInChildren<EnemyController>();
    }


    void Update() 
    {

        float movementAmout = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementAmout);



        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f) 
        {
            

            if(Input.GetButtonDown("Up")){
                direction = new Vector3(0, 1, 0);
                Move(direction);
                enemy.Move(direction);
            }
            else if(Input.GetButtonDown("Down")){
                direction = new Vector3(0, -1, 0);
                Move(direction);
                enemy.Move(direction);
            }
            else if(Input.GetButtonDown("Left")){
                direction = new Vector3(-1, 0, 0);
                Move(direction);
                enemy.Move(direction);
            }
            else if(Input.GetButtonDown("Right")){
                direction = new Vector3(1, 0, 0);
                Move(direction);
                enemy.Move(direction);
            }
           /* if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {

                Move(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));

            }

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {

                Move(new Vector3(0, Input.GetAxisRaw("Vertical"), 0));

            }
            Debug.Log(Input.GetAxisRaw("Horizontal"));*/

        }

    }

    private void Move(Vector3 direction) {

        Vector3 newPosition = movePoint.position + direction;

        // If there's no obstacle, move to a new position
        if (!Physics2D.OverlapCircle(newPosition, 0.01f, obstacleMask)) {

            // If the player isn't stuck, then move, after moving, check if the player hasn't stepped into mud
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

        // Check if the player has reached a victory point
        if (CheckVictory(movePoint.position))
        {
            //Debug.Log("Player reached victory point!");
            WinRound();
        }
    }

    private bool CheckVictory (Vector3 position)
    {
        Vector3 offset = new Vector3(0f, -0.5f, 0f);
        if (Physics2D.OverlapCircle(position + offset, 0.01f, victoryMask))
            return true;
        return false;
    }

    private bool CheckMud (Vector3 position)
    {
        Vector3 offset = new Vector3(0f, -0.5f, 0f);
        if (Physics2D.OverlapCircle(position + offset, 0.1f, mudMask))
        {
            Debug.Log("Player is in mud!");
            return true;
        }
        return false;
    }

    private void WinRound ()
    {
        GameEvent.current.PlayerVictory();
    }
}
