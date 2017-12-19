using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballcontrol1 : MonoBehaviour {

    //public Transform clubObj;
    public float zforce = 100;
    public Transform arrowObj;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("up"))
        {
            GetComponent<Rigidbody>().AddRelativeForce(0, 0, zforce);
        }

        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //Instantiate(clubObj, transform.position, clubObj.rotation);
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
            arrowObj.GetComponent<Transform>().position = transform.position;
        }

        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 1, 0);
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
            Debug.Log("Completed");
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            ;        }
    }
}
