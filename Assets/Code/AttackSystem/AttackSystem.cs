using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _bulletsContainer;
    private PoolSystem<Bullet> _pool;
    
    void Start()
    {
        var bulletPrefab = Resources.Load("Prefabs/BulletPrefab") as GameObject;
        _pool = new PoolSystem<Bullet>(bulletPrefab.GetComponent<Bullet>(), 5, _bulletsContainer);
    }

    public void Attack(Vector3 aim)
    {
        var bullet = _pool.GetElement();
        bullet.Init(aim, _spawnPoint.position);
    }
}