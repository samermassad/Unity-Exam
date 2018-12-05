using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	private LineRenderer line;
	private GameObject lightGameObject;
	private CapsuleCollider healthCollider;
	private Light light;

	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer>();
		light = gameObject.GetComponent<Light>();
		healthCollider = gameObject.GetComponent<CapsuleCollider>();
		
		lightGameObject = new GameObject("Hit Light");
		lightGameObject.transform.parent = transform;
		Light lightComp = lightGameObject.AddComponent<Light>();
        lightComp.color = light.color;
		lightComp.intensity = light.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		
		line.SetPosition(0, ray.origin);
		
		if(Physics.Raycast(ray, out hit, 100)) {
			line.SetPosition(1, hit.point);
			Vector3 lightPoint = hit.point;
			lightPoint.x -= 0.5F;
			lightGameObject.transform.position = lightPoint;
			
			//set the collider
			float length = Vector3.Distance(ray.origin, hit.point) * 1.2f;
			healthCollider.height = length*8;
			healthCollider.center = new Vector3(0, 0, length*4);
		} else {
			line.SetPosition(1, ray.GetPoint(100));
		}
		
	}
}
