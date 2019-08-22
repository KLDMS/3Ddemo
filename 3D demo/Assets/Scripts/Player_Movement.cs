using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    CharacterController charactercontroller;

    [SerializeField]
    float planespeed = 5;
    [SerializeField]
    float upspeed = 5;
    [SerializeField]
    float gravity = 5;


    [SerializeField]
    Vector3 movedir;
    [SerializeField]
    float turntime = 0.1f;
    [SerializeField]
    float BDlast = 0.1f;

    Player_Stat playerstat;
    Player_Input playerin;
    

    // Start is called before the first frame update
    void Start()
    {
        charactercontroller = GetComponent<CharacterController>();
        playerstat = GetComponent<Player_Stat>();
        playerin = GetComponent<Player_Input>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerstat.playerstage) {
            case Player.Normal:
                Move();
                break;
            case Player.BoostDash: 


        }
        
        
    }


    void GetDir()
    {

        Vector3 CamF = new Vector3(playerstat.GetCamera().transform.forward.x,0, playerstat.GetCamera().transform.forward.z);
        Vector3 CamR = new Vector3(playerstat.GetCamera().transform.right.x, 0, playerstat.GetCamera().transform.right.z);


        movedir.x = playerin.horizontalAxis;
        movedir.z = playerin.verticalAxis;

        movedir = (CamR * Input.GetAxis("Horizontal") + CamF * Input.GetAxis("Vertical")) * planespeed;

    }


    void Move()
    {
        
        GetDir();
        Jump();

        charactercontroller.Move(movedir * Time.deltaTime);

        Vector3 lookdir = new Vector3(movedir.x,0,movedir.z);

        if (lookdir != Vector3.zero) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookdir), turntime);
        }
        
    }


    void Jump() {
        if (playerin.isjumping)
        {
            movedir.y += planespeed;
        }

        else {
            if (charactercontroller.isGrounded)
            {
                movedir.y = 0;
            }
            else movedir.y -= gravity;
        }
       

        

    }

    public void BoostDash() {
        planespeed = 10;
        StartCoroutine(BoostDashLast());
    }

    IEnumerator BoostDashLast() {
        yield return new WaitForSeconds(BDlast);
        planespeed = 5;
    }
}
