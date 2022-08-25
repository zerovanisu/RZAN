using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [Header("�X�R�A")]
    [SerializeField]
    public int Score;

    [Header("�ő�HP")]
    [SerializeField]
    public int Player_HPMax;

    [Header("���݂�HP")]
    [SerializeField]
    public int Player_HP;

    [Header("�W�����v���鍂��")]
    [SerializeField]
    float Jump_Max;

    [Header("�W�����v����X�s�[�h")]
    [SerializeField]
    float Jump_Speed;

    [Header("�d��")]
    [SerializeField]
    float GravityScale;

    [Header("��e��̖��G����")]
    [SerializeField]
    float Muteki_Time_Max;

    [Header("���G���̓_�ő��x")]
    [SerializeField]
    float Sprite_Speed;

    [Header("�Q�Ɨp")]
    [SerializeField]
    public bool Frieze;
    public Text Score_Text;
    public bool Muteking;
    public bool Player_Clear, Player_Deth;

    [System.NonSerialized]
    float Vertical;
    float Jump_Keep;
    float Gravity_P;
    float Damage_Time;
    float Muteki_Time;
    SpriteRenderer Sprite_R;

    [System.NonSerialized]
    public bool Not_Gravity, IsGround, Jumoing, Player_Dash, Damageing;
    string Sprite_UD;

    Rigidbody2D Rb;

    private Vector2 Size;//�傫����ۑ�

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Gravity_P = GravityScale;//�d�͂��擾

        Size = transform.localScale;//�傫����ۑ�

        //�X�e�[�^�X�𔽉f
        Player_HP = Player_HPMax;
        Muteki_Time = Muteki_Time_Max;

        Sprite_R = GetComponent<SpriteRenderer>();

        Player_Clear = Player_Dash = false;
    }

    void Update()
    {
        if (Frieze == false)
        {
            //���͎�t
            Vertical = Input.GetAxis("Vertical");
        }
        else
        {
            Rb.velocity = new Vector2(0, 0);
        }

        //�ڒn���Ă��鎞
        if (IsGround == true)
        {
            //�d�͂̉e���𖳂���(���Ɉ�������Ȃ��悤�ɂ���)
            Not_Gravity = true;

            //�W�����v����
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //��ׂ鍂�����v�Z(���̍�������Jump_Keep�܂Ŕ�ׂ�)
                Jump_Keep = transform.position.y + Jump_Max;

                Jumoing = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Jumoing = false;
            Not_Gravity = false;
        }


        if (Player_HP <= 0)
        {
            Player_Deth = true;
        }
    }

    private void FixedUpdate()
    {
        if (Frieze == false)
        {
            Gravity();
            Jump();
        }

        GameOver();
        Muteki();
        DamageMove();
    }

    void Jump()
    {
        //�W�����v�{�^���������ꂽ&��������ׂ���E�ɒB���Ă��Ȃ��Ƃ�
        if (Jumoing == true && transform.position.y < Jump_Keep)
        {
            //��ё�����
            Rb.velocity = new Vector2(Rb.velocity.x, Jump_Speed);
        }
        else
        {
            Jumoing = false;
            Not_Gravity = false;
        }
    }

    void Gravity()
    {
        if (Not_Gravity == false)
        {
            //���݂̍�������d�͉����x���������������̍��W�ɒu��������
            float Gravity_total = transform.position.y - Gravity_P;

            Rb.velocity = new Vector2(Rb.velocity.x, Gravity_total);
        }
        else
        {
            Rb.velocity = new Vector2(Rb.velocity.x, 0);
        }
    }

    public void AddScore()
    {
        Score += 1;

        Score_Text.text = "Score:" + Score + "/10";
    }

    //��e�������̏���
    public void DamageMove()
    {
        //��e�̏���
        if (Damageing == true)
        {
            //���G���I���ɂ���
            Muteking = true;

            if (Damage_Time > 0)
            {
                //�v���C���[���~
                Frieze = true;

                Damage_Time -= Time.deltaTime;
            }
            else
            {
                //�t���O����
                Frieze = false;
                Damageing = false;
            }
        }
    }

    //���G���̏���
    void Muteki()
    {
        if (Muteking == true)
        {
            Muteki_Time -= Time.deltaTime;

            //�_�ŏ���
            if (Sprite_R.color.a >= 1)
            {
                Sprite_UD = "Down";
            }
            else if (Sprite_R.color.a <= 0)
            {
                Sprite_UD = "Up";
            }

            if (Sprite_UD == "Down")
            {
                float Alpha = Sprite_R.color.a - Sprite_Speed;
                Sprite_R.color = new Color(1f, 1f, 1f, Alpha);
            }
            else if (Sprite_UD == "Up")
            {
                float Alpha = Sprite_R.color.a + Sprite_Speed;
                Sprite_R.color = new Color(1f, 1f, 1f, Alpha);
            }
        }
        if (Muteki_Time <= 0)
        {
            //�t���O���Z�b�g
            Muteking = false;
            Muteking = false;
            Muteki_Time = Muteki_Time_Max;
            Sprite_R.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    void GameOver()
    {
        if (Player_Clear == true)
        {
            //�������~�߂�
            Frieze = true;
        }
        else if (Player_Deth == true)
        {
            //�������~�߂�
            Frieze = true;
        }
    }
}