using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("GameManager is Null");
            }
            return _instance;
        }
    }

    [SerializeField] private Slider villageHealth;
    [SerializeField] private int winSurvivalTime = 180;
    private int survivalTime = 0;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TextMeshProUGUI resultTxt;
    [SerializeField] private SpaceFinder finder;
    public static bool isInventryItem;

    [SerializeField]  private EnemyMovement[] enemies;


    private void Awake()
    {
        _instance = this;
    }

    private void Start() 
    {
        StartCoroutine(SurvivingTime());
    }
    #region GameLogics
    IEnumerator SurvivingTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            survivalTime++;
            if (survivalTime == winSurvivalTime)
            {
                Won();
            }
        }
    }

    public void StartDamagingVillage()
    {
        StartCoroutine(VillageDamage());
    }
    IEnumerator VillageDamage()
    {
        while (villageHealth.value>=1)
        {
            yield return new WaitForSeconds(1f);
            villageHealth.value--;
            if (villageHealth.value == 0)
            {
                Loss();
            }
        }
    }
    private void Won()
    {
        StopCoroutine(SurvivingTime());
        resultPanel.SetActive(true);
        resultTxt.text = "You Won!";
        Time.timeScale = 0;
    }
    private void Loss()
    {
        StopCoroutine(VillageDamage());
        resultPanel.SetActive(true);
        resultTxt.text = "You Loss!";
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void PickWeapon(GameObject weapon)
    {
        isInventryItem = true;
        finder.pickedObject = weapon;
    }

    public void PowerUpEffect(int ID)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (ID == 0)
            {
                enemies[i].WalkSlow();
            }
            else if (ID == 1)
            {
                enemies[i].TakeDamage(100f);
                Invoke("Won", 2f);
            }
        }

    }
    #endregion
}
