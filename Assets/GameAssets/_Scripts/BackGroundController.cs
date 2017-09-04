using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [SerializeField] private float _speedMovement = 0.1f;
    private MeshRenderer _backgroundMeshRenderer;

    void Awake()
    {
        _backgroundMeshRenderer = GetComponent<MeshRenderer>();
    }
    
    void Update()
    {
        _backgroundMeshRenderer.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(Time.time * _speedMovement, 0));
    }
}
