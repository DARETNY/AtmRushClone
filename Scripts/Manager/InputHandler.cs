using System.Collections.Generic;
using AtmRushClone.Scripts.Data.SoData;
using AtmRushClone.Scripts.Keys;
using AtmRushClone.Scripts.Signals;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AtmRushClone.Scripts.Manager
{
    public class InputHandler : MonoBehaviour
    {
        #region Self Variables

        #region Private Variables

        private float _positionValuesX;

        private bool _isTouching;

        private float _currentVelocity; //ref type
        private Vector2? _mousePosition; //ref type
        private Vector3 _moveVector; //ref type

        [Header("Data")] public So_Player _data;
        private bool _isFirstTimeTouchTaken;
        private bool _isAvailableForTouch;

        #endregion

        #endregion


        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            GameSıgnals.InputSystemStateSıgnals.Onreset += OnReset;
            GameSıgnals.InputSystemStateSıgnals.Onplay += OnPlay;
            GameSıgnals.InputSystemStateSıgnals.OninputStateChange += OnChangeInputState;
        }

        private void OnPlay()
        {
            _isAvailableForTouch = true;
        }


        private void OnChangeInputState(bool state)
        {
            _isAvailableForTouch = state;
        }

        private void UnSubscribeEvents()
        {
            GameSıgnals.InputSystemStateSıgnals.Onreset -= OnReset;
            GameSıgnals.InputSystemStateSıgnals.Onplay -= OnPlay;
            GameSıgnals.InputSystemStateSıgnals.OninputStateChange -= OnChangeInputState;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }


        private void Update()
        {
            if (!_isAvailableForTouch) return;

            if (Input.GetMouseButtonUp(0) && !IsPointerOverUIElement())
            {
                _isTouching = false;

                GameSıgnals.InputSystemSıgnals.OnTouchrelease?.Invoke();
            }

            if (Input.GetMouseButtonDown(0) && !IsPointerOverUIElement())
            {
                _isTouching = true;
                GameSıgnals.InputSystemSıgnals.InputTaken?.Invoke();
                if (!_isFirstTimeTouchTaken)
                {
                    _isFirstTimeTouchTaken = true;
                    GameSıgnals.InputSystemSıgnals.OnfirstTouch?.Invoke();
                }

                _mousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0) && !IsPointerOverUIElement())
            {
                if (_isTouching)
                {
                    if (_mousePosition != null)
                    {
                        Vector2 mouseDeltaPos = (Vector2)Input.mousePosition - _mousePosition.Value;


                        if (mouseDeltaPos.x > _data.inputdata.horizontalSpeed)
                            _moveVector.x = _data.inputdata.horizontalSpeed / 10f * mouseDeltaPos.x;
                        else if (mouseDeltaPos.x < -_data.inputdata.horizontalSpeed)
                            _moveVector.x = -_data.inputdata.horizontalSpeed / 10f * -mouseDeltaPos.x;
                        else
                            _moveVector.x = Mathf.SmoothDamp(_moveVector.x, 0f, ref _currentVelocity,
                                _data.inputdata.stopeSlope);

                        _mousePosition = Input.mousePosition;


                        GameSıgnals.InputSystemSıgnals.OninputDraged?.Invoke(new HorizantalParms()
                        {
                            HorizantalInputValue = _moveVector.x,
                            HorizantalClamp = _data.inputdata.verticalSpeed.x // negative
                        });
                    }
                }
            }
        }


        private bool IsPointerOverUIElement()
        {
            if (EventSystem.current == null) return false;
            var eventData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            return results.Count > 0;
        }

        private void OnReset()
        {
            _isTouching = false;
            _isFirstTimeTouchTaken = false;
        }
    }
}