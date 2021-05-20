using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Player;

    private float _smoothTime;
    private Vector3 _velosity;

    private float _camMaxX, _camMinX, _camMaxY, _camMinY;

    private void Awake()
    {
        _smoothTime = 0.3f;
        _velosity = Vector3.zero;

        _camMaxX = 3f;
        _camMinX = -3f;
        _camMaxY = 7f;
        _camMinY = -7f;
    }

    private void LateUpdate()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        Vector3 target = new Vector3(Player.position.x, Player.position.y, transform.position.z);

        target = CameraCheckBounds(target);

        transform.position = Vector3.SmoothDamp(transform.position, target, ref _velosity, _smoothTime);
    }

    private Vector3 CameraCheckBounds(Vector3 target)
    {
        if (target.x > _camMaxX) target.x = _camMaxX;
        if (target.x < _camMinX) target.x = _camMinX;
        if (target.y > _camMaxY) target.y = _camMaxY;
        if (target.y < _camMinY) target.y = _camMinY;

        return target;
    }
}
