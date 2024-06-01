using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _shoot;
    [SerializeField] float _turn1=0;
    [SerializeField] float _turn2=180;
    Vector2 Vector2 = Vector2.zero;
    void Start()
    {
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 = this.transform.position;

        var g1 = Instantiate(_shoot,this.transform.position,Quaternion.Euler(0, 0, _turn1));
        _turn1 += 5f;
        var g2 = Instantiate(_shoot, this.transform.position, Quaternion.Euler(0, 0, _turn2));
        _turn2 += 5f;

        Vector2.x += 2*Time.deltaTime;
        this.transform.position = Vector2;
    }
}
