using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Core;

public class Leaderboard : MonoBehaviour
{
    public bool isOpen = false;
    [SerializeField] GameObject buttonToReturnTo;


    [Header("Move Leaderboard")]
    [Space(30)]
    [SerializeField] GameObject leaderboard;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float minY = 0f;
    [SerializeField] float maxY = 0f;
    [SerializeField] float currentY = 0f;


    [Space(30)]
    [SerializeField] GameObject[] objectsToDisable;


    private GameObject leaderboardPanel;


    // Scripts
    private GameInput _GameInput;
    private AudioCue _AudioCue;



    private void Awake()
    {
        // Scripts
        _GameInput = new GameInput();
        _AudioCue = GetComponent<AudioCue>();


        leaderboardPanel = transform.GetChild(0).gameObject;
    }
    private void Start()
    {
        // Disable Panel
        leaderboardPanel.SetActive(false);
    }


    private void OnEnable()
    {
        _GameInput.Enable();
    }
    private void OnDisable()
    {
        _GameInput.Disable();
    }


    private void Update()
    {
        // Close Leaderboard
        if (_GameInput.UI.Return.triggered)
        {
            if (isOpen)
            {
                _AudioCue.PlayAudioCue();
                DisableLeaderboardPanel();
            }
        }


        // Move leaderboard
        if (isOpen) { ScrollLeaderboard(); }
    }


    public void EnableLeaderboardPanel(GameObject buttonToReturn)
    {
        // Enable Panel
        leaderboardPanel.SetActive(true);

        // Set var
        buttonToReturnTo = buttonToReturn;

        // Update Var
        isOpen = true;

        // Disable Objects
        for (int i = 0; i < objectsToDisable.Length; i++)
        {
            objectsToDisable[i].SetActive(false);
        }
    }
    public void DisableLeaderboardPanel()
    {
        // Disable Panel
        leaderboardPanel.SetActive(false);

        // Update Var
        isOpen = false;

        // Enable Objects
        for (int i = 0; i < objectsToDisable.Length; i++)
        {
            objectsToDisable[i].SetActive(true);
        }

        // Set selected Button
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttonToReturnTo);
    }


    private void ScrollLeaderboard()
    {
        if(Save.Get(SaveConstants.MouseState, 1) == 0)
        {
            if(_GameInput.UI.Navigate.ReadValue<Vector2>().y < 0 && currentY < maxY)
            {
                leaderboard.transform.position += new Vector3(0f, moveSpeed, 0f);
                currentY += moveSpeed;
            }

            else if (_GameInput.UI.Navigate.ReadValue<Vector2>().y > 0 && currentY > minY)
            {
                leaderboard.transform.position += new Vector3(0f, -moveSpeed, 0f);
                currentY -= moveSpeed;
            }


            if (scrollRect != null) { scrollRect.enabled = false; }
        }
        else
        {
            if(scrollRect != null) { scrollRect.enabled = true; }
        }
    }
}
