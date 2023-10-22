using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public PlatformManager primeMinister;
    bool first;

    // Start is called before the first frame update
    void Start()
    {
        first = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -3 || transform.position.y > 8 || !first) {
            GetComponent<gravity>().returnHome();
            Physics.gravity = new Vector3(0, -9.8F, 0);
            primeMinister.zOffset = 0;
            primeMinister.GetComponent<PlatformManager>().restart();
            first = true;
        }
    }
}
