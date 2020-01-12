using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpinner : MonoBehaviour
{
    public float speed;
    public GameObject center;
    // Start is called before the first frame update
    void Start()
    {
        center = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, 50 * Time.deltaTime, 0); //rotates 50 degrees per second around z axis

        transform.RotateAround(center.transform.position, transform.up, Time.deltaTime * 200f);
    }
}
