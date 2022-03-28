using UnityEngine;
using System;
//Allows us to use Lists.
using System.Collections.Generic;
//Tells Random to use the Unity Engine random number generator.
using Random = UnityEngine.Random;

namespace Completed
{
    public class BoardManager : MonoBehaviour
    {
        // Using Serializable allows us to embed a class with sub properties in the inspector.
        [Serializable]
        public class Count
        {
            public int minimum;             //Minimum value for our Count class.
            public int maximum;             //Maximum value for our Count class.


            //Assignment constructor.
            public Count (int min, int max)
            {
                minimum = min;
                maximum = max;
            }
        }

        public int columns = 8;
        public int rows = 8;
        public Count wallCount = new Count(8,12);
        public Count foodCount = new Count(8,13);
        public GameObject exit;
        public GameObject[] floorTiles;
        public GameObject[] wallTopTiles;
        public GameObject[] wallInnerTiles;
        public GameObject[] wallSideTiles;
        public GameObject[] wallTiles;
        public GameObject[] foodTiles;
        public GameObject[] enemyTiles;
        public GameObject[] outerWallTiles;

        private Transform boardHolder;
        private List <Vector3> gridPositions = new List<Vector3>();

        void InitialiseList()
        {
            gridPositions.Clear();

            for (int x = 1; x< columns-1; x++)
            {
                for (int y = 1; y< rows-1; y++)
                {
                    gridPositions.Add(new Vector3(x,y,0f));
                }
            }
        }

        void BoardSetup()
        {
            boardHolder = new GameObject ("Board").transform;
            for (int x = 0; x< columns; x++)
            {
                for (int y = 0; y< rows; y++)
                {
                    GameObject toInstantiate = floorTiles[Random.Range(0,floorTiles.Length)];
                    GameObject instance = Instantiate(toInstantiate, new Vector3 (x,y,0f), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(boardHolder);
                }
            }

            // Instantiate outer walls
            for (int x = 0; x< columns +0; x++)
            {
                GameObject toInstantiate= wallTopTiles[1];
                GameObject toInstantiate2= wallTiles[1];
                GameObject toInstantiate3= wallTopTiles[1];
                GameObject toInstantiate4= wallTiles[1];
                if (x==0)
                {
                    toInstantiate = wallTopTiles[0];
                    toInstantiate2 = wallInnerTiles[2];
                    toInstantiate3 = wallInnerTiles[0];
                    toInstantiate4 = wallTiles[0];
                }
                else if (x==columns-1)
                {
                    toInstantiate = wallTopTiles[2];
                    toInstantiate2 = wallInnerTiles[3];
                    toInstantiate3 = wallInnerTiles[1];
                    toInstantiate4 = wallTiles[2];
                }
                GameObject instance = Instantiate(toInstantiate, new Vector3 (x, rows+1,0f), Quaternion.identity) as GameObject;
                GameObject instance2 = Instantiate(toInstantiate2, new Vector3 (x, rows,0f), Quaternion.identity) as GameObject;
                GameObject instance3 = Instantiate(toInstantiate3, new Vector3 (x, 0f,0f), Quaternion.identity) as GameObject;
                GameObject instance4 = Instantiate(toInstantiate4, new Vector3 (x,-1f,0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
                instance2.transform.SetParent(boardHolder);
                instance3.transform.SetParent(boardHolder);
                instance4.transform.SetParent(boardHolder);
            }

            for (int y = 1; y< rows; y++)
            {
                GameObject toInstantiate= wallSideTiles[2];
                GameObject toInstantiate2= wallSideTiles[3];
                GameObject instance = Instantiate(toInstantiate, new Vector3 (columns-1, y,0f), Quaternion.identity) as GameObject;
                GameObject instance2 = Instantiate(toInstantiate2, new Vector3 (0, y,0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
                instance2.transform.SetParent(boardHolder);
            }




        }

        Vector3 RandomPosition()
        {
            int randomIndex = Random.Range(0, gridPositions.Count);
            Vector3 randomPosition = gridPositions[randomIndex];
            gridPositions.RemoveAt(randomIndex);
            return randomPosition;
        }

        void LayoutObjetAtRandom(GameObject[] tileArray, int minimum, int maximum)
        {
            int objectCount = Random.Range(minimum, maximum +1);

            for (int i = 0; i < objectCount; i++)
            {
                Vector3 randomPosition = RandomPosition();
                GameObject tileChoice = tileArray[Random.Range(0,tileArray.Length)];
                Instantiate (tileChoice, randomPosition, Quaternion.identity);
            }
        }

        public void SetupScene(int level)
        {
            BoardSetup();
            InitialiseList();
            //LayoutObjetAtRandom(foodTiles, foodCount.minimum, foodCount.maximum);
            int enemyCount = (int)Math.Log(level,2f);
            LayoutObjetAtRandom(enemyTiles, enemyCount, enemyCount);
            Instantiate(exit, new Vector3(columns-2, rows -2, 0F), Quaternion.identity);
        }


        /* Start is called before the first frame update
           void Start()
           {

           }

        // Update is called once per frame
        void Update()
        {

        }
        */
    }
}

