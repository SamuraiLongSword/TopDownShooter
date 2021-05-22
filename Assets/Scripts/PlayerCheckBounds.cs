using UnityEngine;

public class PlayerCheckBounds : MonoBehaviour
{
    private float _xMax, _xMin, _yMax, _yMin;

    private void Awake()
    {
        _xMax = _yMax = 9.5f;
        _xMin = _yMin = -9.5f;
    }

    void LateUpdate()
    {
        LimitPosition();
    }

    private void LimitPosition()
    {
        Vector2 pos = transform.position;
        pos = CheckBounds(pos);
        transform.position = pos;
    }

    private Vector2 CheckBounds(Vector2 pos)
    {
        if (pos.x > _xMax) pos.x = _xMax;
        if (pos.x < _xMin) pos.x = _xMin;
        if (pos.y > _yMax) pos.y = _yMax;
        if (pos.y < _yMin) pos.y = _yMin;

        return pos;
    }
}
