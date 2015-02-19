using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InsertCodePanelControler : MonoBehaviour {
    public Transform _cardsPanel;
    public Transform _codeField;

    public void CloseInsertCardPanel()
    {
        StartCoroutine(HideInsertCodeCorutine());
        StartCoroutine(ShowCardsPanelCorutine());
    }

    public void CheckCode() {
        print(_codeField.GetComponent<Text>().text);
    }

    IEnumerator HideInsertCodeCorutine()
    {
        float insertCodePanelAplha = GetComponent<CanvasGroup>().alpha;

        while (insertCodePanelAplha > 0.1f)
        {
            insertCodePanelAplha -= 0.16f;
            GetComponent<CanvasGroup>().alpha = insertCodePanelAplha;
            yield return null;
        }

        gameObject.SetActive(false);
    }

    IEnumerator ShowCardsPanelCorutine()
    {
        float cardsPanelAplha = _cardsPanel.GetComponent<CanvasGroup>().alpha;

        while (cardsPanelAplha < 0.99f)
        {
            cardsPanelAplha += 0.16f;
            _cardsPanel.GetComponent<CanvasGroup>().alpha = cardsPanelAplha;
            yield return null;
        }
    }
}
