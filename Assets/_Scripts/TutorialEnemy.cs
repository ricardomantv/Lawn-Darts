using UnityEngine;
using System.Collections;

public class TutorialEnemy : MonoBehaviour {

	Vector3 origPos;
    private Transform player;


	void Start () {
        origPos = transform.position; //where the enemy spawns, not ready yet
        tag = "Enemy";
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	void FixedUpdate () {
		//always rotates to face player
		Vector3 direction = player.position - this.transform.position;
		direction.y = 0; // prevents model from rotating up/down while turning towards player
		this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);

	}
}
