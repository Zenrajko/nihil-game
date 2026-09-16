using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class Blaster : MonoBehaviour
{
	[SerializeField] private Camera aimCamera;
	[SerializeField] private ParticleSystem muzzleFlash;
	[Range(10f, 200f)] public float range = 100f;

	public AudioClip shotSound;

	private AudioSource _audio;

	private void Awake()
	{
		_audio = GetComponent<AudioSource>();
		if (aimCamera == null) aimCamera = Camera.main;
	}

	private void Update()
	{
		if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
		{
			Fire();
		}
	}

	private void Fire()
	{
		muzzleFlash.Play();
		_audio.PlayOneShot(shotSound);

		if (Physics.Raycast(aimCamera.transform.position, aimCamera.transform.forward, out RaycastHit hit, range))
		{
			Debug.Log($"Hit {hit.collider.name}", hit.collider.gameObject);
		}
	}
}
