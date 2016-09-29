using UnityEngine;
using System.Collections;

public class Throw_Script : MonoBehaviour {
	public GameObject dart_prefab;
	public GameObject launch_point;

	private Transform launch;

	// Use this for initialization
	void Start () {
		launch = launch_point.transform;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			GameObject dart = (GameObject) Instantiate (dart_prefab, launch.position, launch.rotation);
			dart.GetComponent<Rigidbody> ().AddForce (launch.forward * 500f + (new Vector3(0, 500f, 0)));
		}
	}
}
