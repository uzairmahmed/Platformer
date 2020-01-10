using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    //public BlockSpawner bs;
    
    //GameObject anchors;
    //GameObject block;

    // Start is called before the first frame update
    void Start()
    {
       // bs.blockArray.Add(transform.parent.gameObject);

        //anchors = transform.Find("Anchors").gameObject;
        //block = transform.Find("Block").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destroyer")
        {
           // Debug.Log("killBlock");
            //bs.blockArray.Remove(transform.parent.gameObject);
           // Destroy(transform.parent.gameObject);
        }
    }
}
