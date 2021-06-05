using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public static PointCounter S;

    private int _maxPoints;
    private int _currnetPoints;
    private int _mobCounter;

    // Property for increasing player max points, current points and counting killed enemies
    public int MaxPoints
    {
        get { return _maxPoints; }
        set
        {
            _maxPoints += value;
            _currnetPoints += value;
            _mobCounter += 1;
        }
    }

    // Property for reducing player points when buying a clip
    public int CurrentPoints
    {
        get { return _currnetPoints; }
        set
        {
            if (_currnetPoints >= value)
            {
                _currnetPoints = value;
            }
        }
    }

    public int MobCounter
    {
        get { return _mobCounter; }
    }

    private void Awake()
    {
        S = this;
        _maxPoints = 0;
        _currnetPoints = 0;
        _mobCounter = 0;
    }
}
