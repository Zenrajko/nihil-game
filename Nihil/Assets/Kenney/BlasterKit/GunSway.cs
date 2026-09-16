using UnityEngine;
using UnityEngine.InputSystem;

public class GunSway : MonoBehaviour
{
    [Header("Walk Bob")]
    [SerializeField] private float bobFrequency = 6f;   // bobbing speed
    [SerializeField] private float bobHeight = 0.006f;  // vertical amplitude (m)
    [SerializeField] private float bobSide = 0.004f;    // horizontal amplitude (m)
    [SerializeField] private float bobResponse = 5f;    // how fast bob ramps with speed

    [Header("Look Sway")]
    [SerializeField] private float swayAmount = 0.05f;  // degrees per pixel of mouse travel
    [SerializeField] private float swayResponse = 8f;   // how fast the gun settles
    [SerializeField] private float maxSway = 3f;        // clamp in degrees

    private CharacterController _controller;
    private Vector3 _restPos;
    private Quaternion _restRot;
    private Vector3 _swayOffset;
    private float _speedFactor;

    private void Awake()
    {
        _controller = FindAnyObjectByType<CharacterController>();
        if (_controller == null) { enabled = false; return; }

        // Cache your hand-placed pose as the "at rest" pose.
        _restPos = transform.localPosition;
        _restRot = transform.localRotation;
    }

    private void LateUpdate()
    {
        WalkBob();
        LookSway();
    }

    private void WalkBob()
    {
        // Horizontal speed drives bob intensity; grounded-only, so no bob mid-air.
        Vector3 flatVel = new Vector3(_controller.velocity.x, 0f, _controller.velocity.z);
        float target = _controller.isGrounded ? Mathf.Clamp01(flatVel.magnitude / 6f) : 0f;
        _speedFactor = Mathf.Lerp(_speedFactor, target, Time.deltaTime * bobResponse);

        float t = Time.time;
        Vector3 bobPos = Vector3.zero;
        bobPos.x = Mathf.Sin(t * bobFrequency) * bobSide;
        bobPos.y = Mathf.Sin(t * bobFrequency * 2f) * bobHeight;
        transform.localPosition = _restPos + bobPos * _speedFactor;
    }

    private void LookSway()
    {
        // Gun leans against the look: no camera sampling, no execution-order sensitivity.
        if (Mouse.current == null) return;

        Vector2 mouse = Mouse.current.delta.ReadValue();
        Vector3 target = new Vector3(mouse.y, -mouse.x, 0f) * swayAmount;
        target = Vector3.ClampMagnitude(target, maxSway);

        _swayOffset = Vector3.Lerp(_swayOffset, target, Time.deltaTime * swayResponse);
        transform.localRotation = _restRot * Quaternion.Euler(_swayOffset);
    }
}