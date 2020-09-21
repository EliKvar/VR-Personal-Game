using Boo.Lang;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    Transform[] Buildings;
    List Fences = new List();

    // Start is called before the first frame update
    void Start()
    {
        Buildings = this.GetComponentsInChildren<Transform>();
        foreach(Transform i in Buildings)
        {
            if (i.name.Contains("fencepart"))
            {
                Fences.Add(i.gameObject);
                //Debug.Log(Fences);
               
            }
                

        }
    }

    public void HitBuilding(GameObject building, int damage)
    {
       // GameObject direct = buil
       

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
