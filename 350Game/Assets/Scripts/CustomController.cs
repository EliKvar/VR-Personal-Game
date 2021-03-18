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
    public GameObject gatlingPosition;
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

    public OVRGrabbable lHandle;
    public OVRGrabbable rHandle;
    public GameObject gatlingGun;
    GatlingGun gg;
    public SoftJointLimitSpring oldSpringTwist;
    public SoftJointLimitSpring oldSpringSwing;
    public SoftJointLimitSpring newSpringTwist;
    public SoftJointLimitSpring newSpringSwing;
    private bool haptic = false;




    void Start()
    {
        myCamera = GetComponentInChildren<Camera>();
        //isSlowed = true;
        isAdded = true;
        OVRManager.display.RecenterPose();
        rb = GetComponent<Rigidbody>();

        oldSpringTwist.spring = gatlingGun.GetComponent<CharacterJoint>().twistLimitSpring.spring;
        oldSpringSwing.spring = gatlingGun.GetComponent<CharacterJoint>().swingLimitSpring.spring;
        
        newSpringSwing = new SoftJointLimitSpring();
        newSpringSwing.spring = 0.0f;
        newSpringTwist = new SoftJointLimitSpring();
        newSpringTwist.spring = 0.0f;
        


    }
    void Update()
    {
        //====================================================================ADJUST values for desired movement.
        Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector2 secondaryAxis = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        float primaryIndex = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        float secondaryIndex = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);

        if(isSlowed == true)
        {
            Time.timeScale = 0.1f;
        }
        
        

        if (lHandle.isGrabbed == false || rHandle.isGrabbed == false)
        {
            Debug.Log("Dropped");
            gatlingGun.GetComponent<Animator>().Play("baseidlegat");

           // gatlingGun.GetComponent<CharacterJoint>().swingLimitSpring = oldSpringSwing;
           // gatlingGun.GetComponent<CharacterJoint>().twistLimitSpring = oldSpringTwist;
        }

        if (lHandle.isGrabbed && rHandle.isGrabbed && OVRInput.Get(OVRInput.Button.One) == false && OVRInput.Get(OVRInput.Button.Three) == false)
        {
            Debug.Log("Grabbed");
            gatlingGun.GetComponent<Animator>().Play("idlegat");
            // gatlingGun.GetComponent<CharacterJoint>().swingLimitSpring = newSpringSwing;
            // gatlingGun.GetComponent<CharacterJoint>().twistLimitSpring = newSpringTwist;
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);

        }

        if (lHandle.isGrabbed && rHandle.isGrabbed && OVRInput.Get(OVRInput.Button.One) == true && OVRInput.Get(OVRInput.Button.Three))
        {
             
            Debug.Log("Firing");
            gatlingGun.GetComponent<Animator>().Play("gatling2");
            GatlingGun.instance.Fire();
            //FOLLOW VIDEO FOR OVRHAPTICSCLIPS
            //OVRInput.SetControllerVibration(.3f, 0.5f, OVRInput.Controller.RTouch);
            //OVRInput.SetControllerVibration(.3f, 0.5f, OVRInput.Controller.LTouch);



            //gg.Fire();
        }
        




        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp) && isAdded == true)
        {
            isAdded = false;
            camSpeed += 5.2f;
            Invoke("SetTrue", .2f); //May not need this if the camslowdown number is balanced well with the camspeedup


            // rb.velocity = CenterEyeAnchor.transform.forward * camSpeed * primaryAxis.y;// + CenterEyeAnchor.transform.right * camSpeed * primaryAxis.x;
        }
     
        else if (primaryAxis.x == 0.0f && primaryAxis.y == 0.0f) //&& (OVRInput.Get(OVRInput.Button.DpadUp) == false && OVRInput.Get(OVRInput.Button.DpadDown) == false && OVRInput.Get(OVRInput.Button.DpadRight) == false && OVRInput.Get(OVRInput.Button.DpadLeft) == false) && rb.velocity.magnitude > 0)
        {
           // rb.velocity = CenterEyeAnchor.transform.forward * Mathf.Lerp(camSpeed, 0, Time.deltaTime);
            rb.velocity = rb.velocity * camSpeed * Time.deltaTime;
            //camSpeed *= 0.99f;

        }
       
        rb.velocity = CenterEyeAnchor.transform.forward * camSpeed;// * primaryAxis.y;
        camSpeed *= 0.99f;

        // Right Analog Stick Player Rotation (This can cause player disorientation)
        if (secondaryAxis.x != 0.0f)
        {
            orientation = orientation + rotationSpeed * secondaryAxis.x * Time.deltaTime;
            rb.rotation = Quaternion.Euler(0, orientation, 0);
        }

       
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
