using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public static PointCounter S;

    private int _maxPoints;
    private int _currnetPoints;
    private int _mobCounter;

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

    public int CurrentPoints
    {
        get { return _currnetPoints; }
        set
        {
            if (_currnetPoints >= value)
            {
                _currnetPoints = value;
            }
            else
            {
                // Send message 'not enough money' or something like that
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
