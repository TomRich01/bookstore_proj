using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Customer : MonoBehaviour
{
    public bool hasBought;

    public BookGenre bookToBuy;
    public enum BookGenre
    {
        romance,
        scifi,
        classic,
        mystery,
        fantasy
    }

    public int satisfaction;

    public VisualWaypoints visual;
    public ChildNodes [] nodes;
    public NavMeshAgent agent;
    private StoreAdditions additions;
    private StoreInventory storeInventory;
    [SerializeField] private float budget = 0f;

    [Space(10)]
    [Header("Destination")]
    public int createNum;
    void Start()
    {

        storeInventory = FindObjectOfType<StoreInventory>();
        additions = FindObjectOfType<StoreAdditions>();
        satisfaction = Random.Range(15, 100);
        agent = GetComponent<NavMeshAgent>();
        visual = FindObjectOfType<VisualWaypoints>();
        nodes = visual.GetComponentsInChildren<ChildNodes>();
        hasBought = false;
        int maxIndex = System.Enum.GetValues(typeof(BookGenre)).Length;
        bookToBuy = (BookGenre)Random.Range(0, maxIndex);
        agent.SetDestination(nodes[0].transform.position);

       
    }

    
        
    

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= 0.5f && !agent.isStopped)
        {
            agent.isStopped = true;
        }
        else if (agent.remainingDistance > 0.5f && agent.isStopped)
        {
            agent.isStopped = false;
        }
    }

    public void Buy()
    {
        float randomInvoke = Random.Range(0.5f, 1f);

        // Check the book genre and store inventory amount.
        int genreIndex = (int)bookToBuy;
        int inventoryCount = 0;

        switch (genreIndex)
        {
            case 0: // Romance
                inventoryCount = storeInventory.b_romance;
                break;
            case 1: // Sci-Fi
                inventoryCount = storeInventory.b_scifi;
                break;
            case 2: // Classic
                inventoryCount = storeInventory.b_classic;
                break;
            case 3: // Thriller
                inventoryCount = storeInventory.b_mystery;
                break;
            case 4: // Fantasy
                inventoryCount = storeInventory.b_fantasy;
                break;
            default:
                Debug.LogWarning("Invalid genre!");
                break;
        }

        if (inventoryCount > 0)
        {
            storeInventory.BuyBook(genreIndex, 1, budget);
            Invoke("LeaveStore", randomInvoke);
            Debug.Log("Customer bought item for " + budget);
        }
        else
        {
            LeaveStore();
        }
    }


    //Sets destination to the buy point.
    private void DecideToBuy()
    {     
        SetDestination(8);
    }

    //Goes to random browse point.
    public void RandomBrowsePoint()
    {
         createNum = Random.Range(1, 7);
        SetDestination(createNum);
       
    }

    // Privately sets destinations.
    private void SetDestination(int moveTo)
    {

        agent.SetDestination(nodes[moveTo].transform.position);
    }

    private void LeaveStore()
    {
        SetDestination(9);
    }


    //Checks if customer is satisfied. If so, will decide to buy an item.
    public void CheckIfSatisfied()
    {

       float randomInvoke = Random.Range(1.5f, 3.5f);
        // This caused the bug of customers walking out the store then coming back. Can keep this if randomInvoke is shorter.
       // satisfaction = Random.Range(1, 100);

        if (additions.CustomerSatisfactionUpgrade == true)
        {
            if (satisfaction >= 41)
            {
                budget = Random.Range(15.00f, 40.00f);
                budget = Mathf.Round(budget * 100.0f) * 0.01f;
                Invoke("DecideToBuy", randomInvoke);
            }
            if (satisfaction <= 40)
            {
                Invoke("LeaveStore", randomInvoke);
            }
        }
        else 
        {
            if (satisfaction >= 70)
            {
                budget = Random.Range(10.00f, 30.00f);
                budget = Mathf.Round(budget * 100.0f) * 0.01f;
                Invoke("DecideToBuy", randomInvoke);
            }

            if (satisfaction <= 69)
            {
                Invoke("LeaveStore", randomInvoke);
            }
               
        }

        
    }

    public void Destroy()
    {
        Destroy(gameObject, 1f);
    }



}
