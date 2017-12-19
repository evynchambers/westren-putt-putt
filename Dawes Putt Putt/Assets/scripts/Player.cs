using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody rigid;
    private float power;
    public GameObject[] cubes;
    public Material[] cubeColours;
    private int number;

	// Use this for initialization
	void Start () {

        power = 0;
        number = 0;
        //InvokeRepeating("PowerBar", 1, 1);
		
	}

    private void PowerBar()
    {
        cubes[number].GetComponent<MeshRenderer>().material = cubeColours[0];
        number++;

        if(number > cubes.Length)
        {
            number = 6;
        }
    }

    private void ResetCubes()
    {
        for(int i = 0; i < cubes.Length; i++)
        {
            cubes[i].GetComponent<MeshRenderer>().material = cubeColours[1];
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

       //power += .01f;

       if (Input.GetButton("Right"))
        {
            switch (number)
            {
                case 0:
                    power = 20;
                    break;

                case 1:
                    power = 40;
                    break;

                case 2:
                    power = 60;
                    break;

                case 3:
                    power = 80;
                    break;

                case 4:
                    power = 100;
                    break;

                case 5:
                    power = 120;
                    break;

                case 6:
                    power = 140;
                    break;
            }

            CancelInvoke("PowerBar");
            transform.Rotate(new Vector3(0, 10, 0) * 5 * Time.deltaTime);
            number = 0;
            ResetCubes();
            rigid.AddForce(Vector3.forward * power);
        }
           
       
           
        }
		
	

        
    }

