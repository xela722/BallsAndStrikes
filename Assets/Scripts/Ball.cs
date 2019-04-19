using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 1.0f;
    public BoxCollider2D StrikeZone;
    public bool waitingCall = false;

    public int variationFactor;

    public Vector3 pitchStartPos;
    public Vector3 pitchPosition;

	// Use this for initialization
	void Start () {

        pitchStartPos = transform.position;
        pitchPosition = pitchStartPos;
	}
	
    public void newPitch()
    {
        waitingCall = true;
        transform.position = pitchStartPos;
        pitchPosition = randomPitchLocation();

    }

    Vector3 randomPitchLocation()
    {
        return new Vector3(
            Random.Range(StrikeZone.bounds.min.x-(variationFactor*this.GetComponent<SpriteRenderer>().bounds.size.x), StrikeZone.bounds.max.x+(variationFactor*this.GetComponent<SpriteRenderer>().bounds.size.x)),
            Random.Range(StrikeZone.bounds.min.y-(variationFactor*this.GetComponent<SpriteRenderer>().bounds.size.y), StrikeZone.bounds.max.y-(variationFactor*this.GetComponent<SpriteRenderer>().bounds.size.y))
            );
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space)&&!waitingCall)
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
            Debug.Log(string.Format("{0} - {1}", pitchPosition.x, StrikeZone.bounds.min.x));
            Debug.Log(string.Format("{0} - {1}", pitchPosition.y, StrikeZone.bounds.min.y));
            return true;
        }
        return false;
    }
}
