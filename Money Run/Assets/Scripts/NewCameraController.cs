using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewCameraController : MonoBehaviour
{
    public EndGameEvents endGame;
    public Transform target;

    public float smoothSpeed = 2f;
    public Vector3 offset;
    private void Awake()
    {
        endGame.onEndGameTrigger += StopAtEndGame;
    }
    private void Start()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition,Time.deltaTime* smoothSpeed);
        transform.position = smoothedPosition;
    }

    void StopAtEndGame()
    {
        GetComponent<NewCameraController>().enabled = false;
        transform.DOLocalMoveX(0, 1.5f);
    }
}
