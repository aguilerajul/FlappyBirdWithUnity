using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private float _speedMovement;
    [SerializeField]
    private int _screenLimitOnPlusZ;

    private GameManager _gameManager;
    
    void Awake()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    
    void Update()
    {
        this.transform.Translate(Vector3.forward * _speedMovement * Time.deltaTime, Space.World);
        _gameManager.SetScore();
        if (this.gameObject.transform.position.z > _screenLimitOnPlusZ)
        {
            this.gameObject.SetActive(false);
        }
    }
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals("Player"))
        {
            _gameManager.CurrentScore += 1;
        }
    }

    public bool IsActive()
    {
        return this.gameObject.activeSelf;
    }

    public void SetActive()
    {
        this.gameObject.SetActive(true);
    }
}
