using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;


public class GetControllerType : MonoBehaviour
{
    public CurrentController controllerType;

    Gamepad gamepad = Gamepad.current;
    Keyboard keyboard = Keyboard.current;
    Mouse mouse = Mouse.current;


    public static GetControllerType instance;



    private void Awake()
    {
        // Check if already exists
        if (instance == null) { instance = this; }
        else
        {
            Destroy(gameObject);
            return;
        }


        // Dont Destroy
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        gamepad = Gamepad.current;
        keyboard = Keyboard.current;
        mouse = Mouse.current;


        // Gamepad
        if (gamepad != null)
        {
            if (gamepad is DualShockGamepad) { controllerType = CurrentController.Playstation; }
            else { controllerType = CurrentController.Xbox; }
        }
        // Keyboard
        else if (keyboard != null)
        {
            controllerType = CurrentController.Keyboard;
        }
        // Mouse
        else if (mouse != null)
        {
            controllerType = CurrentController.Mouse;
        }
    }
}
