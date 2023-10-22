using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platformPrefabs;
    [SerializeField]
    private GameObject[] obsPrefabs;
    [SerializeField]
    private GameObject[] ceilingPrefabs;
    [SerializeField]
    public int zOffset;
    public GameObject intialPlatform;
    ArrayList objs;
    // Start is called before the first frame update
    void Start()
    {
        objs = new ArrayList();
        GameObject temp = Instantiate(intialPlatform);
        zOffset += 10;
        objs.Add(temp);
    }

    public void CreatePlatform(GameObject platform) {
        Destroy(platform, 7f);
        int temp = Random.Range(0, platformPrefabs.Length);
        GameObject plane = Instantiate(platformPrefabs[temp], new Vector3(0, 0, zOffset), Quaternion.Euler(0, 0, 0));
        int r = Random.Range(0, ceilingPrefabs.Length);
        if (temp == 4)
        {
            GameObject obs = Instantiate(ceilingPrefabs[r], plane.transform);
            obs.transform.Translate(new Vector3(Random.Range(0f, 5f) - 2.5f, 0, 0), Space.World);
        }
        else {
            Instantiate(ceilingPrefabs[r], plane.transform);
        }
        if (Random.Range(0, 5) != 1)
        {
            GameObject obs = Instantiate(obsPrefabs[Random.Range(0, obsPrefabs.Length)], plane.transform);
            if (temp == 0)
                obs.transform.Translate(new Vector3(2.5f, 0, 0), Space.World);
            else if (temp == 1)
                obs.transform.Translate(new Vector3(-2.5f, 0, 0), Space.World);
        }
            
        plane.AddComponent<Platform>();
        plane.AddComponent<MeshRenderer>();
        objs.Add(plane);
        //if (Random.Range(0, 10) == 1)
        //    zOffset += 10;
        zOffset += 10;
    }

    public void restart() {
        foreach (GameObject e in objs) {
            // e.GetComponent<Platform>().respawnDestroy();
            Destroy(e);
        }
        objs = new ArrayList();
        GameObject temp = Instantiate(intialPlatform);
        zOffset += 10;
        objs.Add(temp);
    }

}
