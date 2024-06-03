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
    
    void Start()
    {
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector2 = this.transform.position;

        for (var i = 0;i < turns; i++)
        {
            int _allturns = 360 / turns;
            var g = Instantiate(_shoot, this.transform.position, Quaternion.Euler(0, 0, _turn+(i*_allturns)));
        }
        _turn += 5f;

        //Vector2.x += 0*Time.deltaTime;
        this.transform.position = Vector2;
    }
}