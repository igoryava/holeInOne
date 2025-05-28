using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private float _defaultGravity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _defaultGravity = _rigidbody.gravityScale;
    }

    public void Block()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void UnBlock()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.None;
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void StopMove()
    {
        _rigidbody.gravityScale = _defaultGravity;
        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        _disposable.Clear();
    }

    public void MoveRight()
    {
        SetMoveDirection(new Vector2(1, 0), _speed, false);
    }

    public void MoveLeft()
    {
        SetMoveDirection(new Vector2(-1, 0), _speed, false);
    }

    public void SetMoveDirection(Vector2 direction, float speed, bool useGravity = true)
    {
        _disposable.Clear();
        if (useGravity)
            _rigidbody.gravityScale = _defaultGravity;
        else
            _rigidbody.gravityScale = 0;
        Observable.EveryUpdate().Subscribe(_ => { _rigidbody.velocity = direction * speed; }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }
}