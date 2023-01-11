using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IGameplayActions, GameInput.IMenusActions, GameInput.IDialoguesActions
{
	// Gameplay
	public event UnityAction<Vector2> moveEvent;
	public event UnityAction jumpEvent;
	public event UnityAction jumpCanceledEvent;
	public event UnityAction attackEvent;
	public event UnityAction attackCanceledEvent;
	public event UnityAction interactEvent;
	public event UnityAction pauseEvent;
	public event UnityAction returnEvent;
	public event UnityAction rechargeEvent;
	public event UnityAction<Vector2, bool> lookEvent;
	public event UnityAction dashEvent;
	public event UnityAction soarEvent;
	public event UnityAction soarCanceledEvent;
	public event UnityAction mouseDownEvent;
	public event UnityAction mouseUpEvent;
	public event UnityAction <Vector2> mousePositionEvent;


	//Menu
	public event UnityAction<Vector2> moveSelectionEvent;
	public event UnityAction confirmEvent;
	public event UnityAction cancelEvent;


	// Dialogue
	public event UnityAction<Vector2> onDialogueSelectEvent;
	public event UnityAction advanceDialogueEvent;

	private GameInput gameInput;

	private void OnEnable()
	{
		if (gameInput == null)
		{
			gameInput = new GameInput();
			gameInput.Gameplay.SetCallbacks(this);
			gameInput.Menus.SetCallbacks(this);
			gameInput.Dialogues.SetCallbacks(this);
		}
		EnableGameplayInput();
	}

	private void OnDisable()
	{
		DisableAllInput();
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		if (moveEvent != null)
		{
			moveEvent.Invoke(context.ReadValue<Vector2>());
		}
	}

	public void OnJump(InputAction.CallbackContext context)
	{
		if (jumpEvent != null
			&& context.phase == InputActionPhase.Performed)
			jumpEvent.Invoke();

		if (jumpCanceledEvent != null
			&& context.phase == InputActionPhase.Canceled)
			jumpCanceledEvent.Invoke();
	}

	public void OnAttack(InputAction.CallbackContext context)
	{
		if (attackEvent != null
			&& context.phase == InputActionPhase.Performed)
			attackEvent.Invoke();
		if (attackCanceledEvent != null
			&& context.phase == InputActionPhase.Canceled)
			attackCanceledEvent.Invoke();
	}

	public void OnInteract(InputAction.CallbackContext context)
	{
		if (interactEvent != null
			&& context.phase == InputActionPhase.Performed)
			interactEvent.Invoke();
	}

	public void OnPause(InputAction.CallbackContext context)
	{
		if (pauseEvent != null
			&& context.phase == InputActionPhase.Performed)
			pauseEvent.Invoke();
	}

	public void OnRecharge(InputAction.CallbackContext context)
	{
		if (rechargeEvent != null
			 && context.phase == InputActionPhase.Performed)
			rechargeEvent.Invoke();
	}

	public void OnDash(InputAction.CallbackContext context)
	{
		if (dashEvent != null
			 && context.phase == InputActionPhase.Performed)
			dashEvent.Invoke();
	}

	public void OnMoveSelection(InputAction.CallbackContext context)
	{
		if (moveSelectionEvent != null)
		{
			moveSelectionEvent.Invoke(context.ReadValue<Vector2>());
		}
	}

	public void OnConfirm(InputAction.CallbackContext context)
	{
		if (confirmEvent != null
			&& context.phase == InputActionPhase.Performed)
			confirmEvent.Invoke();
	}

	public void OnCancel(InputAction.CallbackContext context)
	{
		if (cancelEvent != null
			&& context.phase == InputActionPhase.Performed)
			cancelEvent.Invoke();
	}

	public void OnDialogueSelect(InputAction.CallbackContext context)
	{
		if (onDialogueSelectEvent != null)
		{
			onDialogueSelectEvent.Invoke(context.ReadValue<Vector2>());
		}
	}

	public void OnAdvanceDialogue(InputAction.CallbackContext context)
	{
		if (advanceDialogueEvent != null
			&& context.phase == InputActionPhase.Performed)
			advanceDialogueEvent.Invoke();
	}

	public void EnableDialogueInput()
	{
		gameInput.Dialogues.Enable();
		gameInput.Gameplay.Disable();
		gameInput.Menus.Disable();
	}

	public void EnableGameplayInput()
	{
		gameInput.Gameplay.Enable();
		gameInput.Dialogues.Disable();
		gameInput.Menus.Disable();
	}

	public void EnableMenusInput()
	{
		gameInput.Menus.Enable();
		gameInput.Gameplay.Disable();
		gameInput.Dialogues.Disable();
	}

	public void DisableAllInput()
	{
		gameInput.Gameplay.Disable();
		gameInput.Dialogues.Disable();
	}

    public void OnMouseClick(InputAction.CallbackContext context)
    {
		if (mouseDownEvent != null
			 && context.phase == InputActionPhase.Performed)
			mouseDownEvent.Invoke(); 
		if (mouseUpEvent != null
			  && context.phase == InputActionPhase.Canceled)
			mouseUpEvent.Invoke();
	}

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        if (mousePositionEvent != null
              && context.phase == InputActionPhase.Performed)
            mousePositionEvent.Invoke(context.ReadValue<Vector2>());
	}

    public void OnSoar(InputAction.CallbackContext context)
    {
		if (soarEvent != null
			 && context.phase == InputActionPhase.Performed)
			soarEvent.Invoke();
		if (soarCanceledEvent != null
			  && context.phase == InputActionPhase.Canceled)
			soarCanceledEvent.Invoke();
	}

    public void OnLook(InputAction.CallbackContext context)
    {
		if (lookEvent != null)
		{
			lookEvent.Invoke(context.ReadValue<Vector2>(), IsDeviceMouse(context));
		}
	}

    private bool IsDeviceMouse(InputAction.CallbackContext context) => context.control.device.name == "Mouse";

    public void OnReturn(InputAction.CallbackContext context)
    {
		if (returnEvent != null
		&& context.phase == InputActionPhase.Performed)
			returnEvent.Invoke();
	}
}
