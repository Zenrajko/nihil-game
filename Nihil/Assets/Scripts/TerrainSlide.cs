using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TerrainSlide : MonoBehaviour
{
    [Tooltip("Slopes steeper than this (degrees) slide downhill instead of wall-riding")]
    public float SteepAngle = 55f;
    [Tooltip("How fast the player slides down steep faces")]
    public float SlideSpeed = 10f;
    [Tooltip("How far the steep-check rays probe ahead")]
    public float RayDistance = 1.5f;
    [Tooltip("How rapidly the slide velocity reaches its full downhill speed")]
    public float SlideAcceleration = 12f;
    [Tooltip("How quickly the slide bleeds off after leaving the steep face")]
    public float SlideFriction = 5f;

    public bool IsSteep { get; private set; }

    private CharacterController _controller;
    private Vector3 _slideVelocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 origin = transform.position + Vector3.up * 0.1f;
        Vector3 forwardSlope = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;

        Vector3 downhill = Vector3.zero;
        IsSteep = false;
        CheckSteep(origin, Vector3.down);
        CheckSteep(origin, Quaternion.Euler(0f, -15f, 0f) * forwardSlope + Vector3.down);
        CheckSteep(origin, Quaternion.Euler(0f, 15f, 0f) * forwardSlope + Vector3.down);

        if (IsSteep)
        {
            if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit, RayDistance))
            {
                downhill = Vector3.ProjectOnPlane(Vector3.down, hit.normal).normalized * SlideSpeed;
            }
            _slideVelocity = Vector3.Lerp(_slideVelocity, downhill, SlideAcceleration * Time.deltaTime);
        }
        else
        {
            _slideVelocity = _slideVelocity.magnitude > 0.001f
                ? Vector3.MoveTowards(_slideVelocity, Vector3.zero, SlideFriction * Time.deltaTime)
                : Vector3.zero;
        }

        if (_controller.isGrounded && _slideVelocity.sqrMagnitude > 0.0001f)
        {
            _controller.Move(_slideVelocity * Time.deltaTime);
        }
    }

    private void CheckSteep(Vector3 origin, Vector3 dir)
    {
        if (Physics.Raycast(origin, dir, out RaycastHit hit, RayDistance)
            && Vector3.Angle(hit.normal, Vector3.up) > SteepAngle)
        {
            IsSteep = true;
        }
    }
}