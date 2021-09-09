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

    [Header("Interactible Detection")]
    [SerializeField]
    private float interactReach=2;
    [SerializeField]
    private LayerMask interactibleLayer;
    [SerializeField]
    private float angleOffSet = 90;
    [SerializeField]
    private InteractionData interactionData;

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

        CheckInteractible(GameManager.DegreeToVector2(angle+angleOffSet));
    }

    private void CheckInteractible(Vector2 direction)
    {
        Vector3 startpos = transform.position;// + new Vector3(offsetXInteract, offsetYInteract);
        RaycastHit2D _Hits;
        _Hits = Physics2D.Raycast(startpos, direction, interactReach, interactibleLayer);



        if (_Hits)
        {
            InteractibleBase interactible = _Hits.transform.GetComponent<InteractibleBase>();
            if (interactible)
            {
                if (interactionData.IsEmpty())
                {
                    interactionData.Interactible = interactible;
                    Debug.DrawRay(startpos, direction * interactReach, Color.green);
                }
                else
                {
                    if (!interactionData.IsSameInteractible(interactible))
                    {
                        interactionData.Interactible = interactible;
                        Debug.DrawRay(startpos, direction * interactReach, Color.green);
                    }
                    else
                    {
                        Debug.DrawRay(startpos, direction * interactReach, Color.green);
                        return;
                    }
                }
            }
        }
        else
        {
            Debug.DrawRay(startpos, direction * interactReach, Color.red);
            interactionData.ResetData();
        }
    }
}
