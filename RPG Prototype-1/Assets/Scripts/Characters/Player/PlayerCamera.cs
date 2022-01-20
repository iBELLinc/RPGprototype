using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    private string PLAYER_TAG = "Player";
    private Transform player;
    private Vector3 wantedPosition;
    public float distance = 5.0f, height = 0.75f, damping = 12.0f;
    public bool smoothRotation = true, followBehind = true;
    public float rotationDamping = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void Update()
    {
//*** Would like camera to look more above player so that player is lower-center of screen
        if(followBehind)
            wantedPosition = player.TransformPoint(0, height, -distance);
        else
            wantedPosition = player.TransformPoint(0, height, distance);
        
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

        if(smoothRotation){
            Quaternion wantedRotation = Quaternion.LookRotation(player.position - transform.position, player.up);
            //Quaternion ownRotation = Quaternion.RotateTowards;
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
        }
        else
            transform.LookAt(player, player.up);
    }
}