using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchMenuScript : MonoBehaviour
{
    public GameObject _menuCanvas;
    private Vector3 _posDiff;
    private Vector3 _rotDiff;
    private Vector3 _refPos = new Vector3(0, 1, 0);
    private Vector3 _refRot = new Vector3(-11, 81, -118);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _posDiff = transform.position - _refPos;
        _rotDiff = transform.eulerAngles - _refRot;
        Debug.Log(_posDiff.magnitude + " " + _rotDiff.magnitude);
        if (_posDiff.magnitude <= 33 && _rotDiff.magnitude <= 400)
        {
            _menuCanvas.SetActive(true);
        } else
        {
            _menuCanvas.SetActive(false);
        }
    }
}
