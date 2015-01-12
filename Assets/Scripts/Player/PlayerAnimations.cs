using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour {

	Animator animationControler;
	
	void Start ()
	{
		animationControler = GetComponent<Animator>();
		animationControler.SetInteger("RandomIdle", GetComponent<PlayerCharacter>().PlayerNumber);
	}
	
	public void StartMoveAnimation() {
		animationControler.SetBool("PickRoadIdle", false);
		animationControler.SetBool("Run", true);
	}
	
	public void StopMoveAnimation() {
		animationControler.SetBool("Run", false);
	}
	
	public void StartPickingRoadIdle() {
		animationControler.SetBool("PickRoadIdle", true);
	}
	
	public void StopPickingRoadIdle() {
		animationControler.SetBool("PickRoadIdle", false);
	}
}
