using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    private static readonly int IsWalking = Animator.StringToHash(IS_WALKING); // Avoids per-frame lookups

    [SerializeField] private Player player;
    
    private Animator _animator;
    
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(IsWalking, player.IsWalking());
    }
}
