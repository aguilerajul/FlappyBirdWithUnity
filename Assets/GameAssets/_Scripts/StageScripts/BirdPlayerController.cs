using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class BirdPlayerController : MonoBehaviour
{
    [SerializeField] int _jumpForce;
    [SerializeField] private AudioClip _birdFlyingAudioClip;
    [SerializeField] private AudioClip _birdDeathAudioClip;

    private Rigidbody _rb;
    private Animator _animator;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _animator.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && !GlobalVariables.IsPlayerDead)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            if (_birdFlyingAudioClip != null)
            {
                AudioSource.PlayClipAtPoint(_birdFlyingAudioClip, this.transform.position, 1f);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        _animator.enabled = true;
        _rb.useGravity = false;
        GlobalVariables.IsPlayerDead = true;
        if (_birdDeathAudioClip != null)
        {
            AudioSource.PlayClipAtPoint(_birdDeathAudioClip, this.transform.position, 1f);
        }

        StartCoroutine(DisplayGameOverCourutine());
    }

    IEnumerator DisplayGameOverCourutine()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("GameOver");
    }
}
