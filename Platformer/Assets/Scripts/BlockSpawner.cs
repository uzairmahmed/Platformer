using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject target;
    public GameObject blockPrefab;

    public float timer;
    public float waitTime;

    public float offsetX, offsetY, offsetZ;

    public float targetOffsetX, targetOffsetY, targetOffsetZ;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.position = target.transform.position + new Vector3(offsetX, offsetY, offsetZ);

        if (timer >= waitTime)
        {
            Vector3 spawnTarget = target.transform.position + new Vector3(targetOffsetX, targetOffsetY, targetOffsetZ);
            GameObject blk = Instantiate(blockPrefab, transform.position, Quaternion.identity);

            blk.transform.Find("Anchors").gameObject.transform.position = spawnTarget;
        }
    }
}
