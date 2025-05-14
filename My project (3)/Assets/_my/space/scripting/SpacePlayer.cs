using UnityEngine;
using UnityEngine.InputSystem;

public class SpacePlayer : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    public float moveSpeed = 6;
    [SerializeField] GameObject spawnPosition;

    [SerializeField] float leftLimit = -5;
    [SerializeField] float rightLimit = 5;

    Animator animator;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform.position = spawnPosition.transform.position;
    }

    // Update is called once per frame
    void Update()//�����ӿ� ���� ȣ��Ǵ� �󵵼��� �ٸ�
    {
        
    }

    private void FixedUpdate()//�� �Լ��� �⺻ 0.02��(50������)���� 1���� ȣ�� �� ���Լ��� FPS�� ���� ���۽����� ��Ȳ�� �����ҷ��� ȣ���Ҷ� �ʿ��� �������� ���� ����� �ϹǷ� �� �Լ��� �̿��ϴ°��� �������� ����
    {
        Vector2 playerPosition = transform.position;

        if (playerPosition.x > rightLimit)
        {
            playerPosition.x = rightLimit;
        }
        else if (playerPosition.x < leftLimit)
        {
            playerPosition.x = leftLimit;
        }

            transform.position = playerPosition;
    }

    public void OnMove(InputValue inputValue)
    {
        float input = inputValue.Get<Vector2>().x;

        //float a = Input.GetAxis("Horizontal");

        //Debug.Log("key : " + input);

        if(input > 0)
        {
            animator.SetBool("right",true);
            animator.SetBool("left", false);
        }
        else if(input < 0)
        {
            animator.SetBool("left",true);
            animator.SetBool("right", false);
        }

        if (Mathf.Abs(input) > 0)
        {
            rigidbody2D.linearVelocity = input * Vector2.right * moveSpeed;
        }
        else
        {
            rigidbody2D.linearVelocity = Vector2.zero;
            animator.SetBool("left", false);
            animator.SetBool("right", false);
        }

    }
}
// MathfŬ������ ���а� ���õ� ������ ��� Ŭ����
// Abs�޼ҵ�(�Լ�)�� ���밪�� ��ȯ�ϴ� �޼ҵ�(�Լ�)
// private �������� Inspector�� ǥ���ϴ� ���:[SerializeField] ��� �� ����
