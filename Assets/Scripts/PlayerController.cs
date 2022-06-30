using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Text playerScoreText;

    public float playerSpeed = 5.0f;
    public float gravityValue = -9.81f;

    public GameObject money2PreFab;
    public GameObject bag;
    public GameObject moneyPosition;

    private Player playerInput;

    private CharacterController controller;

    private Vector3 playerVelocity;

    private bool groundedPlayer;

    public int playerScore = 0;

    private void Awake()
    {
        instance = this;

        playerInput = new Player();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Update()
    {
        //skor yazma
        playerScoreText.text = playerScore.ToString();
    }

    void FixedUpdate()
    {
        //Hareket mekaniði
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x,0f,movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    
    //paralarý sýrtýmýza koyuyoruz
    public void MoneytoBag()
    {
        GameObject mon = Instantiate(money2PreFab, moneyPosition.transform);
        mon.transform.SetParent(bag.transform);
    }

    //binanýn parayý almasý
    public void MoneyFromBuilding(int money)
    {
        for (int i = 0; i < money; i++)
        {
            MoneytoBag();
        }
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("MenuLevel");
    }
}