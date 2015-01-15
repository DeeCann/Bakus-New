using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	public Transform _vigniete;
	public Transform _pauseButtonSprite;
	public Transform _playButtonSprite;
	public Transform _cardsPanel;
	public Transform _tipsPanel;

	private bool _gameIsPaused = false;	

    public void Exit()
    {
		Application.LoadLevel (0);
		return;
    }

	public void TimeControl() {
		if (!_gameIsPaused) {
			Time.timeScale = 0;
			_pauseButtonSprite.gameObject.SetActive(true);
			_playButtonSprite.gameObject.SetActive(false);
			_gameIsPaused = true;

			return;
		}

		if (_gameIsPaused) {
			Time.timeScale = 1;
			_pauseButtonSprite.gameObject.SetActive(false);
			_playButtonSprite.gameObject.SetActive(true);
			_gameIsPaused = false;

			return;
		}
	}

	public void ShowTip() {
		_vigniete.gameObject.SetActive (true);
		_tipsPanel.gameObject.SetActive (true);
		StartCoroutine (ShowVigniete ());
		StartCoroutine (ShowTipsPanelCorutine ());
	}

	public void CloseTip() {
		StartCoroutine (HideVigniete ());
		StartCoroutine (HideTipsPanelCorutine ());
	}

	public void ShowCardsPanel() {
		_vigniete.gameObject.SetActive (true);
		_cardsPanel.gameObject.SetActive (true);
		StartCoroutine (ShowCardsPanelCorutine ());
		StartCoroutine (ShowVigniete ());
	}

	IEnumerator ShowVigniete() {
		Color vignieteColor = _vigniete.GetComponent<Image> ().color;
		while (vignieteColor.a < 0.6f) {
			vignieteColor.a += 0.16f;
			_vigniete.GetComponent<Image>().color = vignieteColor;
			yield return null;
		}
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
	}

	IEnumerator ShowCardsPanelCorutine() {
		float cardsPanelAplha = _cardsPanel.GetComponent<CanvasGroup> ().alpha;

		while (cardsPanelAplha < 0.99f) {
			cardsPanelAplha += 0.16f;
			_cardsPanel.GetComponent<CanvasGroup> ().alpha = cardsPanelAplha;
			yield return null;
		}
	}

	IEnumerator ShowTipsPanelCorutine() {
		float _tipsPanelAlpha = _tipsPanel.GetComponent<CanvasGroup> ().alpha;
		
		while (_tipsPanelAlpha < 0.99f) {
			_tipsPanelAlpha += 0.16f;
			_tipsPanel.GetComponent<CanvasGroup> ().alpha = _tipsPanelAlpha;
			yield return null;
		}

		foreach(Transform fruit in _tipsPanel.FindChild("FruitsAmountTexts").transform)
			fruit.GetComponent<Text>().text = Game._fruitsInGame[fruit.name].ToString();
		
	}

	IEnumerator HideTipsPanelCorutine() {
		float _tipsPanelAlpha = _tipsPanel.GetComponent<CanvasGroup> ().alpha;
		
		while (_tipsPanelAlpha < 0.99f) {
			_tipsPanelAlpha += 0.16f;
			_tipsPanel.GetComponent<CanvasGroup> ().alpha = _tipsPanelAlpha;
			yield return null;
		}

		_tipsPanel.gameObject.SetActive (false);
	}

}
