using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeGames.Misc
{
    public class PoolerContainer : MonoBehaviour
    {
        public EnumPoolerContainerName poolerName;

        [Space]
        public PoolerObject[] prefabs;
        public Transform parent;

        public int poolSize = 5;
        public bool sequence = false;

        public List<PoolerObject> collection = new List<PoolerObject>();

        // Start is called before the first frame update
        void Awake()
        {
            if (!parent)
                parent = transform;

            FillPool();
        }

        void Start()
        {

        }

        protected virtual void FillPool()
        {
            PoolerObject tempPooler;

            if (sequence)
            {
                for (int i = 0; i < poolSize; i++)
                {
                    for (int j = 0; j < prefabs.Length; j++)
                    {
                        tempPooler = Instantiate(prefabs[j], parent);
                        tempPooler.Init(this);
                        tempPooler.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                for (int i = 0; i < prefabs.Length; i++)
                {
                    for (int j = 0; j < poolSize; j++)
                    {
                        tempPooler = Instantiate(prefabs[i], parent);
                        tempPooler.Init(this);
                        tempPooler.gameObject.SetActive(false);
                    }
                }
            }
        }

        public virtual GameObject Pop(bool randomize = false)
        {
            PoolerObject temp = null;

            if (collection.Count > 0 && !randomize)
            {
                temp = collection[0];
            }
            else if (collection.Count > prefabs.Length * poolSize && randomize)
            {
                temp = collection[Random.Range(0, collection.Count)];
            }
            else
            {
                temp = Instantiate(prefabs[Random.Range(0, prefabs.Length)], parent);
            }

            if (temp)
                temp.Init(this);

            return temp.gameObject;
        }

        public virtual GameObject Pop(string find)
        {
            PoolerObject temp = collection.Find(x => x.name.Contains(find));

            if (temp == null)
            {
                for (int i = 0; i < prefabs.Length; i++)
                {
                    if (prefabs[i].name.Contains(find))
                    {
                        temp = Instantiate(prefabs[i], parent);
                        break;
                    }
                    else if (find.Contains("Clone") && find.Contains(prefabs[i].name))
                    {
                        temp = Instantiate(prefabs[i], parent);
                        break;
                    }
                }
            }

            if (temp)
                temp.Init(this);

            return temp.gameObject;
        }

        public virtual void Add(PoolerObject pooler)
        {
            if (!collection.Contains(pooler))
            {
                collection.Add(pooler);
            }
        }

        public virtual void Remove(PoolerObject pooler)
        {
            if (collection.Contains(pooler))
            {
                collection.Remove(pooler);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}