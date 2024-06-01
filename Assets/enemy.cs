using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _shoot;
    [SerializeField] float _turn=0;
    Vector2 Vector2 = Vector2.zero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 = this.transform.position;
        var g = Instantiate(_shoot,this.transform.position,Quaternion.Euler(0, 0, _turn));
        _turn += 1.5f;
        Vector2.x += 1*Time.deltaTime;
        this.transform.position = Vector2;
    }
}
