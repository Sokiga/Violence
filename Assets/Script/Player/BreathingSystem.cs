using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathingSystem : MonoBehaviour
{
    public float breathingValue;
    public float moveMaxValue = 40;
    public TerroritySystem terroritySystem;
    private PlayerController playerController;
    private Dictionary<int, float> consumeBreath = new Dictionary<int, float>();
    private Dictionary<int, float> restoreBreath = new Dictionary<int, float>();
    private float maxValue = 100;
    private bool isHolding = false;
    [SerializeField]
    private Image breImgae;
    private void Start()
    {
        terroritySystem = GetComponent<TerroritySystem>();
        breathingValue = maxValue;
        playerController = GetComponent<PlayerController>();
        consumeBreath[(int)MoveType.kRun] = 12.5f;
        consumeBreath[(int)MoveType.kTrot] = 16.5f;
        consumeBreath[(int)MoveType.kCreep] = 10f;
        consumeBreath[(int)MoveType.kStop] = 3.0f;
        restoreBreath[(int)MoveType.kTrot] = 15f;
        restoreBreath[(int)MoveType.kCreep] = 18f;
        restoreBreath[(int)MoveType.kStop] = 20f;
    }
    private void Update()
    {
        CalcalateBreathing();
    }
    private void CalcalateBreathing()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            isHolding = true;
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            isHolding = false;
        }
        if (isHolding)
        {
            breathingValue -= consumeBreath[(int)playerController.moveType] * Time.deltaTime;
            breathingValue = Mathf.Max(0, breathingValue);
            if (breathingValue < 0.05f) breathingValue = 0;
        }
        if (!isHolding || playerController.isStopMove)
        {
            breathingValue += restoreBreath[(int)playerController.moveType] * Time.deltaTime;
            breathingValue = Mathf.Min(maxValue, breathingValue);
        }
        if (breathingValue > moveMaxValue &&
            terroritySystem.terValue > terroritySystem.maxTerValue * 0.9f && 
            !playerController.isOpenBag &&
            !playerController.isOpenPlane)
        {
            playerController.isStopMove = false;
        }
        if (breathingValue < 0.05f)
        {
            playerController.isStopMove = true;
            playerController.moveType = MoveType.kStop;
            isHolding = false;
        }
        breImgae.fillAmount = breathingValue * 0.5f;
    }
}
