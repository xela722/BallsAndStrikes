using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PostGame : MonoBehaviour {

    public GameObject correctCallsGO,totalCallsGO,accuracyGO;

	// Use this for initialization
	void Start () {
        TextMeshProUGUI correctCallsTM = correctCallsGO.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI totalCallsTM = totalCallsGO.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI accuracyTM = accuracyGO.GetComponent<TextMeshProUGUI>();

        int totalCalls = PlayerPrefs.GetInt("totalCalls");
        int correctCalls= PlayerPrefs.GetInt("correctCalls");
        double accuracy = (double)correctCalls/ (double)totalCalls*100;

        Debug.Log(accuracy.ToString());

        correctCallsTM.text = string.Format("{0}", correctCalls);
        totalCallsTM.text = string.Format("{0}", totalCalls);
        accuracyTM.text = string.Format("{0}%", System.Math.Round(accuracy,0));
	}
	

    public void quitGame()
    {
        Application.Quit();
    }
    public void nextGame()
    {
        SceneManager.LoadScene(1);
    }
}
