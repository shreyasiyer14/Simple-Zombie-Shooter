using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public float speed = 1f;
    public float healthPacket = 100f;
	void Start () {
		
	}
	
	void Update () {

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) {
                hit.collider.gameObject.SendMessageUpwards("Hit", SendMessageOptions.DontRequireReceiver);
            }
        }
	}

    public void DoDamage() {
        healthPacket -= 10f;
    }
}
