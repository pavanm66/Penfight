using System;
using System.Collections;
using UnityEngine;

public class PenScript : MonoBehaviour
{
    private bool isDragging;
    Vector3 forcedirection;
    public Vector2 projectedPointOnPen;
    Vector3 clickposition;
    public Vector3 centreofmass;
    private float minforce = 0.5f;
    public Rigidbody2D rb;
    public GameObject penBG;
    public float maxDragMagnitude = 100f;
    public float maxDrag = 1f;
    public float forcemultiplier = 2;
    public bool turnactive = false;
    private bool canStrike;
    public GameObject penBorder;
    private bool timerActive;
    public float timer;
    //public gamemanager gm;
    Vector3 spawnpos;
    Quaternion spawnrot;
    public PenScaler pen3d;
    public Collider2D penCollider;

    // Start is called before the first frame update
    void Start()
    {
        spawnpos = transform.position;
        spawnrot = transform.rotation;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.centerOfMass = centreofmass;
        penBG.SetActive(isDragging);
    }


    public IEnumerator StartTurn()
    {

        isDragging = false; //initially isdragging is false
        penBG.SetActive(false); //before dragging bg should be false
        penBorder.SetActive(true); // Enabling the pen_border to indicate turn active  
        turnactive = true;
        canStrike = true;
        timerActive = true;
        yield return new WaitForSeconds(0.01f);
        while (turnactive)
        {
            if (timerActive)
            {
                GameManager.Instance.StartTurnTimer();


            }

            yield return new WaitForSeconds(0.01f);
        }

        DisablePen();
        GameManager.Instance.SubmitTurn();
    }

    private void Update()
    {
        if (canStrike)
            ReceiveInput();
    }
    float maxScale = 1f;
    void ReceiveInput()
    {
        // Background arrow and circle state turn on when isDragging is true

        // Check for mouse click on pencil
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

            RaycastHit2D raycastHit2D = Physics2D.Raycast(worldMousePos, Vector2.zero);
            if (raycastHit2D.collider != null)
            {
                isDragging = raycastHit2D.collider.gameObject.name == base.gameObject.name;
                if (isDragging)
                {
                    // Store initial click position in world space for proper comparison
                    clickposition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
                    Debug.Log("clickposition is: " + clickposition);
                }
            }
        }

        // When dragging the pencil, check the direction of force to apply
        if (isDragging && Input.GetMouseButton(0))
        {
            // Convert mouse position to world space for consistent comparison
            Vector3 currentMouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

            // Calculate dragging distance (forcedirection)
            forcedirection = clickposition - currentMouseWorldPos;

            // Setting background circle scale according to drag scale
            projectedPointOnPen = Physics2D.ClosestPoint(clickposition, penCollider);

            // Position the background circle
            penBG.transform.position = new Vector3(projectedPointOnPen.x, projectedPointOnPen.y, -0.5f);

            // Calculate the drag distance (magnitude of forcedirection)
            float dragMagnitude = Mathf.Clamp(forcedirection.magnitude, 0, maxDragMagnitude);
            print(dragMagnitude + " is dragMagnitude");

            // Scale the background proportional to drag distance
            float scaleFactor = Mathf.Lerp(1f, maxScale, dragMagnitude / maxDragMagnitude);
            print(scaleFactor + " is scaleFactor");

            if (!float.IsNaN(dragMagnitude) && dragMagnitude > 0 && dragMagnitude <= maxDrag)
            {
               
                    penBG.transform.localScale = Vector3.one * dragMagnitude;

                print(penBG.transform.localScale + " is the scale of penbg");
            }

            // Set rotation of arrow according to the direction of the drag
            float angle = Mathf.Atan2(forcedirection.y, forcedirection.x) * Mathf.Rad2Deg;

            penBG.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        }

        // When mouse is released, apply force
        if (isDragging && Input.GetMouseButtonUp(0))
        {
            if (forcedirection.magnitude > minforce)
            {
                Rigidbody2D rb2d = GetComponent<Rigidbody2D>();

                // Normalize the force direction if it exceeds max magnitude
                Vector3 clampedForceDirection = forcedirection.magnitude < maxDragMagnitude
                    ? forcedirection
                    : forcedirection.normalized * maxDragMagnitude;

                print(clampedForceDirection + " is clampedforceDirection");

                // Applying force
                rb2d.AddForceAtPosition(forcemultiplier * clampedForceDirection, projectedPointOnPen, ForceMode2D.Impulse);

                // Disable pen after force application
                DisablePen();
                StartCoroutine(ICheckPensToStop());
            }

            isDragging = false;
        }
    }




    IEnumerator ICheckPensToStop()
    {
        yield return new WaitUntil(() => GameManager.Instance.AllPensStopped());

        yield return new WaitForSeconds(1);
        turnactive = false;

    }

    public void DisablePen()
    {
        canStrike = false;
        timerActive = false;
        penBorder.SetActive(false); //disabling the pen_border//UI
                                   
    }


    public void Respawn()
    {
        transform.SetPositionAndRotation(spawnpos, spawnrot);
        pen3d.Respawn();
    }
}

public enum PlayerTitle
{
    Player1,
    Player2
}