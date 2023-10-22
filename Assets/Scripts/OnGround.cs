using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Threading.Tasks;

public class OnGround : MonoBehaviour
{
    private gravity g;
    private Boolean firstTime;

    public void Awake()
    {
        if (g == null)
            Debug.Log("is null");
        g = GameObject.FindObjectOfType<gravity>();
        firstTime = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        // Debug.Log("exitA");
        //if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Ceiling")
        //{
        Debug.Log("exit");
        g.grounded = false;
        if (g.down)
            g.rb.AddForce(0.9f * Vector3.up, ForceMode.Impulse);
        else
            g.rb.AddForce(0.9f * Vector3.down, ForceMode.Impulse);
        //}
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("enterA");
        //if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Ceiling")
        //{
        if (g == null)
            Debug.Log("null");
        else
            Debug.Log("This shit stupid af");
        //noGo();
        Debug.Log("enter");
        g.grounded = true;
        //if (firstTime)
        //    g.gameObject.transform.position = new Vector3();
        //}
    }

    private async void noGo() {
        await Task.Delay(10000);
 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
