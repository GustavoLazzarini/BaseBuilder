using UnityEngine;

public enum ControllerType
{
    XBox,
    Playstation,
    Nintendo,
    KeyboardAndMouse
}

public enum ControllerButtonType
{
    A,
    B,
    Y,
    X,
    LB,
    RB,
    LT,
    RT,
    ANALOG_L,
    ANALOG_R,
    SELECT,
    START
}

[CreateAssetMenu(menuName = "Controllers UI/Controllers Data")]
public class ControllersUIData : ScriptableObject
{
    [Header("Controllers")]
    public ControllerUIData xBoxData;
    public ControllerUIData playstationData;
    public ControllerUIData nintendoData;
    public ControllerUIData keyboardAndMouseData;
}
