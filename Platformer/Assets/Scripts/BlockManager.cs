using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    GameObject anchors;
    GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        anchors = transform.Find("Anchors").gameObject;
        block = transform.Find("Block").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
