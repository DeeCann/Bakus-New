using UnityEngine;
using System.Collections;

public class CrossRoadArrow : MonoBehaviour {

	private GameObject _myParentCharacter;
	private GameObject _myParentField;

	private static bool _listenForClickAction = false;

	void Update() {
        if (_listenForClickAction)
            if (GameInputs.isButtonDown)
                HitRay();
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

    public bool CanListen {
        set {
            _listenForClickAction = value;
        }
    }


    private void HitRay() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.transform.GetInstanceID() == transform.GetInstanceID())
            _myParentCharacter.GetComponent<PlayerRoute>().GoInThisDirection(_myParentField.transform.position);
    }
}
