using UnityEngine;
using System.Collections;

public class Dart_Script : MonoBehaviour {
	private Rigidbody rb;
	private Coroutine disappear;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		disappear = StartCoroutine (Disappear (3));
	}
	
	// Update is called once per frame
	void Update () {
		//TODO rotate with y-velocity of rigidbody
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Enemy") {
			StopCoroutine (disappear);
			Destroy (this.gameObject);

			Animator animator = col.gameObject.GetComponent<Animator> ();
			animator.SetBool ("isDead", true);
			animator.SetBool ("isWalking", false);
			animator.SetBool ("isAttacking", false);
		}
	}

	IEnumerator Disappear(float delay) {
		yield return new WaitForSeconds (delay);
		Destroy (this.gameObject);
	}
}
