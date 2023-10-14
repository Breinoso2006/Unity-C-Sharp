using UnityEngine;

public class Bola : MonoBehaviour
{
    //configurações
    [SerializeField] Plataforma plataforma1;
    [SerializeField] float pressX = 2f;
    [SerializeField] float pressY = 15f;
    [SerializeField] AudioClip[] sonsDaBola;
    [SerializeField] float fatorRandomico = 0.2f;

    //estado
    Vector2 vetorDistanciaBolaPlataforma;
    bool comecou = false;

    //Referencias de componente em cache
    AudioSource minhaFonteDeAudio;
    Rigidbody2D meuRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        vetorDistanciaBolaPlataforma = transform.position - plataforma1.transform.position;
        minhaFonteDeAudio = GetComponent<AudioSource>();
        meuRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!comecou)
        {
            LockBolaEPlataforma();
            LancarAoClicar();
        }
    }

    private void LancarAoClicar()
    {
        if (Input.GetMouseButtonDown(0))//o zero representa o botao esquerdo
        {
            comecou = true;
            meuRigidBody.velocity = new Vector2(pressX, pressY);
        }
    }

    private void LockBolaEPlataforma()
    {
        Vector2 posiPlataforma = new Vector2(plataforma1.transform.position.x, plataforma1.transform.position.y);
        transform.position = posiPlataforma + vetorDistanciaBolaPlataforma;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 ajusteDeVelocidade = new Vector2(Random.Range(- fatorRandomico, fatorRandomico), 
            Random.Range(- fatorRandomico, fatorRandomico));       
        
        if (comecou)
        {
            AudioClip clip = sonsDaBola[UnityEngine.Random.Range(0,sonsDaBola.Length)];
            minhaFonteDeAudio.PlayOneShot(clip); //playoneshot garante que o audio não será interrompido
            //caso houvesse apenas um som, o comando seria GetComponent<AudioSource>().Play();
        }
    }

}
