using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CustomController : MonoBehaviour
{
    public float speed = 5f;
    Vector3 playerPos = new Vector3(); 
    Vector3 playerDirection = new Vector3();
    Quaternion playerRotation = new Quaternion();
    float spawnDistance = 10;
    RaycastHit hitInfo;
    //public GameObject playerCon;

    Camera myCamera;
   public GameObject meteor;
    public GameObject angle;
    public GameObject target;
   // public GameObject players;



    Vector3 spawnPos = new Vector3();
    public bool isSlowed;

    
    public static float standardSpeed = 3.0f;
    public static float fastSpeed = 15.0f;
    public static float rotationSpeed = 60.0f;
    public static float orientation = 0.0f;
    public static float positionalSpeed = 7.5f;

    // float camSpeed = standardSpeed;
    public static float camSpeed = 0.0f;
    bool isAdded;

    public GameObject CenterEyeAnchor;

    Rigidbody rb;
    private int fireDelay;
    private bool isHeld;

    void Start()
    {
        myCamera = GetComponentInChildren<Camera>();
        isSlowed = false;
        isAdded = true;
        OVRManager.display.RecenterPose();
        rb = GetComponent<Rigidbody>();



    }
    void Update()
    {
        //====================================================================ADJUST values for desired movement.

        Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector2 secondaryAxis = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        float primaryIndex = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        float secondaryIndex = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);

        //if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick) || OVRInput.Get(OVRInput.Button.DpadUp) || OVRInput.Get(OVRInput.Button.DpadDown) || OVRInput.Get(OVRInput.Button.DpadLeft) || OVRInput.Get(OVRInput.Button.DpadRight))
        //{
        //    camSpeed = fastSpeed;
        //}
        //else
        //{
        //    camSpeed = standardSpeed;
        //}

        // Dpad Movement
        //if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        //{
        //    Debug.Log(OVRInput.Button.PrimaryThumbstickUp);

        //    rb.velocity = CenterEyeAnchor.transform.forward * camSpeed;  //CENTEREYEANCHOR could also be target
        //}
        //else if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickUp) && (primaryAxis.y == 0.0f && secondaryAxis.x == 0.0f))
        //{
        //    //currentSpeed = Mathf.Lerp(, , Time.deltaTime);

        //    rb.velocity = CenterEyeAnchor.transform.forward * 0.0f;
        //    //Debug.Log(OVRInput.Button.PrimaryThumbstickUp);

        //}


        //if (OVRInput.Get(OVRInput.Button.DpadDown) || Input.GetKeyDown(KeyCode.S))
        //{
        //    rb.velocity = CenterEyeAnchor.transform.forward * camSpeed * -1;
        //}
        //else if (OVRInput.GetUp(OVRInput.Button.DpadDown) && (primaryAxis.y == 0.0f && secondaryAxis.x == 0.0f))
        //{
        //    rb.velocity = CenterEyeAnchor.transform.forward * 0.0f;
        //}


        //if (OVRInput.Get(OVRInput.Button.DpadRight))
        //{
        //    rb.velocity = CenterEyeAnchor.transform.right * camSpeed;
        //}
        //else if (OVRInput.GetUp(OVRInput.Button.DpadRight) && (primaryAxis.y == 0.0f && secondaryAxis.x == 0.0f))
        //{
        //    rb.velocity = CenterEyeAnchor.transform.right * 0.0f;
        //}


        //if (OVRInput.Get(OVRInput.Button.DpadLeft))
        //{
        //    rb.velocity = CenterEyeAnchor.transform.right * camSpeed * -1;
        //}
        //else if (OVRInput.GetUp(OVRInput.Button.DpadLeft) && (primaryAxis.y == 0.0f && secondaryAxis.x == 0.0f))
        //{
        //    rb.velocity = CenterEyeAnchor.transform.right * 0.0f;
        //}

        // primaryAxis.x != 0.0f ||
        // Left Analog Stick Movement (Camera Face Movement)
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp) && isAdded == true)
        {
            isAdded = false;
            camSpeed += 5.2f;
            Invoke("SetTrue", .2f); //May not need this if the camslowdown number is balanced well with the camspeedup


            // rb.velocity = CenterEyeAnchor.transform.forward * camSpeed * primaryAxis.y;// + CenterEyeAnchor.transform.right * camSpeed * primaryAxis.x;
        }
      //  if (primaryAxis.y != 0.0f)
      //  {
       //     isAdded = false;
       //     camSpeed *= 1.5f;
       //     Invoke("SetTrue", .2f);


            // rb.velocity = CenterEyeAnchor.transform.forward * camSpeed * primaryAxis.y;// + CenterEyeAnchor.transform.right * camSpeed * primaryAxis.x;
       // }
        else if (primaryAxis.x == 0.0f && primaryAxis.y == 0.0f) //&& (OVRInput.Get(OVRInput.Button.DpadUp) == false && OVRInput.Get(OVRInput.Button.DpadDown) == false && OVRInput.Get(OVRInput.Button.DpadRight) == false && OVRInput.Get(OVRInput.Button.DpadLeft) == false) && rb.velocity.magnitude > 0)
        {
           // rb.velocity = CenterEyeAnchor.transform.forward * Mathf.Lerp(camSpeed, 0, Time.deltaTime);
            rb.velocity = rb.velocity * camSpeed * Time.deltaTime;
            //camSpeed *= 0.99f;

        }
        if (OVRInput.Get(OVRInput.Button.Three) && isAdded == true)
        {
           
        }
        // camSpeed= Mathf.Lerp(camSpeed, 0, Time.deltaTime);
        rb.velocity = CenterEyeAnchor.transform.forward * camSpeed;// * primaryAxis.y;
        camSpeed *= 0.99f;
       // Debug.Log(speed);

        // Right Analog Stick Player Rotation (This can cause player disorientation)
        if (secondaryAxis.x != 0.0f)
        {
            orientation = orientation + rotationSpeed * secondaryAxis.x * Time.deltaTime;
            rb.rotation = Quaternion.Euler(0, orientation, 0);
        }

        // Triggers Vertical Movement (Game World Vertical Movement)
        //if (primaryIndex != 0.0f || secondaryIndex != 0.0f)
        //{
        //    rb.velocity = transform.up * positionalSpeed * (secondaryIndex - primaryIndex);
        //}

        // playerPos = transform.position;
        // playerDirection = transform.forward;
        // playerRotation = transform.rotation;
        //spawnPos = playerPos + playerDirection * spawnDistance;
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && fireDelay > 10)
        {
            fireDelay = 0;

            isHeld = true;
            Vector3 camScreen = new Vector3(0.5f, 0.5f, 0f); // center of the screen
            float rayLength = Mathf.Infinity;
            Ray ray = myCamera.ViewportPointToRay(camScreen);
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

            Physics.Raycast(ray, out hitInfo);


            GameObject met = Instantiate(meteor) as GameObject;
            met.transform.position = transform.position + angle.transform.forward * .01f;
            Rigidbody rbMet = met.GetComponent<Rigidbody>();
            met.transform.LookAt(target.transform);
            rbMet.velocity = rb.velocity;

            rbMet.AddForce((target.transform.position - angle.transform.position) * speed);
            Destroy(met, 9f);
        }
        else
        {
            isHeld = false;
        }
      
     //   Debug.Log(fireDelay);
        fireDelay++;


    }
    void SetTrue()
    {
        isAdded = true;
    }
     void FixedUpdate()
    {

     
        
        Vector3 camScreens = new Vector3(0.5f, 0.5f, 0f); // center of the screen
        float rayLengths = 100f;
        Ray rays = myCamera.ViewportPointToRay(camScreens);
        Debug.DrawRay(rays.origin, rays.direction * rayLengths, Color.red);

        float step = speed * Time.deltaTime; // calculate distance to move
      
    }
   
}
