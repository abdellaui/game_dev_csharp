using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity
{
    public const int maxLife = 10;
    private int life = 10;

    public abstract void Hit(Entity other);
    public abstract int DamageGeneration();

    public void AddToLife(int extralife)
    {
        this.life = Mathf.Min(this.life + extralife, maxLife);
    }

    public bool IsDead()
    {
        return this.life <= 0;
    }

    public void PrintLife()
    {
        Debug.Log($"Life: {life}");
    }

}

// #####################

public class Player : Entity
{
    bool defending = true;



    public override int DamageGeneration()
    {
        return Random.Range(1, 2);
    }

    public override void Hit(Entity other)
    {
        int damage = DamageGeneration();
        Enemy victim = (Enemy)other;
        victim.AddToLife(-damage);
        Debug.Log($"<color=yellow>Player hits {damage} damage!</color>");
    }
    public void Mage()
    {
        AddToLife(2);
        Debug.Log($"<color=green>Player heals!</color>");
    }
    public void Defend()
    {
        this.defending = true;
        Debug.Log($"<color=green>Player defends!</color>");
    }

    public void BrakeDefend()
    {
        this.defending = false;
    }


    public bool IsDefending()
    {
        return defending;
    }

}

// #####################


public class Enemy : Entity
{
    bool charged = false;


    public override int DamageGeneration()
    {
        return Random.Range(2, 4);
    }

    public override void Hit(Entity other)
    {
        Player victim = (Player)other;
        int damage = (!charged) ? DamageGeneration() : 10;
        if (victim.IsDefending())
        {
            this.AddToLife(-damage);
            victim.BrakeDefend();
            Debug.Log($"<color=green>Player defends {damage} damage!</color>");
        }
        else
        {
            victim.AddToLife(-damage);
            Debug.Log($"<color=red>Enemy hits {damage} damage!</color>");
        }
    }

    public void Charge()
    {
        charged = true;
    }
}

// #####################


public class BossEnemy : Entity
{

    int lastDamage = 0;

    public override int DamageGeneration()
    {
        return Random.Range(2, 4);
    }

    public override void Hit(Entity other)
    {
        Player victim = (Player)other;
        int damage = DamageGeneration();

        if (lastDamage == damage)
        {
            damage *= Random.Range(2, 3);
        }

        if (victim.IsDefending())
        {
            this.AddToLife(-damage);
            victim.BrakeDefend();
            Debug.Log($"<color=green>Player defends {damage} damage!</color>");
        }
        else
        {
            victim.AddToLife(-damage);
            Debug.Log($"<color=red>Boss hits {damage} damage!</color>");
        }
    }

}

// #####################


public class Aufgabe_7 : MonoBehaviour
{
    bool isPlayersTurn = false;
    Player m_player;
    Enemy m_enemy;
    BossEnemy m_boss;

    void PrintGameStat()
    {
        Debug.Log("********************************************");
        Debug.Log("Führe eine Aktion aus:");
        Debug.Log("<color=yellow>Angriff (1), Magie (2) und Verteidigung (3).</color>");


        Debug.Log("<color=green>--------   Player   --------</color>");
        m_player.PrintLife();

        Debug.Log("<color=green>--------   Enemy   --------</color>");
        m_enemy.PrintLife();



        if (IsGameFinished())
        {

            Debug.Log("<color=red>--------   FINISHED   --------</color>");
        }

    }

    bool IsGameFinished()
    {
        return m_player.IsDead() || m_enemy.IsDead() || m_boss.IsDead();
    }

    void RandomAiBasic()
    {
        int rand = Random.Range(0, 1);
        if (rand == 0)
        {
            m_enemy.Hit(m_player);
        }
        else
        {
            m_enemy.Charge();
        }

        isPlayersTurn = true;
        PrintGameStat();
    }

    void BossPlayer()
    {

        m_boss.Hit(m_player);
        isPlayersTurn = true;
        PrintGameStat();

    }

    void ChangePlayersTurn()
    {
        isPlayersTurn = false;
        PrintGameStat();

    }

    void UserInputProccess()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_player.Hit(m_enemy);
            ChangePlayersTurn();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_player.Mage();
            ChangePlayersTurn();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_player.Defend();
            ChangePlayersTurn();
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        m_player = new Player();
        m_enemy = new Enemy();
        m_boss = new BossEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGameFinished())
        {
            if (!isPlayersTurn)
            {

                BossPlayer();

            }
            else
            {

                UserInputProccess();

            }
        }


    }
}
