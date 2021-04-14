using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerManager : MonoBehaviour
{
    public GameObject player;
    public static VRPlayerManager Instance;

    float xPos = 171.678f;
    float yPos = 223.909f;
    float zPos = 981.186f;
    float yRot = 181.276f;
    float xScale = 2.4608f;
    float yScale = 2.4608f;
    float zScale = 2.4608f;

    private void Start()
    {
        Instance = this;
    }
    public void SetInPlane()
    {
        player.transform.position = new Vector3(xPos,yPos,zPos);
        player.transform.rotation = new Quaternion(0f, yRot, 0f,0f);
        player.transform.localScale = new Vector3(xScale, yScale, zScale);
        player.GetComponent<OVRPlayerController>().enabled = false;
        player.GetComponent<CustomController>().enabled = true;
    }
    public void SetInStart()
    {

    }
}
