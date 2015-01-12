using UnityEngine;
using System.Collections;

public class CrossRoadArrow : MonoBehaviour {

	private GameObject _myParentCharacter;
	private GameObject _myParentField;

	void Update() {
		if(Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray,out hit) && hit.collider.transform.GetInstanceID() == transform.GetInstanceID()) {
				_myParentCharacter.GetComponent<PlayerRoute>().GoInThisDirection(_myParentField.transform.position);
			}
		}
	}

	public GameObject SetMyParentCharacterReference {
		set {
			_myParentCharacter = value;
		}
	}

	public GameObject SetMyParentFieldReference {
		set {
			_myParentField = value;
		}
	}
}
