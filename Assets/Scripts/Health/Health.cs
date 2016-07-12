using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int _maxHP = 10;
    public int _currentHP;
    public bool _bDead = false;
    public bool _bHit = false;
    public float _hitCD = 1f;

	// Use this for initialization
	void Start ()
    {
        InitHealth();
	}
	
    private void InitHealth()
    {
        _currentHP = _maxHP;
        _bDead = false;
        _bHit = false;
    }

    public void TakeDamage(int pAmount)
    {
        if (!_bDead && !_bHit)
        {
            _currentHP -= pAmount;
            if (_currentHP < 0)
            {
                _currentHP = 0;
                _bDead = true;
            }
            _bHit = true;
            StartCoroutine(RestoreHit());
        }
    }

    public void Heal(int pAmount)
    {
        if (!_bDead)
        {
            _currentHP += pAmount;
            if (_currentHP > _maxHP)
            {
                _currentHP = _maxHP;
            }
        }
    }

    private IEnumerator RestoreHit()
    {
        yield return new WaitForSeconds(_hitCD);
        _bHit = false;
    }
}
