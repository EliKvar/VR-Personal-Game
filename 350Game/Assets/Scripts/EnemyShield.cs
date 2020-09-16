using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : EnemyBase
{


    private Rigidbody rb;
    public GameObject den;
    public GameObject meteor;
    private int count;
    public static EnemyShield Instance;


    WaveSpawner ws;

    void Start()
    {
        Instance = this;
        den = GameObject.Find("TargetEnemy");
        maxSpeed = 1.55f;
        rb = gameObject.GetComponent<Rigidbody>();

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Meteor")
        {
           // ws.enemies.Remove(ws.ShieldEnemy);
            Debug.Log("Destroy");
            GameManager.Instance.AddKill();
            GameManager.Instance.SaveGame();

            UIManager.Instance.UpdateLives();

            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Den")
        {
            Destroy(gameObject);
            GameManager.Instance.OnEnemyEscape();
            GameManager.Instance.SaveGame();  
            UIManager.Instance.UpdateLives();
       
        }
       
    }
 
    // Update is called once per frame
    void FixedUpdate()
    {
       // Debug.Log("Enemy hits: " + counter);

        // vel *= maxSpeed;
        //transform.position = Vector3.Lerp(gameObject.transform.position, den.transform.position, Time.deltaTime);
        rb.AddForce(gameObject.transform.forward * maxSpeed);
        
        gameObject.transform.LookAt(den.transform);
       // rb.AddForce(player.transform.position * maxSpeed); //I THINK THE PLAYER POSITION THE FORCE IS POINTING TOWARDS IS GETTING *MAXSPEED 
        //rb.AddForce((target.transform.position - angle.transform.position) * speed);

       // Debug.Log(player.transform.position);
       

        //if (vel.magnitude > maxSpeed)
        //  {
        //     rb.velocity = vel.normalized * maxSpeed;
        // }
    }
}
