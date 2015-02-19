using UnityEngine;
using System.Collections;

public class MinigameField : MonoBehaviour
{
    private Field FieldObj;
    private bool _hasPlayerForMiniGame = false;
    private float _playerEnteredTime = 0;
    private AsyncOperation async;
    void Awake()
    {
        FieldObj = new Field();
        gameObject.GetComponent<FieldSocket>().MyFieldObject = FieldObj;
    }

    void Update() {
        if (_hasPlayerForMiniGame && _playerEnteredTime + 1 < Time.time)
        {
            async.allowSceneActivation = true;
            _hasPlayerForMiniGame = false;
        }
    }

    void OnTriggerEnter(Collider playerCollider)
    {
        if (playerCollider.tag == "Player")
        {
            if (playerCollider.gameObject.GetComponent<PlayerRoute>().NumberOfFieldsToGo == 1)
            {
                StartCoroutine("LoadGame");
                _hasPlayerForMiniGame = true;
                _playerEnteredTime = Time.time;
            }
            
        };
    }


    public Field GetFieldObject
    {
        get
        {
            return FieldObj;
        }
    }

    IEnumerator LoadGame()
    {
        async = Application.LoadLevelAsync("Trampoliny");
        async.allowSceneActivation = false;
        yield return async;
    }

}
