using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public IntVariable gameScore;
    public GameObject scoreText;
    void Start()
    {
        SetHighScore();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartNewGame()
    {
        SceneManager.LoadSceneAsync("LoadingScene", LoadSceneMode.Single);
    }
    void SetHighScore()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = gameScore.previousHighestValue.ToString("D6");
    }
    public void ResetHighScore()
    {
        GameObject eventSystem = GameObject.Find("EventSystem");
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        gameScore.ResetHighestValue();
        SetHighScore();

    }

}
