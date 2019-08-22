using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stat : MonoBehaviour
{
    GameObject[] targets;
    int currtargetindex = 0;

    
    [SerializeField]
    GameObject Camera;

    public Player playerstage;


    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");
        playerstage = Player.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TargetSwitch() {

        currtargetindex = (currtargetindex + 1) % targets.Length;

    }

    public GameObject GetTarget() {
        return targets[currtargetindex];
    }

    public GameObject GetCamera() {
        return Camera;
    }
}

public enum Player {
    Normal,
    BoostDash

}