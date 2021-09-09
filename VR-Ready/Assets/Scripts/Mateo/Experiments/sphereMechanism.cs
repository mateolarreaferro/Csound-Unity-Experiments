
//Steps:
// 1. Create sphere #1 based on player's location (using Instantiate)
// 2. Make it expand until it collides with other player
// 3. Once the collision is detected:
// 3.1 destroy sphere #1 
// 3.2 make a new sphere (#2) based on the position of that collision 
// 3.3 make it expand until it collides with the other player 
// 3.4 destroy sphere #2




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereMechanism : MonoBehaviour
{

	//Variables

	public GameObject sphere1; //Sphere #1 Object
	public Vector3 expansion; //Sphere #1 expansion
	public Transform startingPoint1; //Starting Point for Sphere #1
	public AudioSource expansionSound; //Sound it makes while expanding
	private float startAudio; 
	public float xyz;
	private bool action;

	void Start(){

		expansion = gameObject.GetComponent<Vector3>();
		expansionSound = gameObject.GetComponent<AudioSource>();
		startAudio = 0f;
		action = false;

	}

	void Update() {

		  if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(sphere1, startingPoint1.position, startingPoint1.rotation);
            sphere1.transform.localScale += expansion;
            expansion = new Vector3(xyz, xyz -0.1f, xyz);



            startAudio += 0.1f;
            if (startAudio > 0.2f && startAudio < 0.4f){
            	expansionSound.Play();
            }
        }

	}

	public void FinishStart (bool estate){

		action = estate;

		if (action == true){

			Destroy(sphere1);

		}


	}















}







