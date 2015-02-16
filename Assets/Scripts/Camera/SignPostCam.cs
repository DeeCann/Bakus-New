using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SignPostCam : MonoBehaviour {
    public Transform arrow;
    private List<Vector3> _endPaths = new List<Vector3>();
    private Vector3 _arrowDelta;

    void Start() {
        foreach (GameObject field in GameObject.FindGameObjectsWithTag("EndPathField")) {
            _endPaths.Add(new Vector3(field.transform.position.x, transform.position.y, field.transform.position.z));
        }
        _arrowDelta = arrow.transform.position - transform.position;
        print(_endPaths[0]);
    }

    void Update() {
        arrow.transform.position = new Vector3(Game.GetCurrentPlayer.transform.position.x, transform.position.y, Game.GetCurrentPlayer.transform.position.z);
        //_arrowDelta = arrow.transform.position - transform.position;
        transform.position = Vector3.Lerp(transform.position, transform.position - _arrowDelta, Time.deltaTime );
        //transform.FindChild("Arrow").transform.localRotation = Quaternion.LookRotation(_endPaths[0] - transform.FindChild("Arrow").transform.position);
    }
}
