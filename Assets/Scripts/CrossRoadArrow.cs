using UnityEngine;
using System.Collections;

public class CrossRoadArrow : MonoBehaviour {

	private GameObject _myParentCharacter;
	private GameObject _myParentField;

	private bool _listenForClickAction = false;

	void Update() {
		if(_listenForClickAction && Input.GetMouseButtonDown(0)) {
			print ("halo");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray,out hit) && hit.collider.transform.GetInstanceID() == transform.GetInstanceID()) {
				_myParentCharacter.GetComponent<PlayerRoute>().GoInThisDirection(_myParentField.transform.position);
			}
			_listenForClickAction = false;
		}
	}


	public GameObject SetMyParentCharacterReference {
		set {
			_myParentCharacter = value;
			_listenForClickAction = true;
		}
	}

	public GameObject SetMyParentFieldReference {
		set {
			_myParentField = value;
		}
	}
}
