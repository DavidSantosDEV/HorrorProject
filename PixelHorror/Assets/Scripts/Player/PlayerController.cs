using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerActions inputActions;

    private PlayerMovement myMovement;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private GameObject Head;
    [SerializeField]
    private GameObject Legs;

    private void Awake()
    {
        myMovement = GetComponent<PlayerMovement>();

        inputActions = new PlayerActions();
        inputActions.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.SetPlayer(this);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPoint = cam.ScreenToWorldPoint(inputActions.Gameplay.Aim.ReadValue<Vector2>());

        float angle = Quaternion.FromToRotation(Vector3.up, worldPoint - transform.position).eulerAngles.z;
        Head.transform.localEulerAngles = new Vector3(0, 0, angle);


        myMovement.UpdateInput(inputActions.Gameplay.Movement.ReadValue<Vector2>());
    }
}
