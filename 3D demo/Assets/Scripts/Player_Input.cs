using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    public float verticalAxis;
    public float horizontalAxis;
    public bool targetSwitch;
    public bool isjumping;
    
    Player_Stat playerstat;
    Player_Movement playermovement;

    [SerializeField]
    float doubleTapDelay = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        targetSwitch = false;
        playerstat = GetComponent<Player_Stat>();
        playermovement = GetComponent<Player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        AxisUpdate();
        TargetSwitchUpdate();
        JumpUpdate();
    }

    void AxisUpdate() {
        verticalAxis = Input.GetAxis("Vertical");
        horizontalAxis = Input.GetAxis("Horizontal");
    }

    void TargetSwitchUpdate() {
        if (Input.GetButtonDown("Switch"))
        {
            playerstat.TargetSwitch();
        }
    }

    bool jumpdoubletap = false;

    void JumpUpdate() {
        
        if (Input.GetButtonDown("Jump") && jumpdoubletap)
        {
            //BD
            playermovement.BoostDash();
            Debug.Log("BD");
        }
        if (Input.GetButton("Jump") && !jumpdoubletap)
        {
            isjumping = true;
            jumpdoubletap = true;
            //Jump
            StartCoroutine(DoubleTapCountDown());
        }

        if (Input.GetButtonUp("Jump")) {
            isjumping = false;
        }

    }

    IEnumerator DoubleTapCountDown() {
        
        yield return new WaitForSeconds(doubleTapDelay);
        jumpdoubletap = false;
    }
}
