using System;
using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Brush_Attack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool hasAttacked = false;
    
    public ParticleSystem damagedParticleEffect;
    private CapsuleCollider2D childCapsuleCollider;
    private SpriteRenderer childSpriteRenderer;

    AudioSource  audioSource;
    public AudioClip clip;
    
    
    void Start()
    {
        childSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        childCapsuleCollider = GetComponentInChildren<CapsuleCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AttackAbility();
    }

    void AttackAbility()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(!hasAttacked)
            {
                childSpriteRenderer.enabled = true;
                childCapsuleCollider.enabled = true;
                Vector3 objectScale = transform.localScale;
                Vector3 targetScale = new Vector3(1.6f, 0.5f, 1);
                float scaleRate = 0.8f;
                audioSource.PlayOneShot(clip, 1f);
                StartCoroutine(PhaseThreeAttack(objectScale,targetScale, scaleRate));
            }
        }
    }

    private IEnumerator PhaseThreeAttack(Vector3 minimumScale, Vector3 maximumScale,float scaleRate)
    {
        //Extend the attack
        hasAttacked = true;
        float originalScaleRate = scaleRate;
        Vector3 originalScale = transform.localScale;
        Vector3 newScale = originalScale;
        while(newScale.x < maximumScale.x)
        {
            newScale = Vector3.Lerp(minimumScale, maximumScale, scaleRate);
            scaleRate += Time.deltaTime;
            transform.localScale = newScale;
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        
        //Shrink back to original
        scaleRate = originalScaleRate;
        while (newScale.x > minimumScale.x)
        {
            newScale = Vector3.Lerp(maximumScale, minimumScale, scaleRate);
            scaleRate +=Time.deltaTime;
            transform.localScale = newScale;
            yield return null;
        }
        //Hide the weapon
        childSpriteRenderer.enabled = false;
        childCapsuleCollider.enabled = false;
        yield return new WaitForSeconds(0.6f);
        hasAttacked = false;
    }

    public void dealDamage(GameObject target, float damage, float knockback)
    {
        meleeEnemies enemyStats = target.GetComponent<meleeEnemies>();
        
        if (!enemyStats || !target) 
            return;
        
        float enemyHealth = enemyStats.getHealth();
        enemyStats.setHealth(enemyHealth - damage);
        damagedParticleEffect.GetComponent<particleScript>().DamagedParticleEffect(target.transform);
        StartCoroutine(knockBackEnemyCoroutine(knockback, target, enemyStats));
    }

    private IEnumerator knockBackEnemyCoroutine(float knockback, GameObject enemy, meleeEnemies enemyStats)
    {
        float timeLimit = 0.4f;
        float elapsedTime = 0f;
        Vector3 direction = (transform.position - enemy.transform.position).normalized;
        Vector3 moveDirection = direction * (knockback * -1);
        enemyStats.getRb().linearVelocity = moveDirection;
        enemyStats.setCanMove(false);
        while (elapsedTime < timeLimit)
        {
            if (!enemyStats.getRb())
                break;  
            enemyStats.getRb().linearVelocity = moveDirection * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        enemyStats.setCanMove(true);
    }
}
