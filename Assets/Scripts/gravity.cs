using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;
public class gravity : MonoBehaviour
{
    public bool down;
    public bool grounded;
    float lastInverted;
    public Rigidbody rb;
    float gravityValue = -9.8f;
    public GameObject canvas;
    public Text cooldownCount;
    float lastDisplayed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //down = true;
        grounded = true;
        lastInverted = 3f;
        lastDisplayed = 1f;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("enterA");
        //if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Ceiling")
        //{
            grounded = true;
            Debug.Log("enter");
        //}
    }

    private void OnCollisionExit(Collision collision)
    {
       // Debug.Log("exitA");
        //if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Ceiling")
        //{
            grounded = false;
            Debug.Log("exit");
        //}
    }*/
    

    // Update is called once per frame
    void Update()
    {
        down = Physics.gravity.Equals(new Vector3(0, gravityValue, 0));
        lastInverted += Time.deltaTime;
        lastDisplayed += Time.deltaTime;
        //Debug.Log("alive");
        if (Input.GetKeyDown(KeyCode.E) && lastInverted >= 3f)
        {
            lastInverted = 0;
            if (down)
            {
                Physics.gravity = new Vector3(0, -gravityValue, 0);
                //down = false;
            }
            else
            {
                Physics.gravity = new Vector3(0, gravityValue, 0);
                //down = true;
            }
            Debug.Log("Gravity");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            canvas.SetActive(true);
            lastDisplayed = 0f;
            cooldownCount.text = 3f - lastInverted + " seconds";
        }
        else { 
            if(canvas.active && lastDisplayed > 0.5f)
                canvas.SetActive(false);
        }
        rb.AddForce(1 * Time.deltaTime * Vector3.forward, ForceMode.Impulse);
        if(rb.velocity.z < 0)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
        //transform.Translate(new Vector3(0, 0, 5) * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(10 * Time.deltaTime * Vector3.left, ForceMode.Impulse);
            //transform.Translate(5 * Vector3.left * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(10 *Time.deltaTime * Vector3.right, ForceMode.Impulse);
        //transform.Translate(5 * Vector3.right * Time.deltaTime, Space.World);
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            if (down)
                rb.AddForce(7f * Vector3.up, ForceMode.Impulse);
            else
                rb.AddForce(7f * Vector3.down, ForceMode.Impulse);
            Debug.Log("Jump");
        }
    }
    public void returnHome() {
        transform.position = new Vector3(0, 1, 0);
         rb.velocity = new Vector3(0f, 0f, 0f);
         rb.angularVelocity = new Vector3(0f, 0f, 0f);
         transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
    }
}
