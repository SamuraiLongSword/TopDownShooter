using UnityEngine;

[RequireComponent(typeof(PlayerInput))]

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private GameObject PlayerAnimationGO;

    private Animator _playerAnimator;
    private SpriteRenderer _sRenderer;
    private PlayerInput _pInput;

    private void Awake()
    {
        _playerAnimator = PlayerAnimationGO.GetComponent<Animator>();
        _sRenderer = PlayerAnimationGO.GetComponent<SpriteRenderer>();
        _pInput = GetComponent<PlayerInput>();
    }

    private void Update() => AnimationLogic();

    private void AnimationLogic()
    {
        if (!Mathf.Approximately(_pInput.Horizontal, 0) || !Mathf.Approximately(_pInput.Vertical, 0))
        {
            if (_pInput.Horizontal >= 0) _sRenderer.flipX = false;
            else _sRenderer.flipX = true;

            _playerAnimator.SetBool("IsMoving", true);
        }
        else _playerAnimator.SetBool("IsMoving", false);
    }
}
