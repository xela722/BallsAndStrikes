using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventTextHandler : MonoBehaviour {

    public GameObject StrikeOutEventText;
    public GameObject WalkEventText;

	public void eventStrikeOut()
    {
        StrikeOutEventText.GetComponent<Animator>().SetTrigger("Go");
        
    }
    public void eventWalk()
    {
        WalkEventText.GetComponent<Animator>().SetTrigger("Go");
        
    }

}
