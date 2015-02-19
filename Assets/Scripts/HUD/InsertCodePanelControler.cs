using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InsertCodePanelControler : MonoBehaviour {
    public Transform _cardsPanel;
    public Transform _codeField;
    public Transform _messageText;

    public void CloseInsertCardPanel()
    {
        StartCoroutine(HideInsertCodeCorutine());
        StartCoroutine(ShowCardsPanelCorutine());
    }

    public void CheckCode() {
        _messageText.GetComponent<Text>().text = "Kod niepoprawny.\nSpróbuj ponownie później";
    }

    IEnumerator HideInsertCodeCorutine()
    {
        _codeField.parent.GetComponent<InputField>().text = "";
        float insertCodePanelAplha = GetComponent<CanvasGroup>().alpha;

        while (insertCodePanelAplha > 0.1f)
        {
            insertCodePanelAplha -= 0.16f;
            GetComponent<CanvasGroup>().alpha = insertCodePanelAplha;
            yield return null;
        }
       
        _messageText.GetComponent<Text>().text = "";
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
