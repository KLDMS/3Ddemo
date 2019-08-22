using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public GameObject player;
    public GameObject target;

    Player_Stat playerstat;


    [SerializeField]
    float movementSmoothSpeed;
    [SerializeField]
    float rotationSmoothSpeed;



    // Start is called before the first frame update
    void Start()
    {
        playerstat = player.GetComponent<Player_Stat>();   
    }

    // Update is called once per frame
    void Update()
    {
        target = playerstat.GetTarget();

        Vector3 targetPosition = player.transform.position;
        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, movementSmoothSpeed);

        var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,rotationSmoothSpeed);
    }
}
