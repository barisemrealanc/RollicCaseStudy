using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager _gameManager;
    public int collectibleCount = 0;
    public float forwardSpeed;
    public List<GameObject> collectibleItems;
    // Start is called before the first frame update
    void Start()
    {
        collectibleItems = new List<GameObject>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private float firstTouchX;
    // Update is called once per frame
    void Update()
    {
        if (_gameManager.currentGameState != GameState.Start)
        {
            return;
        }

        for(int i=0;i < collectibleItems.Count; i++)
        {
            collectibleItems[i].transform.position = new Vector3(
                collectibleItems[i].transform.position.x,
                collectibleItems[i].transform.position.y,
                Mathf.Lerp(transform.position.z, collectibleItems[i].transform.position.z, 0.01f * Time.deltaTime
                ));
        }

        Vector3 moveVector = new Vector3(-1*forwardSpeed*Time.deltaTime, 0, 0);
        float diff = 0;

        if(Input.GetMouseButtonDown(0))
        {
            firstTouchX = Input.mousePosition.x;
        }
        else if(Input.GetMouseButton(0))
        {
            float lastTouchX = Input.mousePosition.x;
            diff = lastTouchX - firstTouchX;
            moveVector += new Vector3(0, 0, diff * Time.deltaTime);
            firstTouchX = lastTouchX;
        }

        transform.position += moveVector;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectibles"))
        {
            other.transform.SetParent(transform);
            collectibleItems.Add(other.gameObject);

            collectibleCount++;
        }
        else if (other.CompareTag("Finish"))
        {          
            if(collectibleCount==0)
            {
                _gameManager.EndGame();
            }
            else
            {
                collectibleItems[collectibleItems.Count - 1].SetActive(false);
                collectibleItems.RemoveAt(collectibleItems.Count - 1);

                collectibleCount--;
            }
            
                
            
        }
    }
}
