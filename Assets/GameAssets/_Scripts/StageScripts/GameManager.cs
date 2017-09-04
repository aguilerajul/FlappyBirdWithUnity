using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    #region UnityEditor
    [Header("Propiedades")]
    [SerializeField]
    private float _pipeSpeed;
    [SerializeField]
    private Vector2 _maxHeigh;
    [SerializeField]
    private int _pipesToCreate;

    [Header("Prefabs")]
    [SerializeField]
    private GameObject _pipeObjectRef;
    #endregion

    #region GlobalProperties
    private string DefaultScoreText { get; set; }
    private Text ScoreTextRef { get; set; }
    #endregion

    #region Public Variables
    public int CurrentScore { get; set; }
    #endregion

    #region Private Variables
    private PipeEndlessController _pipeEndlessController;
    #endregion

    void Awake()
    {
        ScoreTextRef = GameObject.Find("txtPanel").GetComponent<Text>();
        _pipeEndlessController = GameObject.FindObjectOfType<PipeEndlessController>();
    }

    // Use this for initialization
    void Start()
    {
        DefaultScoreText = "SCORE: {0}";
        if (ScoreTextRef != null)
        {
            ScoreTextRef.text = string.Format(DefaultScoreText, 0);
        }

        //InvokeRepeating("GeneratePipes", 0, 1);
        _pipeEndlessController.GeneratePipes(new PipeEntity
        {
            PipesPrefab = _pipeObjectRef,
            MaxHeight = _maxHeigh,
            Position = transform.position,
            PipesToCreate = _pipesToCreate
        });
    }

    public void SetScore()
    {
        if (ScoreTextRef != null && CurrentScore > 0)
        {
            ScoreTextRef.text = string.Format(DefaultScoreText, CurrentScore);
        }
        else
        {
            Debug.Log("The Score Text box has not been assined");
        }
    }
}
