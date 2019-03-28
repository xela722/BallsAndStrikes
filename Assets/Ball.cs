using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 1.0f;
    public BoxCollider2D StrikeZone;

    Vector3 pitchPosition;

	// Use this for initialization
	void Start () {
        pitchPosition = randomPitchLocation();
	}
	
    Vector3 randomPitchLocation()
    {
        return new Vector3(
            Random.Range(StrikeZone.bounds.min.x, StrikeZone.bounds.max.x),
            Random.Range(StrikeZone.bounds.min.y, StrikeZone.bounds.max.y)
            );
    }

	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, pitchPosition, step);	
	}
}
