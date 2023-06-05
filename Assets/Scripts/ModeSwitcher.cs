using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode { AttackMode , DefendMode }

public class ModeSwitcher : MonoBehaviour
{
    [SerializeField]
    public GameMode currentGameMode = GameMode.DefendMode;

    public static ModeSwitcher Instance;

    [SerializeField]
    private Player _attackerReference;

    [SerializeField]
    private Camera _attackerCameraReference;

    [SerializeField]
    private Camera _defenderCameraReference;

    [SerializeField]
    private TurretPreview _previewTurretReference;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("There are more than one ModeSwitcher!");
            return;
        }

        SetDefendMode();

        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (currentGameMode == GameMode.AttackMode)
            {
                SetDefendMode();
            }
            else if (currentGameMode == GameMode.DefendMode)
            {
                SetAttackMode();
            }
        }
    }

    private void SetAttackMode()
    {
        Debug.Log("Switched Game Mode to Attack Mode");

        // Set values and stuff to what it needs to be for the attacker to play.
        // Sets camera and player to standard posistions at the start of the map.
        // Deactivates defender camera and activates attacker camera and vessel.

        currentGameMode = GameMode.AttackMode;

        _attackerCameraReference.gameObject.SetActive(true);
        _attackerCameraReference.transform.position = new Vector3(0, 0, -10);

        _attackerReference.gameObject.SetActive(true);
        _attackerReference.transform.localPosition = new Vector3(-5, 0, 10);

        _defenderCameraReference.gameObject.SetActive(false);

        _previewTurretReference.gameObject.SetActive(false);
    }

    private void SetDefendMode()
    {
        Debug.Log("Switched Game Mode to Defend Mode");

        // Set values to what it needs to be for the defender to play.
        // Hides the attacker vessel and camera, activates defender camera.

        currentGameMode = GameMode.DefendMode;

        _attackerReference.gameObject.SetActive(false);

        _attackerCameraReference.gameObject.SetActive(false);

        _defenderCameraReference.gameObject.SetActive(true);
        _defenderCameraReference.transform.position = new Vector3(0, 0, -10);

        _previewTurretReference.gameObject.SetActive(true);
    }

    public bool IsAttackMode()
    {
        return currentGameMode == GameMode.AttackMode;
    }

    public bool IsDefendMode()
    {
        return currentGameMode == GameMode.DefendMode;
    }
}
