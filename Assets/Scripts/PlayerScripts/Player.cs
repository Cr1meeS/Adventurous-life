using UnityEngine;


public class Player : MonoBehaviour, IDamageable, IKillable
{
    [SerializeField] private PlayerMovement _playerMovement;

    
    private StateMachine _stateMachine;

    public delegate void _PlayerDead();
    public event _PlayerDead OnPlayerDead;

    public delegate void _playerGetDamage(float damage);
    public event _playerGetDamage OnPlayerGetDamage;

    public Transform Camera;
    public Rigidbody Rigidbody;

    public PlayerMovementCharacteristics MovementCharacteristics;
    public PlayerInputManager PlayerInputManager;

    public PlayerJumping PlayerJumping;

    private void Awake()
    {
        PlayerInputManager = new PlayerInputManager(this);
        PlayerJumping = GetComponent<PlayerJumping>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            
        }
    }

    private void OnEnable()
    {
        PlayerInputManager.Enable();
    }
    private void OnDisable()
    {
        PlayerInputManager.Disable();
    }

    public void ApplyDamage(float damage)
    {
        OnPlayerGetDamage?.Invoke(damage);
    }

    public void KillEntity()
    {
        OnPlayerDead?.Invoke();
    }
}
