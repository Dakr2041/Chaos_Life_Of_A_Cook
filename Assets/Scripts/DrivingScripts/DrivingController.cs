using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DrivingController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;

    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameObject vehicle;

    private static string DEAD_STOP_TAG = "DeadStop";

    void Update()
    {
        HandleSpeed();
        HandleMovement();

    }

    private async void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == DEAD_STOP_TAG)
        {
            await Task.Delay(500);
            Loader.Load(Loader.Scene.SurvivorScene);
        }
    }


    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, 0f);
        transform.Rotate(Vector3.up,moveDir.x * Time.deltaTime * turnSpeed);

    }

    private void HandleSpeed()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirSpeed = new Vector3(0f, 0f, inputVector.y);
        transform.Translate(moveDirSpeed * Time.deltaTime * speed);

    }
}
