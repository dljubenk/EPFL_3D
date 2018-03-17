using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public GUIText[] scoreTexts;


	int [] scores;


	void Start(){
		scores = new int [scoreTexts.Length];
		for (int i=0; i<scores.Length; i++) {
			scores[i] = 0;
		}
		UpdateTexts ();
	}

	void UpdateTexts(){
		for (int i=0; i<scoreTexts.Length; i++) {
			if (scoreTexts[i] != null)
				scoreTexts[i].text = "P" + (i+1).ToString() + " goals taken: " + scores[i].ToString();
		}
	}

	public void UpdateScore (GUIText textRef){
		for (int i=0; i<scoreTexts.Length; i++) {
			if (textRef == scoreTexts[i])
				scores[i]++;
		}
		UpdateTexts ();
	}
}
