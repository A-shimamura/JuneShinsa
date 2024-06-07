using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Pool;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _shoot;
    [SerializeField] float _turn=0;
    [SerializeField] int turns = 2;
    Vector2 Vector2 = Vector2.zero;
    ObjectPool<GameObject> pool;
    private int _layer;
    
    void Start()
    {
        Application.targetFrameRate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector2 = this.transform.position;

        for (var i = 0; i < turns; i++)
        {
            int _allturns = 360 / turns;
            var g = Instantiate(_shoot, this.transform.position, Quaternion.Euler(0, 0, _turn+(i*_allturns)));
            g.GetComponent<SpriteRenderer>().sortingOrder = _layer;
        }
        _turn += 10f;
        _layer++;

        if (_turn == 3600) _turn = 0;
        if (_layer == 10000)_layer = 0;
        //Vector2.x += 0*Time.deltaTime;
        this.transform.position = Vector2;
    }
}