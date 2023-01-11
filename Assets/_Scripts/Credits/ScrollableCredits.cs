using UnityEngine;

public class ScrollableCredits : MonoBehaviour
{
    public RectTransform _rectTransform;
    public RectTransform _destination;
    public float _speed;
    public bool _activated;
    public bool _rolling;
    public bool _end;
    public Vector3 _startPosition;
    public Vector3 _restartPosition;

    [Header("Automatic Scene Loader")]
    public LoadSceneEventChannelSO onPlayButtonPress;
    public GameSceneSO[] locationsToLoad;
    public bool showLoadScreen;

    private void OnEnable()
    {
        _startPosition = _restartPosition;
        _activated = true;
    }


    public void Activate()
    {
        _activated = true;
    }

    private void Awake()
    {
        _startPosition = _rectTransform.position;
        _restartPosition = _rectTransform.position;
    }

    private void Update()
    {
        if (_activated)
        {
            _rectTransform.position = _startPosition;
            _rolling = true;
            _activated = false;
        }
        if (_rolling)
        {
            if (_rectTransform.position.y < _destination.position.y)
            {
                _rectTransform.position = new Vector3(_rectTransform.position.x, _rectTransform.position.y + (_speed * Time.deltaTime), _rectTransform.position.z);
            }
            else
            {
                _rolling = false;
                if (_end)
                {
                    OnButtonPress();
                }
            }

        }
    }


    public void OnButtonPress()
    {
        onPlayButtonPress.RaiseEvent(locationsToLoad, showLoadScreen);
    }

}

