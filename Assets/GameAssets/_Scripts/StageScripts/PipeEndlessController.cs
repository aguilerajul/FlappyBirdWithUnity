using System.Collections.Generic;
using UnityEngine;

public class PipeEndlessController : MonoBehaviour
{
    private List<GameObject> _poolingPipesList;
    private PipeEntity _pipeEntity;
    
    // Use this for initialization
    void Awake()
    {
        _poolingPipesList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalVariables.IsPlayerDead)
        {
            for (int i = 0; i < _poolingPipesList.Count; i++)
            {
                var pipeController = _poolingPipesList[i].GetComponentInChildren<PipeController>();
                if (!pipeController.IsActive())
                {
                    float rnd = Random.Range(_pipeEntity.MaxHeight.x, _pipeEntity.MaxHeight.y);
                    rnd = Mathf.Clamp(rnd, _pipeEntity.MaxHeight.x, _pipeEntity.MaxHeight.y);

                    Vector3 pipePosition = SetPipeInitialPosition(_pipeEntity, false);
                    pipePosition.y += rnd;

                    _poolingPipesList[i].gameObject.transform.position = pipePosition;
                    _poolingPipesList[i].GetComponentInChildren<PipeController>().SetActive();
                }
            }
        }        
    }

    public void GeneratePipes(PipeEntity pipeEntity)
    {
        _pipeEntity = pipeEntity;
        for (int i = 0; i < pipeEntity.PipesToCreate; i++)
        {
            Vector3 pipePosition = SetPipeInitialPosition(pipeEntity);
            var instanceObj = GameObject.Instantiate(pipeEntity.PipesPrefab, pipePosition, Quaternion.identity);
            _poolingPipesList.Add(instanceObj);
        }
    }

    private Vector3 SetPipeInitialPosition(PipeEntity pipeEntity, bool addDistance = true)
    {
        float rnd = Random.Range(pipeEntity.MaxHeight.x, pipeEntity.MaxHeight.y);
        Vector3 finalPos = pipeEntity.Position;
        finalPos.y += rnd;
        if (_poolingPipesList.Count > 0 && addDistance)
        {
            finalPos.z += _poolingPipesList[_poolingPipesList.Count - 1].transform.position.z + 5f;
        }

        return finalPos;
    }
}
