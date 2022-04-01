using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
   
    private int survivalTime;
    [SerializeField]private GameObject resultPanel;
    [SerializeField] private TextMeshProUGUI resultTxt;

    private void Start() 
    {
        StartCoroutine(SurvivingTime());
    }

    IEnumerator SurvivingTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            survivalTime++;
            if (survivalTime == 180)
            {
                Won();
            }
        }
    }

    private void Won()
    {
        StopCoroutine(SurvivingTime());
        resultPanel.SetActive(true);
        resultTxt.text = "You Won!";
    }
    private void Loss()
    {
        StopCoroutine(SurvivingTime());
        resultPanel.SetActive(true);
        resultTxt.text = "You Loss!";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
