using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using Cinemachine;
using System;
using Random = System.Random;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _shoot;
    [SerializeField] float _turn = 0;
    [SerializeField] int turns = 11;
    [SerializeField] public int _hp=1000;
    [SerializeField] int _damage = 8;
    [SerializeField] GameObject area;
    [SerializeField] GameObject _player;
    [SerializeField] ObjectPool _OP = default;
    [SerializeField] Transform _playerpos;
    [SerializeField] Transform[] _P2move = null;
    Vector2 Vector2 = Vector2.zero;
    private int _layer;
    private float _speed = 0.3f;
    bool _muteki = false;
    private ObjectPool _objectPool = default;
    float _shottime;
    float _subtime;
    int _P2shotcount;
    new Vector2 vector2 = Vector2.zero;
    [SerializeField] float _P1shotcool = 0.1f;
    [SerializeField] float _P2shotcool = 0.5f;
    [SerializeField] float _P2shotcools = 0.3f;
    [SerializeField] float _P3shotcool = 0.1f;
    [SerializeField] float _dis = 0.1f;
    [SerializeField] int i = 0;
    [SerializeField] GameObject imp;
    CinemachineImpulseSource impulseSource;
    public bool _CF = false;
    Player f;

    [SerializeField] public int _nowphase=0;
    
    void Start()
    {
        //ビルド時にコメント解除して
        //_nowphase = 1;
        _objectPool = new();
        area.GetComponent<DeleteA>().Initialize(_objectPool);
        impulseSource = imp.GetComponent<CinemachineImpulseSource>();
        f = _player.GetComponent<Player>();
    }
    public void Initialize(ObjectPool objectPool)
    {
        _OP = objectPool;
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp <= 0)
        {
            _hp = 1;
            _muteki = true;
            
            impulseSource.GenerateImpulse();
        }
        _shottime += Time.deltaTime;
        _subtime += Time.deltaTime;

    }
    private void FixedUpdate()
    {
        if (!f._gameoverflag)
        {
            Vector2 = this.transform.position;
            if (_muteki && _hp <= 9996)
            {
                _hp += 5;
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 3), _speed * 2 * Time.deltaTime);
                if (_nowphase == 3) { Initiate.Fade("crear", Color.black, 4f); }
            }
            if (_hp >= 1000 && _muteki)
            {
                _hp--;
                _muteki = false;
                _nowphase++;
                transform.position = new Vector2(0, 3);
                vector2 = _playerpos.position;
            }
            if (!_muteki)
            {
                #region Phase1
                if (_nowphase == 1)
                {
                    if (_P1shotcool <= _shottime)
                    {
                        _shottime = 0;
                        for (var i = 0; i < turns; i++)
                        {
                            int _allturns = 360 / turns;
                            var g = _objectPool.SpawnObject(_shoot);
                            g.transform.position = this.transform.position;
                            g.transform.rotation = Quaternion.Euler(0, 0, _turn + (i * _allturns));
                            g.transform.localScale = new Vector3(0, 0, 0);
                            //var g = Instantiate(_shoot, this.transform.position, Quaternion.Euler(0, 0, _turn + (i * _allturns)));
                            //g.GetComponent<SpriteRenderer>().sortingOrder = _layer;
                            var e = g.GetComponent<shotmanage>();
                            e.Init(1, transform.position);
                        }
                        _turn += 10f;
                        _layer++;

                        if (_turn == 3600) _turn = 0;
                        if (_layer == 10000) _layer = 0;
                    }
                    if (!_muteki) { Vector2.x += _speed * Time.deltaTime; }
                    if (Vector2.x >= 0.5f)
                    {
                        _speed *= -1;
                    }
                    else if (Vector2.x <= -0.5f)
                    {
                        _speed *= -1;
                    }
                    this.transform.position = Vector2;
                }
                #endregion
                #region Phase2
                if (_nowphase == 2)
                {
                    if (!_muteki)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, _P2move[i].position, _speed * 2 * Time.deltaTime);
                        if (_dis >= Vector2.Distance(transform.position, _P2move[i].position))
                        {
                            i++;
                        }
                        if (i >= _P2move.Length) { i = 0; }
                    }
                    if (_P2shotcool <= _shottime)
                    {
                        var g = _objectPool.SpawnObject(_shoot);
                        g.transform.position = this.transform.position;
                        g.transform.rotation = Quaternion.Euler(0, 0, GetAngle(this.transform.position, vector2));
                        var e = g.GetComponent<shotmanage>();
                        e.Init(2, transform.position);

                        var g1 = _objectPool.SpawnObject(_shoot);
                        g1.transform.position = this.transform.position;
                        g1.transform.rotation = Quaternion.Euler(0, 0, GetAngle(this.transform.position, vector2) - 7f);
                        var e1 = g1.GetComponent<shotmanage>();
                        e1.Init(2, transform.position);

                        var g2 = _objectPool.SpawnObject(_shoot);
                        g2.transform.position = this.transform.position;
                        g2.transform.rotation = Quaternion.Euler(0, 0, GetAngle(this.transform.position, vector2) + 7f);
                        var e2 = g2.GetComponent<shotmanage>();
                        e2.Init(2, transform.position);

                        _P2shotcount++;
                        if (_P2shotcount < 3)
                        {
                            _shottime = _P2shotcool - 0.05f;
                        }
                        else if (_P2shotcount == 3)
                        {
                            _shottime = 0;
                            _P2shotcount = 0;
                            vector2 = _playerpos.position;
                        }
                    }
                }
                #endregion
                #region Phase2
                if (_nowphase == 3)
                {
                    if (!_muteki)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, _P2move[i].position, _speed * 5 * Time.deltaTime);
                        if (_dis >= Vector2.Distance(transform.position, _P2move[i].position))
                        {
                            i++;
                        }
                        if (i >= _P2move.Length) { i = 0; }
                    }
                    if (_P3shotcool <= _shottime)
                    {
                        var s = GetAngle(this.transform.position, (vector2));
                        var g = _objectPool.SpawnObject(_shoot);
                        g.transform.position = this.transform.position;
                        g.transform.rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(s - 40f, s + 40f));
                        var e = g.GetComponent<shotmanage>();
                        e.Init(2, transform.position);

                        var g1 = _objectPool.SpawnObject(_shoot);
                        g1.transform.position = this.transform.position;
                        g1.transform.rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(s - 40f, s + 40f));
                        var e1 = g1.GetComponent<shotmanage>();
                        e1.Init(2, transform.position);

                        var g2 = _objectPool.SpawnObject(_shoot);
                        g2.transform.position = this.transform.position;
                        g2.transform.rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(s - 40f, s + 40f));
                        var e2 = g2.GetComponent<shotmanage>();
                        e2.Init(2, transform.position);

                        var g3 = _objectPool.SpawnObject(_shoot);
                        g3.transform.position = this.transform.position;
                        g3.transform.rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(s - 40f, s + 40f));
                        var e3 = g3.GetComponent<shotmanage>();
                        e3.Init(2, transform.position);

                        _shottime = 0;
                    }
                }
                #endregion
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "pshoot"&&!_muteki)
        {
            this._hp-=_damage;
            _OP.RemoveObject(collision.gameObject);
        }
    }
    public float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 dt = target - start;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }
}