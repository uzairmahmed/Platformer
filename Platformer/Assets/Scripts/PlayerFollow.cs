using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    public GameObject player;

    private Vector3 _offset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _offset = new Vector3(0, 5f, -10f);    //just put the values that you want instead of y and z
    }

    void FixedUpdate()
    {
        Vector3 flatSpeed = player.GetComponent<Rigidbody>().velocity;
        flatSpeed.y = 0;
        //stores the flat velocity of your player so it can put the camera always behind it

        Quaternion wantedRotation;

        if (flatSpeed != Vector3.zero)
        {
            float targetAngle = Quaternion.LookRotation(flatSpeed).eulerAngles.y;
            wantedRotation = Quaternion.Euler(0, targetAngle, 0);
        }
        else wantedRotation = Quaternion.Euler(0, 0, 0);

        transform.position = player.transform.position + (wantedRotation * _offset);
        transform.LookAt(player.transform);
    }
}
