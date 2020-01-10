using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    //public Camera mainCamera;

    public GameObject blockPrefab;
    public GameObject startPlatformPrefab;
    public GameObject endPlatformPrefab;

    public int blockSize = 1;
    public int platformSize = 5;

    public int level = 1;

    public bool generating_level;


    // Start is called before the first frame update
    void Start()
    {
        generating_level = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (generating_level)
        {
            GenerateLevel(level);
        }
    }

    public void GenerateLevel(int lvl)
    {
        int blockGap = lvl - 1;
        int platformGap = (((lvl-1)*5) + 2) + platformSize;

        int rows = (2 * lvl) - 1;
        int mapCenter = (int)((rows / 2) + 1);
        for (int i = mapCenter * (-1); i <= mapCenter; i++)
        {
            int columns = rows - ((System.Math.Abs(i) * 2) + 1);
            int rowCenter = (int)((columns / 2));
            for (int j = rowCenter * (-1); j <= rowCenter; j++)
            {
                float platX = i + (i * platformGap);
                float platZ = j + (j * platformGap);

                int zoneCenter = (int)((platformSize / 2) + 1);
                for (int k = zoneCenter * (-1); k <= zoneCenter; k++)
                {
                    int platColumns = platformSize - ((System.Math.Abs(k) * 2) + 1);
                    int platformCenter = (int)((platColumns / 2));
                    for (int l = platformCenter * (-1); l <= platformCenter; l++)
                    {
                        float blockX = platX + k + (k * blockGap);
                        float blockZ = platZ + l + (l * blockGap);

                        Instantiate(blockPrefab, new Vector3(blockX, 0, blockZ), Quaternion.identity);
                    }
                }                
            }
        }
        generating_level = false;
    }

}
