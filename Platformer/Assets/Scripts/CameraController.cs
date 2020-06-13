using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    Vector3 _offset;

    void Start()
    {
        _offset = new Vector3(0, 5, -5); // or whatever you need
    }

    void FixedUpdate()
    {
        transform.position = Player.transform.position + _offset;
        transform.LookAt(Player.transform);

    }
}
