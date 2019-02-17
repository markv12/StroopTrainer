using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public TMP_Text mainText;

    public Button startButton;

    public Canvas gameCanvas;

    public Button[] colorButtons;
    public TMP_Text[] colorButtonTexts;

    public TMP_Text gameResultText;

    public ColorInfo colorInfo;

    private void Awake() {
        startButton.onClick.AddListener(delegate { StartGame(); });

        for (int i = 0; i < colorButtons.Length; i++) {
            colorButtonTexts[i].text = colorInfo.items[i].name;
            int index = i;
            colorButtons[i].onClick.AddListener(delegate { ClickColorButton(index); });
        }
    }

    private bool inGame;
    private bool InGame {
        get {
            return inGame;
        }
        set {
            inGame = value;
            startButton.gameObject.SetActive(!inGame);
            gameCanvas.gameObject.SetActive(inGame);
        }
    }
    private ColorPair currentPair;
    private ColorPair CurrentPair {
        get {
            return currentPair;
        }
        set {
            currentPair = value;
            mainText.text = colorInfo.items[currentPair.textColor].name;
            mainText.color = colorInfo.items[currentPair.displayColor].color;
        }
    }

    private float gameStartTime = 0;
    private int correctAnswers = 0;
    private const int CORRECT_ANSWERS_PER_GAME = 20;
    private void StartGame() {
        InGame = true;
        correctAnswers = 0;
        gameStartTime = Time.time;
        CurrentPair = GetNextPair();
    }

    public void ClickColorButton(int index) {
        if (InGame) {
            if (index == currentPair.displayColor) {
                correctAnswers++;
            }
            if(correctAnswers >= CORRECT_ANSWERS_PER_GAME) {
                float timeTaken = Time.time - gameStartTime;
                gameResultText.text = CORRECT_ANSWERS_PER_GAME + " correct answers in: " + timeTaken.ToString("0.##") + " seconds";
                InGame = false;
            }
            CurrentPair = GetNextPair();
        }
    }

    private ColorPair GetNextPair() {
        int dc = Random.Range(0, colorInfo.items.Length);
        int tc;
        do {
            tc = Random.Range(0, colorInfo.items.Length);
        } while (tc == dc);

        return new ColorPair() {
            displayColor = dc,
            textColor = tc
        };
    }

    private struct ColorPair {
        public int displayColor;
        public int textColor;
    }
}
