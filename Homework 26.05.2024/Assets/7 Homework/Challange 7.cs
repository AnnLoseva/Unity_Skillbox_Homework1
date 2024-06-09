using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Challange7 : MonoBehaviour
{
    #region Variables

    [Header("Clock Images")]
    [SerializeField] private Image wheatImage;
    [SerializeField] private Image workerImage;
    [SerializeField] private Image foodImage;
    [SerializeField] private Image warriorImage;
    [SerializeField] private Image enemyImage;

    [Header("Text")]
    [SerializeField] private Text[] wheatText;
    [SerializeField] private Text eatingText;
    [SerializeField] private Text workerText;
    [SerializeField] private Text[] warriorText;
    [SerializeField] private Text[] enemyText;
    [SerializeField] private Text[] attackcounterText;

    [Header("States")]
    [SerializeField] private GameObject playWindow;
    [SerializeField] private GameObject menuWindow;
    [SerializeField] private GameObject victoryWindow;
    [SerializeField] private GameObject defeatWindow;
    [SerializeField] private GameObject enemyAttack;

    [Header("Sounds")]
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource effects;
    [SerializeField] private AudioSource speach;
    [SerializeField] private AudioClip enemyAttackSound;
    [SerializeField] private AudioClip defeatSound;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip eatingSound;
    [SerializeField] private AudioClip victorySound;
    [SerializeField] private AudioClip[] warriorSound;
    [SerializeField] private AudioClip[] workerSound;

    

    [Header("Timers")]
    [SerializeField] private float maxWheatTime = 3;
    [SerializeField] private float maxWorkerTime = 3;
    [SerializeField] private float maxWarriorTime = 3;
    [SerializeField] private float maxEnemyTime = 30;
    [SerializeField] private float maxFoodTime =10;

    [Header("Other")]
    [SerializeField] private int victoryWheatNumber = 100;
    [SerializeField] private int enemyModificator = 3;
    [SerializeField] private int wheatModificator = 3;
    [SerializeField] private int workerCost = 5;
    [SerializeField] private int warriorCost = 10;
    [SerializeField] private int foodModificator = 2;
    [SerializeField] private PauseAndSpeed gameSpeed;

    private int wheatNumber = 0;
    private int workerNumber = 1;
    private int warriorNumber = 0;
    private int enemyNumber = 1;
    private int attackCounter = 1;

    private float wheatTimer;
    private float workerTimer;
    private float warriorTimer;
    private float enemyTimer;
    private float foodTimer;
    private float attackTimer;
    private int buyMod;

    private bool gettingWorker;
    private bool gettingWarrior;
    private bool isEnemyAttacking;

    private float blinkTime;
    private bool isBlinking;
    private Random rnd = new Random();

    #endregion Variables

    #region StartAndUpdate

    void Start()
    {
        Play();
    }

    void Update()
    {
        if (!isEnemyAttacking)
        {
            Wheat();
            Eating();
            EnemyAttack();
            FillTimers();
        }
        else if(isEnemyAttacking)
        {
            Attack();
        }

        if (gettingWorker) 
        { 
            GetWorker(); 
        };

        if(gettingWarrior) 
        {
            GetWarrior();
        }

        if(isBlinking)
        {
            Blink();
        }
    }

    #endregion StartAndUpdate

    #region Actions

    private void Wheat()
    {
        wheatTimer += Time.deltaTime;

        if(wheatTimer >= maxWheatTime)
        {
            wheatNumber += wheatModificator * workerNumber;
            wheatTimer = 0;
            for (int i = 0; i < wheatText.Length; i++)
            {
                wheatText[i].text = wheatNumber.ToString();
            }
        }

        if(wheatNumber >= victoryWheatNumber)
        {
            Victory();
            wheatNumber = 0;
        }
    }

    private void Eating()
    {
        foodTimer += Time.deltaTime;

        if (foodTimer >= maxFoodTime)
        {
            foodTimer = 0;

            wheatNumber -= ((warriorNumber + workerNumber) * foodModificator);

            for (int i = 0; i < wheatText.Length; i++)
            {
                wheatText[i].text = wheatNumber.ToString();
            }

            effects.clip = eatingSound;
            effects.Play();
        }

        eatingText.text = ((warriorNumber + workerNumber) * foodModificator).ToString();

    }

    private void EnemyAttack()
    {
        enemyTimer += Time.deltaTime;

        for (int i = 0; i < warriorText.Length; i++)
        {
            enemyText[i].text = enemyNumber.ToString();
            warriorText[i].text = warriorNumber.ToString();
        }

        if (enemyTimer >= maxEnemyTime) 
        {
            enemyTimer = 0;

            enemyAttack.SetActive(true);
            isEnemyAttacking = true;
            isBlinking = true;
            effects.clip = enemyAttackSound;
            effects.Play();


        }
    }

    private void FillTimers()
    {

        // Wheat Timer
        wheatImage.fillAmount = wheatTimer / maxWheatTime;

        // Food Timer
        foodImage.fillAmount = foodTimer / maxFoodTime;

        // EnemyTimer
        enemyImage.fillAmount = enemyTimer / maxEnemyTime;

        // Warrior Timer
        if (warriorTimer <= maxWarriorTime && warriorTimer != 0)
        {
            warriorImage.fillAmount = warriorTimer / maxWarriorTime;
        }
        else if (warriorTimer == 0)
        {
            warriorImage.fillAmount = 1;
        }
        // Worker Timer
        if (workerTimer <= maxWorkerTime && workerTimer != 0)
        {
            workerImage.fillAmount = workerTimer / maxWorkerTime;
        }
        else if (workerTimer == 0)
        {
            workerImage.fillAmount = 1;
        }

    }

    private void Blink()
    {
        blinkTime += Time.deltaTime;
        if (blinkTime >= 0.3f)
        {
            workerImage.color = Color.white;
            warriorImage.color = Color.white;
            isBlinking = false;
        }
    }

    #endregion Actions

    #region Buttons

    public void WorkerButton()
    {
        effects.clip = clickSound;
        effects.Play();
        
        if (wheatNumber >= workerCost && !gettingWorker)
        {

            wheatNumber -= workerCost;
            gettingWorker = true;

            for (int i = 0; i < wheatText.Length; i++)
            {
                wheatText[i].text = wheatNumber.ToString();
            }

        }
        else
        {
            blinkTime = 0;
            workerImage.color = Color.red;
            isBlinking = true;
        }
    }

    public void WarriorButton() 
    {
        effects.clip = clickSound;
        effects.Play();

        if (wheatNumber >= (warriorCost * buyMod) && !gettingWarrior)
        {

            wheatNumber -= (warriorCost * buyMod);
            gettingWarrior = true;

            for (int i = 0; i < wheatText.Length; i++)
            {
                wheatText[i].text = wheatNumber.ToString();
            }

        }
        else
        {
            blinkTime = 0;
            warriorImage.color = Color.red;
            isBlinking = true;
        }
    }

    public void BuyModificator1()
    {
        buyMod = 1;
    }

    public void BuyModificator3() 
    {
        buyMod = 3;
    }

    public void BuyModificator5()
    {
        buyMod = 5;
    }

    #endregion Buttons

    #region Buy

    private void GetWorker()
    {
        workerTimer += Time.deltaTime;

        if (workerTimer >= maxWorkerTime)
        {
            workerNumber += 1;
            workerTimer = 0;
            workerText.text = workerNumber.ToString();
            gettingWorker = false;

            
            speach.clip = workerSound[rnd.Next(0, 4)];
            speach.Play();
        }
    }

    private void GetWarrior()
    {
        warriorTimer += Time.deltaTime;

        if (warriorTimer >= maxWorkerTime)
        {
            warriorNumber += buyMod;
            warriorTimer = 0;

            for (int i = 0; i < warriorText.Length; i++)
            {
                enemyText[i].text = enemyNumber.ToString();
            }
            gettingWarrior = false;
            speach.clip = warriorSound[rnd.Next(0,4)];
            speach.Play();
        }
    }

    #endregion Buy

    #region States

    private void Attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= 3)
        {
            isEnemyAttacking = false;
            enemyAttack.SetActive(false);
            attackTimer = 0;
            effects.Stop();

            warriorNumber -= enemyNumber;
            enemyNumber += enemyModificator;
            attackCounter++;

            for (int i = 0; i < attackcounterText.Length; i++)
            {
                attackcounterText[i].text = ("x" +  attackCounter.ToString());
            }

            if (warriorNumber < 0)
            {
                Defeat();
            }
        }
    }

    public void Play()
    {
        playWindow.SetActive(true);
        victoryWindow.SetActive(false);
        defeatWindow.SetActive(false);

        workerNumber = 1;
        warriorNumber = 0;
        enemyNumber = 1;
        wheatNumber = 0;
        buyMod = 1;
        attackCounter = 1;

        enemyTimer = 0;
        foodTimer = 0;
        wheatTimer = 0;


        for (int i = 0; i < wheatText.Length; i++)
        {
            wheatText[i].text = wheatNumber.ToString();
        }

        for (int i = 0; i < warriorText.Length; i++)
        {
            enemyText[i].text = enemyNumber.ToString();
            warriorText[i].text = warriorNumber.ToString();
        }

        attackCounter = 1;

        for (int i = 0; i < warriorText.Length; i++)
        {
            attackcounterText[i].text = ("x" + attackCounter.ToString());
        }

        workerText.text = workerNumber.ToString();
    }

    public void Menu()
    {
        menuWindow.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue ()
    {
        menuWindow.SetActive(false);
        Time.timeScale = gameSpeed.speed;

    }

    private void Victory()
    {
        victoryWindow.SetActive(true);
        playWindow.SetActive(false);
        defeatWindow.SetActive(false);
        effects.clip = victorySound;
        effects.Play();
    }

    private void Defeat()
    {
        attackCounter--;

        for (int i = 0; i < attackcounterText.Length; i++)
        {
            attackcounterText[i].text = ("x" + attackCounter.ToString());
        }

        defeatWindow.SetActive(true);
        victoryWindow.SetActive(false);
        playWindow.SetActive(false);
        effects.clip = defeatSound;
        effects.Play();
    }

    #endregion States


}
