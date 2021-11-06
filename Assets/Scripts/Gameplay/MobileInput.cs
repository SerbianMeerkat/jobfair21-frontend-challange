using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    [HideInInspector] public float inputX { get; private set; }
    [HideInInspector] public bool jump { get; private set; }

    private static MobileInput _instance;
    public static MobileInput Instance => _instance;

    public static bool inputEnabled => Input.touchSupported;

    void Awake()
    {
        if (_instance == null) _instance = this;

        gameObject.SetActive(inputEnabled);
    }

    #region Event Handlers
    public void Input_MoveLeft(bool state)
    {
        inputX = state ? -1f : 0f;
    }

    public void Input_MoveRight(bool state)
    {
        inputX = state ? 1f : 0f;
    }

    public void Input_Jump(bool state)
    {
        jump = state;
    }
    #endregion
}
