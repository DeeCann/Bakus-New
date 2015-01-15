using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cardPanelControler : MonoBehaviour {
	public Transform _vigniete;

	public void ClosePanel() {
		StartCoroutine (HideVigniete ());
		StartCoroutine (HideCardsPanelCorutine ());
	}

	IEnumerator HideVigniete() {
		Color vignieteColor = _vigniete.GetComponent<Image> ().color;
		while (vignieteColor.a > 0.1f) {
			vignieteColor.a -= 0.2f;
			_vigniete.GetComponent<Image>().color = vignieteColor;
			yield return null;
		}
	
		vignieteColor.a = 0;
		_vigniete.GetComponent<Image> ().color = vignieteColor;
		_vigniete.gameObject.SetActive (false);
		gameObject.SetActive (false);
	}

	IEnumerator HideCardsPanelCorutine() {
		float cardsPanelAplha = gameObject.GetComponent<CanvasGroup> ().alpha;
		
		while (cardsPanelAplha > 0.1f) {
			cardsPanelAplha -= 1.6f;
			gameObject.GetComponent<CanvasGroup>().alpha = cardsPanelAplha;
			yield return null;
		}
	}
}
