using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 1.0f;
    public BoxCollider2D StrikeZone;

    public Vector3 pitchStartPos;
    public Vector3 pitchPosition;

	// Use this for initialization
	void Start () {

        pitchStartPos = transform.position;
        pitchPosition = pitchStartPos;
        newPitch();
	}
	
    public void newPitch()
    {
        transform.position = pitchStartPos;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = pitchStartPos;
            newPitch();
            Debug.Log(isStrike().ToString());
        }

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, pitchPosition, step);	
	}

    public bool isStrike()
    {
        if(pitchPosition.x >= StrikeZone.bounds.min.x && pitchPosition.x <= StrikeZone.bounds.max.x && pitchPosition.y >= StrikeZone.bounds.min.y && pitchPosition.y <= StrikeZone.bounds.max.y)
        {
            return true;
        }
        return false;
    }
}
