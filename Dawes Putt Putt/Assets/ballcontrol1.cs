using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballcontrol1 : MonoBehaviour {

    //public Transform clubObj;
    public float zforce = 100;
    public Transform arrowObj;
    private bool isShot;
    public Rigidbody golfBall;
    public GameObject ball;
    private int shotsTaken;
    public int[] pars;
    private int parTotal;
    private int currentHole;
    public int[] score;

    void addPar()
    {
        for (int i = 0; i < pars.Length; i++)
        {
            parTotal += pars[i];
        }
    }

    //score[currentHole] = pars[currentHole] - shotsTaken;

	// Use this for initialization
	void Start () {

        isShot = false;
        shotsTaken = 0;
        parTotal = 0;
        currentHole = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

        if(golfBall.velocity == Vector3.zero)
        {
            if(isShot == true)
            {
                isShot = false;
                ball.transform.position = transform.position;
                this.transform.parent = ball.transform;
                arrowObj.transform.parent = ball.transform;
                golfBall.transform.rotation = ball.transform.rotation;
                arrowObj.transform.position = transform.position;

            }
        }

        if (Input.GetButtonDown("up") && isShot == false)
        {
            shotsTaken++;
            Debug.Log(shotsTaken);
            isShot = true;
            ball.transform.DetachChildren();
            //golfBall.AddRelativeForce(0, 0, zforce);
            golfBall.AddForce(transform.forward * zforce);

        }

        //fix
        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //Instantiate(clubObj, transform.position, clubObj.rotation);
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
            arrowObj.GetComponent<Transform>().position = transform.position;
        }

        if (Input.GetKey("a"))
        {
            ball.transform.Rotate(0, -1, 0);
           
        }
        if (Input.GetKey("d"))
        {
            ball.transform.Rotate(0, 1, 0);
        }

        if (Input.GetButton("one"))
        {
            zforce += 5;
        }

        if (Input.GetButton("two"))
        {
            zforce -= 5;
        }

        if (zforce < 20)
        {
            zforce = 20;
        }

        if (zforce > 2000)
        {
            zforce = 2000;
        }




    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "cup")
        {
            //score[currentHole] = pars[currentHole] - shotsTaken;
            Debug.Log("Completed");
            //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            ;        }
    }
}
