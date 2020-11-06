using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrSeguecamera : MonoBehaviour {

    public Image preto;
    public Animator fade;
    public float xMax;
	public float xMin;
    public float yMax;
    public float yMin;

	private Transform target;

	void Start () {
		target = GameObject.Find ("Player").transform;
	}
	
	void LateUpdate () {
		transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
	}
}
