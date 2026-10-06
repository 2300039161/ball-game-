using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public static bool gameOver = false;

    void Awake()
    {
        score = 0;
        gameOver = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnGUI()
    {
        GUIStyle scoreStyle = new GUIStyle(GUI.skin.label);
        scoreStyle.fontSize = 48;
        scoreStyle.fontStyle = FontStyle.Bold;
        scoreStyle.alignment = TextAnchor.UpperCenter;
        scoreStyle.normal.textColor = Color.white;

        GUI.Label(
            new Rect(0, 20, Screen.width, 70),
            "Score: " + score,
            scoreStyle
        );

        if (gameOver)
        {
            GUIStyle gameOverStyle = new GUIStyle(GUI.skin.label);
            gameOverStyle.fontSize = 72;
            gameOverStyle.fontStyle = FontStyle.Bold;
            gameOverStyle.alignment = TextAnchor.MiddleCenter;
            gameOverStyle.normal.textColor = Color.red;

            GUI.Label(
                new Rect(0, Screen.height / 2 - 70, Screen.width, 100),
                "GAME OVER",
                gameOverStyle
            );

            GUIStyle restartStyle = new GUIStyle(GUI.skin.label);
            restartStyle.fontSize = 32;
            restartStyle.alignment = TextAnchor.MiddleCenter;
            restartStyle.normal.textColor = Color.white;

            GUI.Label(
                new Rect(0, Screen.height / 2 + 20, Screen.width, 50),
                "Press R to restart",
                restartStyle
            );
        }
    }
}