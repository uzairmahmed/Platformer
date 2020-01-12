using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;
    public List<GameObject> blockTypes = new List<GameObject>();

    List<Vector3> outerPlatforms = new List<Vector3>();
    int blockSize = 1;
    int platformSize = 5;

    public int level = 1;

    bool generating_level;


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

    void GenerateStartEnd(int platformSize, float blockGap, float platformGap)
    {
        List<Vector3> startPlats = new List<Vector3>();
        List<Vector3> endPlats = new List<Vector3>();

        float startPlatX, startPlatZ;
        float endPlatX, endPlatZ;

        for (int i = 0; i < outerPlatforms.Count; i++)
        {
            if (i <= (outerPlatforms.Count/2)-1) startPlats.Add(outerPlatforms[i]);
            else if (i > (outerPlatforms.Count/2)-1) endPlats.Add(outerPlatforms[i]);
        }

        int startplatZone = Random.Range(0, startPlats.Count);
        int endplatZone = Random.Range(0, endPlats.Count);
        if (startPlats[startplatZone].z < 0)
        {
            startPlatX = (startPlats[startplatZone].x);
            startPlatZ = (startPlats[startplatZone].z - platformGap);
            endPlatX = (endPlats[endplatZone].x);
            endPlatZ = (endPlats[endplatZone].z + platformGap);
        }
        else if (startPlats[startplatZone].z > 0)
        {
            startPlatX = (startPlats[startplatZone].x);
            startPlatZ = (startPlats[startplatZone].z + platformGap);
            endPlatX = (endPlats[endplatZone].x);
            endPlatZ = (endPlats[endplatZone].z - platformGap);
        }
        else
        {
            startPlatX = (startPlats[startplatZone].x - platformGap);
            startPlatZ = (startPlats[startplatZone].z);
            endPlatX = (endPlats[endplatZone].x + platformGap);
            endPlatZ = (endPlats[endplatZone].z);
        }
        GeneratePlatform(startPlatX, 0, startPlatZ, platformSize, blockGap, 0);
        GeneratePlatform(endPlatX, 0, endPlatZ, platformSize, blockGap, 1);
    }

    public void GenerateLevel(int lvl)
    {
        float blockGap = lvl - 1;
        float platformGap = ((((lvl-1)*5) + 2) + platformSize);

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

                if ((System.Math.Abs(i) == mapCenter-1) || (System.Math.Abs(j) == rowCenter))
                {
                    outerPlatforms.Add(new Vector3(platX, 0, platZ));
                }
                GeneratePlatform(platX, 0, platZ, platformSize, blockGap, 3);
            }
        }
        GenerateStartEnd(platformSize*2, 0, platformGap);
        generating_level = false;
    }

    void GeneratePlatform(float x, float y, float z, int size, float gap, int mode)
    {
        int zoneCenter = (int)((size / 2) + 1);
        for (int k = zoneCenter * (-1); k <= zoneCenter; k++)
        {
            int platColumns = size - ((System.Math.Abs(k) * 2) + 1);
            int platformCenter = (int)((platColumns / 2));
            for (int l = platformCenter * (-1); l <= platformCenter; l++)
            {
                float blockX = x + k + (k * gap);
                float blockZ = z + l + (l * gap);

                if ((mode == 0) || (mode == 1))
                {
                    if ((k == 0) && (l == 0)) MakeBlock(mode, new Vector3(blockX, y, blockZ), Quaternion.identity);
                    else MakeBlock(3, new Vector3(blockX, y, blockZ), Quaternion.identity);
                }
                else MakeBlock(3, new Vector3(blockX, y, blockZ), Quaternion.identity);
            }
        }
    }

    void MakeBlock(int mode, Vector3 pos, Quaternion rot)
    {
        if (mode == 0)
        {
            Instantiate(blockTypes[0], pos, rot);
            GameObject ball = Instantiate(player, pos + new Vector3(0, 1f, 0), rot);
            Instantiate(mainCamera, pos + new Vector3(5f, 5f, 0), rot);
        }
        else if (mode == 1) Instantiate(blockTypes[1], pos, rot);
        else
        {
            int type = Random.Range(2, 15);
            Instantiate(blockTypes[type], pos, rot);
        }
    }
}
