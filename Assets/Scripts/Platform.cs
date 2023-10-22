using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformManager platformManager;

    private void OnEnable()
    {
        platformManager = GameObject.FindObjectOfType<PlatformManager>();
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Creates");
        platformManager.CreatePlatform(this.gameObject);
    }

    public void respawnDestroy() { 
        Destroy(this.gameObject);
    }
}
