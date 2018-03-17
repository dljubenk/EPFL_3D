using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {

	public ScoreController scoreCont;


	void OnTriggerExit(Collider other){
		if (other.tag == "Ball")
			scoreCont.UpdateScore (this.gameObject.GetComponent<GUIText>());
	}
}
