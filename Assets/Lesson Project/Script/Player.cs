using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LernProject
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject shieldPrefab;
        [SerializeField] private GameObject MinePrefab;
        [SerializeField] private GameObject BoxPrefab;

        [SerializeField] private Transform SpawnPosition;
        [SerializeField] private Transform SpawnPositionM;

        [SerializeField] private float speed = 2f;
        [SerializeField] private float speedRotate = 20f;
        [SerializeField] private float jumpUp = 100f;

        private bool _isSpawnShield;
        private bool _isSpawnMine;
        private bool _isSprint;

        private Vector3 _direction;

        private Rigidbody rb;

        

        private int level = 1;



        private void Awake()
        {

        }

        void Start()
        {
            this.rb = this.GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(1))
                _isSpawnShield = true;

            if (Input.GetMouseButtonDown(0))
                _isSpawnMine = true;

            if (Input.GetKeyDown(KeyCode.Space))
                rb.AddForce(Vector3.up * jumpUp, ForceMode.Impulse);
            if (Input.GetKeyUp(KeyCode.Space))
                rb.AddForce(Vector3.up * -jumpUp, ForceMode.Impulse);

            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
            _isSprint = Input.GetButton("Sprint");
        }

        private void FixedUpdate()
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * speedRotate * Time.fixedDeltaTime, 0));

            if (_isSpawnShield)
            {
                _isSpawnShield = false;
                SpawnShield();
            }

            if (_isSpawnMine)
            {
                _isSpawnMine = false;
                SpawnMine();
            }

            Move(Time.fixedDeltaTime);
        }
        private void SpawnShield()
        {
            var shieldObj = Instantiate(shieldPrefab, SpawnPosition.position, SpawnPosition.rotation);
            var shield = shieldObj.GetComponent<Shield>();
            shield.Init(10 * level);

            shield.transform.SetParent(SpawnPosition);
        }
        
        private void SpawnMine()
        {
            var MineObj = Instantiate(MinePrefab, SpawnPositionM.position, SpawnPositionM.rotation);
            var mine = MineObj.GetComponent<Mine>();
            mine.Init(4 * level);
        }

        /*private void SpawnBox()
        {
            var boxObj = Instantiate(shieldPrefab, SpawnPosition.position, SpawnPosition.rotation);
            var shield = boxObj.GetComponent<Box>();
            

            box.transform.SetParent(SpawnPosition);
        }*/

        private void Move(float delta)
        {
            var fixedDirection = transform.TransformDirection(_direction.normalized);
            transform.position += fixedDirection * (_isSprint ? speed * 2: speed) * delta;
        }
    }
}