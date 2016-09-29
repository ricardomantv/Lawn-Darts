using UnityEngine;
using System.Collections;

public class Mom_Script : MonoBehaviour {

	public float walkSpeed;

	private Animator animator;
	private Transform player;

	private bool dead = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		dead = animator.GetBool ("isDead");
		if (!dead) {
			Act ();
		} else {
			//Body disappears after 2 seconds
			StartCoroutine (Disappear (5));
		}
	}

	void Act() {
		Vector3 direction = player.position - this.transform.position;
		direction.y = 0; // prevents model from rotating up/down while turning towards player
		this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);

		if (direction.magnitude < 2) {
			//Enemy is close enough to attack
			animator.SetBool ("isDead", false);
			animator.SetBool ("isWalking", false);
			animator.SetBool ("isAttacking", true);
		} else {
			//Enemy walks towards player to attack
			this.transform.Translate (new Vector3 (0, 0, walkSpeed));
			animator.SetBool ("isDead", false);
			animator.SetBool ("isWalking", true);
			animator.SetBool ("isAttacking", false);
		}
	}

	IEnumerator Disappear(float delay) {
		yield return new WaitForSeconds (delay);
		Destroy (this.gameObject);
	}
}
