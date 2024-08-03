using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunshipMovement : MonoBehaviour
{


    private Gunship gunship;
    GameInput gameInput;

    private float moveSpeed = 10f;

    void Start()
    {
        Init();
    }

    void Init()
    {
        gunship = GetComponent<Gunship>();        
        gameInput = gunship.GameInput;
        
    }
    void Update()
    {
        Handle_Movement();
    }

    void Handle_Movement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormailized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;

        // 맵 범위를 벗어나는지 후에 체크
        //bool canMove = default;

        transform.position += moveDir * moveDistance;



    }
}
