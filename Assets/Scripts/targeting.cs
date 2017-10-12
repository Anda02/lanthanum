using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targeting : MonoBehaviour {

	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public GameObject p4;
	public GameObject p5;
	public GameObject p6;
	public GameObject p7;
	public GameObject p8;
	public GameObject p9;
	public GameObject p10;
	public GameObject p11;
	public GameObject p12;
	public GameObject p13;
	List<GameObject> HardpointList = new List<GameObject>();
	GameObject target;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//For selecting an object in worldspace
		if (Input.GetMouseButtonDown (1)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			print ("Does this go twice?");
			if (Physics.Raycast (ray, out hit)) {
				HardpointList.Clear ();
				target = hit.collider.gameObject;
				print ("The object is: " + target.ToString());
				//this is here so it only collects hardpoints when an new object is collected
				AddToTargetList ();
			}

			}
		if (Input.GetKeyDown (KeyCode.P)){
			print ("P worked");
			if (HardpointList == null) {
				Debug.Log ("The list is null");
			}
			foreach (GameObject obj in HardpointList){
				Debug.Log (obj);
			}

		}
	}

	void AddToTargetList(){
		//Collects all weapon hardpoints and puts them in a list
		int w = 0;
		int numchildren = target.transform.childCount;
		//Debug.Log (target.transform.childCount);
		for (int i = 0; i < numchildren; i++) {
			GameObject temp;
			temp = target.transform.GetChild (i).gameObject;
			Debug.Log (temp);
			//only adds weaponhardpoints
			if (temp.transform.tag == "weapon_hardpoint"){
				HardpointList.Add (temp);
			}
		}

	}
}
