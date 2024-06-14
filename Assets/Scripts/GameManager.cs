using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject bolinhaPrefab;
    public Text Score1, Score2;
    public static int score1 = 0, score2 = 0;
    public static GameManager instance;
    public int ScoreMax;

    private GameObject currentBola;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            InicializarJogo();
        }
    }

    void InicializarJogo()
    {
        score1 = 0;
        score2 = 0;

        if (Score1 == null || Score2 == null)
        {
            Score1 = GameObject.Find("Score1")?.GetComponent<Text>();
            Score2 = GameObject.Find("Score2")?.GetComponent<Text>();
        }

        if (Score1 == null || Score2 == null)
        {
            Debug.LogError("Score1 or Score2 Text objects not found in the scene.");
            return;
        }

        AtualizarPontuacao();
        if (currentBola == null)
        {
            SpawnBola();
        }
    }

    public static void SpawnBola()
    {
        if (instance != null && instance.bolinhaPrefab != null)
        {
            if (instance.currentBola != null)
            {
                Destroy(instance.currentBola);
            }
            instance.currentBola = Instantiate(instance.bolinhaPrefab);
            Bola bolaEmJogo = instance.currentBola.GetComponent<Bola>();
            if (bolaEmJogo != null)
            {
                bolaEmJogo.transform.position = Vector3.zero;
            }
            else
            {
                Debug.LogError("O prefab da bolinha não tem o componente Bola.");
            }
        }
        else
        {
            Debug.LogError("Instance ou bolinha é nulo!");
        }
    }

    public static void AtualizarPontuacao()
    {
        if (instance != null && instance.Score1 != null && instance.Score2 != null)
        {
            instance.Score1.text = score1.ToString();
            instance.Score2.text = score2.ToString();
            instance.PlacarMax();
        }
        else
        {
            Debug.LogError("GameManager instance or Score1/Score2 is null");
        }
    }

    private void PlacarMax()
    {
        if (score1 >= ScoreMax || score2 >= ScoreMax)
        {
            SceneManager.LoadScene(2);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            InicializarJogo();
        }
       
    }
}