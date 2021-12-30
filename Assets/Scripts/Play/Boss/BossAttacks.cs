using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    // Flags
    public bool chainComplete;
    public bool isSpinning;

    // Single Fire Prefab and Parent Transform Grouper
    public GameObject singleFirePrefab;
    public Transform singleFireGrouping;

    // Area Fire Prefab and Parent Transform Grouper
    public GameObject areaFirePrefab;
    public Transform areaFireGrouping;

    // MineField Prefab and Parent Transform Grouper
    public GameObject minePrefab;
    public Transform mineGrouping;

    // Tracking Fire Prefab
    public TrackerProjectile trackerProjPrefab;

    // Strings to access types of attack methods in Invoke()
    public string singleFire = "SingleFire";
    public string areaFire = "AreaFire";
    public string mineField = "MineField";
    public string trackingFire = "TrackingFire";

    private Boss boss;

    // Single Fire projectiles available
    private List<GameObject> singleFireProjectiles;

    // Area Fire Projectiles available from pool
    private List<GameObject> areaFireProjectiles;
    private List<GameObject> areaFireProjPool;

    // Mines available
    private List<GameObject> mines;

    // Tracking Fire projectile
    private TrackerProjectile trackerProjectile;

    private void Start()
    {
        boss = GetComponent<Boss>();

        // Attack setups
        SingleFireSetup();
        AreaFireSetup();
        MineFieldSetup();
        TrackingFireSetup();

        chainComplete = false;
        isSpinning = false;
    }
    #region Chaining Attacks Together
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
        // Single Fire
        StartCoroutine(PhaseOne());
        yield return new WaitForSeconds(GameManager.instance.gameData.phaseOneTime);
        // Area Fire
        StartCoroutine(PhaseTwo());
        isSpinning = true;
        yield return new WaitForSeconds(GameManager.instance.gameData.phaseTwoTime);
        isSpinning = false;
        // Mine Field + Tracking Fire
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
        StartRepeatingAttack(boss.bossAttacks.singleFire, boss.bossData.singleFireStartTime, boss.bossData.singleFireRate);
        yield break;
    }

    // Area Fire Phase
    IEnumerator PhaseTwo()
    {
        boss.bossAttacks.StopAttack();
        boss.bossAttacks.StartRepeatingAttack(boss.bossAttacks.areaFire, boss.bossData.areaFireStartTime, boss.bossData.areaFireRate);
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

    #region Start/Stop Attacks

    // Start one of Boss's repeating attacks (Single Fire or Area Fire)
    public void StartRepeatingAttack(string _methodName, float _startTime, float _repeatRate)
    {
        InvokeRepeating(_methodName, _startTime, _repeatRate);
    }

    // Start one of Boss's singular attacks (Mine Field or Tracking) 
    public void StartSingleAttack(string _methodName, float _startTime)
    {
        Invoke(_methodName, _startTime);
    }

    // Stop Boss's current attack
    public void StopAttack()
    {
        CancelInvoke();
    }

    public void ClearMinesEarly()
    {
        for (int i = 0; i < mines.Count; i++)
        {
            mines[i].gameObject.SetActive(false);
        }
    }

    #endregion

    #region Single Fire

    // Set up for attacks that use basic projectiles (Single Fire & Area Fire)
    private void SingleFireSetup()
    {
        // Basic projectile data setup
        BasicProjectile basicProjData = singleFirePrefab.GetComponent<BasicProjectile>();
        basicProjData.speed = boss.bossData.singleFireSpeed;
        basicProjData.destroyAfter = boss.bossData.singleFireDestroyAfter;
        basicProjData.damage = boss.bossData.singleFireDamage;

        // Object pooling setup
        singleFireProjectiles = new List<GameObject>();
        int projectilesToPool = boss.bossData.singleFireProjectiles;
        singleFireProjectiles = ObjectPooler.CreateObjectPool(projectilesToPool, singleFirePrefab);
        singleFireProjectiles = ObjectPooler.AssignParentGrouping(singleFireProjectiles, singleFireGrouping);
    }
    public void SingleFire()
    {
        GameObject projectile = ObjectPooler.GetPooledObject(singleFireProjectiles);

        // If boss has projectiles available to fire
        if (projectile != null)
        {
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            projectile.GetComponent<BasicProjectile>().dir = Vector3.forward;
            projectile.SetActive(true);
            boss.bossSFX.bossAudioSource.PlayOneShot(boss.bossSFX.bossAudio[1]);
        }
    }
    #endregion

    #region Area Fire
    private void AreaFireSetup()
    {
        // Area Fire projectile data setup
        BasicProjectile areaFireData = areaFirePrefab.GetComponent<BasicProjectile>();
        areaFireData.speed = boss.bossData.areaFireSpeed;
        areaFireData.destroyAfter = boss.bossData.areaFireDestroyAfter;
        areaFireData.damage = boss.bossData.areaFireDamage;

        // Object pooling setup
        areaFireProjPool = new List<GameObject>();
        int projectilesToPool = boss.bossData.areaFireProjectiles;
        areaFireProjPool = ObjectPooler.CreateObjectPool(projectilesToPool, areaFirePrefab);
        areaFireProjPool = ObjectPooler.AssignParentGrouping(areaFireProjPool, areaFireGrouping);

        // Set up list of x amount of projectiles to fire in x amount of directions
        areaFireProjectiles = new List<GameObject>();
    }

    // Shoot x projectiles in x directions
    public void AreaFire()
    {
        areaFireProjectiles.Clear();

        for (int i = 0; i < boss.bossData.numOfDirections; i++)
        {
            GameObject areaProjectile = ObjectPooler.GetPooledObject(areaFireProjPool);

            // Keep looking until projectile is not null
            while (areaProjectile == null)
            {
                areaProjectile = ObjectPooler.GetPooledObject(areaFireProjPool);
            }

            // Activate it so it is not picked up again on next iteration
            areaProjectile.gameObject.SetActive(true);
            areaFireProjectiles.Add(areaProjectile);
        }

        float angle = 0;

        // Shoot each projectile in a distinct direction
        foreach (var proj in areaFireProjectiles)
        {
            proj.SetActive(false);
            angle += 360 / boss.bossData.numOfDirections;
            proj.transform.position = transform.position;
            proj.transform.rotation = transform.rotation * Quaternion.Euler(0, angle, 0);
            proj.GetComponent<BasicProjectile>().dir = Vector3.forward;
            proj.SetActive(true);
        }

        boss.bossSFX.bossAudioSource.PlayOneShot(boss.bossSFX.bossAudio[2]);
    }

    #endregion

    #region MineField
    private void MineFieldSetup()
    {
        // Basic mine data setup
        Mine mineData = minePrefab.GetComponent<Mine>();
        mineData.speed = boss.bossData.mineSpeed;
        mineData.destroyAfter = boss.bossData.mineDestroyAfter;
        mineData.damage = boss.bossData.mineDamage;

        // Object pooling setup
        mines = new List<GameObject>();
        int minesToPool = boss.bossData.mineLocations.Count;
        mines = ObjectPooler.CreateObjectPool(minesToPool, minePrefab);
        mines = ObjectPooler.AssignParentGrouping(mines, mineGrouping);

        // Set final locations for each pooled mine
        for (int i = 0; i < mines.Count; i++)
        {
            mines[i].GetComponent<Mine>().finalPosition = boss.bossData.mineLocations[i];
        }
    }

    public void MineField()
    {
        boss.bossSFX.bossAudioSource.PlayOneShot(boss.bossSFX.bossAudio[4]);

        for (int i = 0; i < boss.bossData.mineLocations.Count; i++)
        {
            GameObject pooledMine = ObjectPooler.GetPooledObject(mines);

            // Keep looking until projectile is not null
            while (pooledMine == null)
            {
                pooledMine = ObjectPooler.GetPooledObject(mines);
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
        trackerProjectile.damage = boss.bossData.trackerDamage;
    }

    public void TrackingFire()
    {
        // Reset position and rotation before firing
        trackerProjectile.transform.position = transform.position;
        trackerProjectile.transform.rotation = Quaternion.identity;
        trackerProjectile.gameObject.SetActive(true);
        InvokeRepeating("TrackingFireSFX", 0.5f, 0.5f);
    }

    public void TrackingFireSFX()
    {
        boss.bossSFX.bossAudioSource.PlayOneShot(boss.bossSFX.bossAudio[5]);
    }
    #endregion
}
