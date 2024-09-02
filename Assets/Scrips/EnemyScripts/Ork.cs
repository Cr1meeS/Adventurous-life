
using UnityEngine;
using UnityEngine.UI;

public class Ork : Enemy
{
    [SerializeField] private Transform _player;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Slider _hpBar;
    [SerializeField] private float _health, _triggerDistance, _speed;

    private Transform _ork;
    private bool _triggered;
    private TriggerState _triggerState;
    

    

    private void Start()
    {
        Say();
        _ork = gameObject.GetComponentInChildren<Transform>();
        _triggerState = TriggerState.NotTriggered;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            MoveToPlayer();
            
        }
        Trigger();
    }

    private void Trigger()
    {
        float currentDistance = Vector3.Distance(_ork.position, _player.position);

        if (currentDistance <= _triggerDistance && _triggerState == TriggerState.NotTriggered)
        {
            _triggered = true;
            _triggerState = TriggerState.Triggered;
        }
        else if (currentDistance >= _triggerDistance && _triggerState == TriggerState.Triggered)
        {
            _triggerState = TriggerState.NotTriggered;
        }

        if (_triggered == true)
        {
            MoveToPlayer();
        }

        if (currentDistance <= 1f)
        {
            _triggered = false;
        }
    }

    private void Rotate()
    {
        _ork.LookAt(_player.position);
    }

    protected override void Say()
    {
        Debug.Log("Say");
    }

    protected override void MoveToPlayer()
    {
        Rotate();
        _ork.position = Vector3.Lerp(_ork.position, _player.position, Time.deltaTime * _speed);
    }

    public override void ApplyDamage(float damage)
    {
        if (_health >= damage)
        {
            _health = _health - damage;
        }

        _hpBar.value = _health;
    }

    private enum TriggerState
    {
        Triggered,
        NotTriggered
    }
}

