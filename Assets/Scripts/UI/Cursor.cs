using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

    private Vector3 _mousePosition;
    private Vector3 _worldPosition;

    void Start()
    {
        Screen.showCursor = false; //hides system cursor
    }

    void Update()
    {
        _mousePosition = Input.mousePosition;
        _worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(_mousePosition.x, _mousePosition.y, _mousePosition.z));
        transform.position = new Vector3(_worldPosition.x, _worldPosition.y, 0);
    }
}
