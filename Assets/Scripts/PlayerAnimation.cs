using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerAnimation : MonoBehaviour
{
    private Animator _playerAnimator;
    private PlayerInput _pInput;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
        _pInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        AnimationLogic();
    }

    private void AnimationLogic()
    {
        if (!Mathf.Approximately(_pInput.Horizontal, 0) || !Mathf.Approximately(_pInput.Vertical, 0))
        {
            Vector3 localScale = transform.localScale;
            transform.localScale = new Vector3(Mathf.Sign(_pInput.Horizontal) * Mathf.Abs(localScale.x), localScale.y, localScale.z);

            _playerAnimator.SetBool("IsMoving", true);
        }
        else _playerAnimator.SetBool("IsMoving", false);
    }
}
