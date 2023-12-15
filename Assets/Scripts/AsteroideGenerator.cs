using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class AsteroideGenerator : MonoBehaviour
{
    public float _distApparition;
    public float _propVisee;
    public Transform _myTf;
    public Transform _tfSpawner;
    public GameObject _asteroid;
    public GameObject _currAsteroid;
    public Rigidbody _rbcurrAsteroid;
    public Vector3 _pointVisee;
    public float _timer;
    public float _densite;
    public float _nbMaxAsteroide;
    public int _nbAsteroide;
    public int _nbAsteroideG;
    public float _maxVitesse;
    public float _vitesse;
    public Vector3 torque;


    void GenerateOneAsteroid(int size)
    {
        _tfSpawner.position = Random.onUnitSphere * _distApparition + _myTf.position;
        _pointVisee = Random.insideUnitSphere * _distApparition * _propVisee + _myTf.position; 
        _tfSpawner.rotation = Quaternion.LookRotation(_pointVisee - _tfSpawner.position); //regarde vers _pointVisee
        _currAsteroid = Instantiate(_asteroid,_tfSpawner);
        _rbcurrAsteroid = _currAsteroid.GetComponent<Rigidbody>();
        _currAsteroid.GetComponent<Transform>().parent = _myTf;
        _vitesse = (Random.value / 2.0f + 0.2f) * _maxVitesse;
        _rbcurrAsteroid.AddForce(Vector3.Normalize(_pointVisee - _tfSpawner.position)*_vitesse);
        torque = new Vector3(Random.Range(0, 2.0f), Random.Range(0, 2.0f), Random.Range(0, 2.0f));
        _rbcurrAsteroid.AddTorque(torque);
        _currAsteroid.GetComponent<Asteroide>()._vitesse = _vitesse;
        switch (size)
        {
            case 0:
                _currAsteroid.GetComponent<Asteroide>()._baseScale = Random.Range(1.0f, 5);
                break;
            case 1: 
                _currAsteroid.GetComponent<Asteroide>()._baseScale = Random.Range(15.0f, 20);
                break;
        }
    }

    public void Destructed(int size)
    {
        if (size == 1) _nbAsteroideG--;
        _nbAsteroide--;
    }

    // Start is called before the first frame update
    void Start()
    {
        _densite = 0.00001f;
        _myTf = GetComponent<Transform>();
        _distApparition = 100.0f;
        _propVisee = 0.8f;
        _timer = 0;
        _nbAsteroide = 0;
        _nbAsteroideG = 0;
        _nbMaxAsteroide =  4.0f * math.PI / 3.0f * _distApparition * _distApparition * _distApparition * _densite;
        _maxVitesse = 100.0f; //*100 pour vitesse accelere
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 0.1)
        {
            _timer = 0;
            if (_nbAsteroide < _nbMaxAsteroide) {
                if (_nbAsteroideG > _nbMaxAsteroide / 10)
                {
                    GenerateOneAsteroid(0);
                }
                else
                {
                    if (Random.Range(0, (int) _nbMaxAsteroide) > 0)
                    {
                        GenerateOneAsteroid(0);
                    }
                    else
                    {
                        GenerateOneAsteroid(1);
                        _nbAsteroideG++;
                    }
                }
                _nbAsteroide++;
            }
        }
    }
}
