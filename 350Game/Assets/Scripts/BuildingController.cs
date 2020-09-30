using Boo.Lang;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class BuildingController : MonoBehaviour
{
    Transform[] Buildings;
    //List Fences = new List();
    public Dictionary<string, int> Fences = new Dictionary<string, int>();
    public int fenceHealth;
    string determinedBuilding;
    public int pairValue;
    public int health;
    

    void Start()
    {
        fenceHealth = 5000;
        Buildings = this.GetComponentsInChildren<Transform>();
        foreach(Transform i in Buildings)
        {
            if (i.name.Contains("fencepart"))
            {
                Fences.Add(i.name, fenceHealth);
                //Fences.Add(i.gameObject);
               
            }
                

        }
        foreach(KeyValuePair<string, int> pair in Fences)
        {
            //Debug.Log(pair.Key +" " + pair.Value);
        }
    }
     void Update()
    {
        

    }




    public void SetPair()
    {
        Debug.Log("SetPAir");
      
        foreach (KeyValuePair<string, int> pair in Fences)
        {
            Debug.Log(pair.Key + " " + pair.Value);

            if (pair.Key == determinedBuilding)
            {
                pairValue = pair.Value;
                Debug.Log(pair.Key + " " + pairValue);
                // break;

            }
        }
    }
    //Get incoming building GameObject and dmg int. Determine what type. Find equivalent GO in list. modify its value. if the value == 0, destroy GO.
    /*
    public void HitBuilding(GameObject building, int dmg)
    {
       // Debug.Log(Fences[building.name]);
        determinedBuilding = building.name;
        if (determinedBuilding.Contains("fencepart"))
        {
            if (Fences.TryGetValue(determinedBuilding.ToString(), out int value))
            {
                Debug.Log(value);
            }
            else
            {
               // Debug.Log("NO GOOD");
            }
            //Debug.Log(Fences["fencepart (4)"]);
            //Fences[determinedBuilding] -= dmg;


                //fenceHealth -= dmg;
                //Debug.Log(fenceHealth);

                //if (fenceHealth == 0)
                //{

                //    Destroy(determinedBuilding);
                //}

        }
        
       

    }*/
  
    
}
