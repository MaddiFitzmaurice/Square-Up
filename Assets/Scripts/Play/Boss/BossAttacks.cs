using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    // Flags
    public bool chainComplete;
    public bool isSpinning;

    // Single and Area Fire Prefab and Parent Transform Grouper
    public GameObject basicProjectile;
    public Transform basicProjectileGrouping;

    // MineField Prefab and Parent Transform Grouper
    public GameObject mine;
    public Transform mineGrouping;

    // Tracking Fire Prefab
    public TrackerProjectile trackerProjPrefab;

    // String name for types of attacks
    public string singleFire = "SingleFire";
    public string areaFire = "AreaFire";
    public string mineField = "MineField";
    public string trackingFire = "TrackingFire";

    private int projectilesToPool;
    private int minesToPool;

    private Boss boss;

    // Single Fire projectiles available
    private List<GameObject> projectiles;

    // Mines available
    private List<GameObject> mines;

    // Area Fire projectiles available
    private List<GameObject> areaProjectiles;

    // Tracking Projectile
    private TrackerProjectile trackerProjectile;

    private void Start()
    {
        boss = GetComponent<Boss>();

        // Attack setups
        ProjectilePoolingSetup();
        MineFieldPoolingSetup();
        TrackingFireSetup();
        areaProjectiles = new List<GameObject>();

        chainComplete = false;
        isSpinning = false;
    }
    #region Chain Attacks
    // Chain Boss's attack phases with timers
    public void BeginAttackPhases()
    {
        chainComplete = false;
        isSpinning = false;
        StartCoroutine(AttackPhases());
    }

    // Coroutine chain for Boss's attacks
    IEnumerator AttackPhases()
    {
        StartCoroutine(PhaseOne());
        yield return new WaitForSeconds(GameManager.instance.gameData.phaseOneTime);
        StartCoroutine(PhaseTwo());
        isSpinning = true;
        yield return new WaitForSeconds(GameManager.instance.gameData.phaseTwoTime);
        isSpinning = false;
        StartCoroutine(PhaseThree());
        yield return new WaitForSeconds(GameManager.instance.gameData.phaseThreeTime);
        StopAttack();
        chainComplete = true;
        yield break;
    }

    // Single Fire Phase
    IEnumerator PhaseOne()
    {
        StopAttack();
        StartAttack(boss.bossAttacks.singleFire, boss.bossData.bpStartTime, boss.bossData.bpFireRate);
        yield break;
    }

    // Area Fire Phase
    IEnumerator PhaseTwo()
    {
        boss.bossAttacks.StopAttack();
        boss.bossAttacks.StartAttack(boss.bossAttacks.areaFire, boss.bossData.bpStartTime, boss.bossData.areaFireRate);
        yield break;
    }

    IEnumerator PhaseThree()
    {
        boss.bossAttacks.StopAttack();
        boss.bossAttacks.StartSingleAttack(boss.bossAttacks.mineField, boss.bossData.mineStartTime);
        boss.bossAttacks.StartSingleAttack(boss.bossAttacks.trackingFire, boss.bossData.trackerStartTime);
        yield break;
    }

    #endregion

    // Start Boss's specified repeating attack (Single Fire, Area Fire)
    public void StartAttack(string _methodName, float _startTime, float _repeatRate)
    {
        InvokeRepeating(_methodName, _startTime, _repeatRate);
    }

    // Start Boss's singular attack (Mine Field, Tracking) 
    public void StartSingleAttack(string _methodName, float _startTime)
    {
        Invoke(_methodName, _startTime);
    }

    // Stop Boss's current attack
    public void StopAttack()
    {
        CancelInvoke();
    }

    #region Single Fire

    public void SingleFire()
    {
        GameObject projectile = ObjectPooler.GetPooledObject(projectiles);

        // If boss has projectiles available to fire
        if (projectile != null)
        {
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            projectile.GetComponent<BasicProjectile>().dir = Vector3.forward;
            projectile.SetActive(true);
        }
    }

    // Set up for attacks that use basic projectiles (Single Fire & Area Fire)
    private void ProjectilePoolingSetup()
    {
        // Basic projectile data setup
        BasicProjectile basicProjData = basicProjectile.GetComponent<BasicProjectile>();
        basicProjData.speed = boss.bossData.bpSpeed;
        basicProjData.destroyAfter = boss.bossData.bpDestroyAfter;

        // Object pooling setup
        projectiles = new List<GameObject>();
        projectilesToPool = boss.bossData.basicProjectiles;
        projectiles = ObjectPooler.CreateObjectPool(projectilesToPool, basicProjectile);
        projectiles = ObjectPooler.AssignParentGrouping(projectiles, basicProjectileGrouping);
    }

    #endregion

    #region Area Fire

    // Shoot 8 projectiles in 8 directions
    public void AreaFire()
    {
        areaProjectiles.Clear();

        for (int i = 0; i < 8; i++)
        {
            GameObject areaProjectile = ObjectPooler.GetPooledObject(projectiles);

            // Keep looking until projectile is not null
            while (areaProjectile == null)
            {
                areaProjectile = ObjectPooler.GetPooledObject(projectiles);
            }

            // Activate it so it is not picked up again on next iteration
            areaProjectile.gameObject.SetActive(true);
            areaProjectiles.Add(areaProjectile);
        }

        float angle = 0;

        // Shoot each projectile in a distinct direction
        foreach (var proj in areaProjectiles)
        {
            proj.SetActive(false);
            angle += 45;
            proj.transform.position = transform.position;
            proj.transform.rotation = transform.rotation * Quaternion.Euler(0, angle, 0);
            proj.GetComponent<BasicProjectile>().dir = Vector3.forward;
            proj.SetActive(true);
        }   
    }

    #endregion

    #region MineField
    private void MineFieldPoolingSetup()
    {
        // Basic mine data setup
        Mine mineData = mine.GetComponent<Mine>();
        mineData.speed = boss.bossData.mineSpeed;
        mineData.destroyAfter = boss.bossData.mineDestroyAfter;

        // Object pooling setup
        mines = new List<GameObject>();
        minesToPool = boss.bossData.mineLocations.Count;
        mines = ObjectPooler.CreateObjectPool(minesToPool, mine);
        mines = ObjectPooler.AssignParentGrouping(mines, mineGrouping);

        // Set final locations for each pooled mine
        for (int i = 0; i < mines.Count; i++)
        {
            mines[i].GetComponent<Mine>().finalPosition = boss.bossData.mineLocations[i];
        }
    }

    public void MineField()
    {
        for (int i = 0; i < minesToPool; i++)
        {
            GameObject pooledMine = ObjectPooler.GetPooledObject(mines);

            // Keep looking until projectile is not null
            while (pooledMine == null)
            {
                pooledMine = ObjectPooler.GetPooledObject(projectiles);
            }

            // Activate it so it is not picked up again on next for() iteration
            pooledMine.transform.position = transform.position;
            pooledMine.gameObject.SetActive(true);
        }
    }

    #endregion

    #region Tracking Fire
    private void TrackingFireSetup()
    {
        // Create tracker projectile
        trackerProjectile = Instantiate(trackerProjPrefab, transform.position, Quaternion.identity);
        trackerProjectile.gameObject.SetActive(false);
        trackerProjectile.player = boss.player;
        trackerProjectile.speed = boss.bossData.trackerSpeed;
        trackerProjectile.destroyAfter = boss.bossData.trackerDestroyAfter;
    }

    public void TrackingFire()
    {
        // Reset position and rotation before firing
        trackerProjectile.transform.position = transform.position;
        trackerProjectile.transform.rotation = Quaternion.identity;
        trackerProjectile.gameObject.SetActive(true);
    }
    #endregion
}
