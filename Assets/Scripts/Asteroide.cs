using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public float _distDisparition; // same as AsteroidGenerator _distApparition
    public Rigidbody _myRb;
    public Transform _tfAsteroidGenerator;
    public Transform _myTf;
    public float _vitesse;
    AsteroideGenerator _asteroideGenerator;
    public float _baseScale;
    public float _scale1;
    public float _scale2;
    public float _scale3;

    // Start is called before the first frame update
    void Start()
    {
        _myRb = GetComponent<Rigidbody>();
        _myTf = GetComponent<Transform>();
        _tfAsteroidGenerator = _myTf.parent.GetComponent<Transform>();
        _distDisparition = 100.0f;
        _scale1 = Random.Range(0.75f, 1.5f);
        _scale2 = Random.Range(0.75f, 1.5f);
        _scale3 = Random.Range(0.75f, 1.5f);
        _asteroideGenerator = _myTf.parent.GetComponent<AsteroideGenerator>();
        Vector3 scale = new Vector3(_scale1, _scale2, _scale3);
        _myTf.localScale = Vector3.Scale(_myTf.localScale * _baseScale, scale);
        if (_baseScale > 10)
        {
            GetComponent<Renderer>().material.color = new Color32(0xFF,0xD7,0x00,0);
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_tfAsteroidGenerator.position, _myTf.position) > _distDisparition)
        {
            Destroy(gameObject);
            _asteroideGenerator.Destructed((_baseScale>10)?1:0);
        }
    }
}
