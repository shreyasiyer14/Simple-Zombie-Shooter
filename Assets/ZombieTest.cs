using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTest : MonoBehaviour {
	private Animator anim;
	private Transform player;
    public float attackDistance = 1f;
    enum State { WALKING, ATTACK, DEAD };
    State ZombieState;
    bool isrunning = false;
	void Start () {
		anim = GetComponent<Animator>();
		player = GameObject.FindWithTag("Player").transform;
        ZombieState = State.WALKING;
	}
	

	// Update is called once per frame
	void Update () {
        if (ZombieState != State.DEAD) {
            if (Vector3.Distance(player.transform.position, transform.position) <= attackDistance)
                ZombieState = State.ATTACK;
            else
                ZombieState = State.WALKING;

            if (ZombieState == State.WALKING) {
                Vector3 toLookAt = player.transform.position;
                toLookAt = new Vector3(player.position.x, transform.position.y, player.position.z);
                transform.LookAt(toLookAt);
                anim.Play("walk");
            }
            else if (ZombieState == State.ATTACK) {
                StartCoroutine("Attack");
            }
        }
    }

    void Hit () {
        ZombieState = State.DEAD;
        anim.Play("fallingback");
        Destroy(gameObject, 2f);
    }

    IEnumerator Attack () {
        if (isrunning)
            yield break;
        anim.Play("attack");

        isrunning = true;
        yield return new WaitForSeconds(2f);
        player.GetComponent<PlayerShoot>().DoDamage();
        isrunning = false;
    }
}
