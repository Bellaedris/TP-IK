using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomIK : MonoBehaviour
{
    // Le transform (noeud) racine de l'arbre, 
    // le constructeur créera une sphère sur ce point pour en garder une copie visuelle.
    public GameObject rootNode;
    
    // Un transform (noeud) (probablement une feuille) qui devra arriver sur targetNode
    public Transform srcNode;
    
    // Le transform (noeud) cible pour srcNode
    public Transform targetNode;                         

    // Si vrai, recréer toutes les chaines dans Update
    public bool createChains = true;                            
    
    // Toutes les chaines cinématiques 
    public List<CustomIKChain> chains = new List<CustomIKChain>();          

    // Nombre d'itération de l'algo à chaque appel
    public int nb_ite = 10;                                     


    void Start()
    {
        if (createChains)
        {
            Debug.Log("(Re)Create CHAIN");
            
            // TODO : 
            // Création des chaines : une chaine cinématique est un chemin entre deux nœuds carrefours.
            // Dans la 1ere question, une unique chaine sera suffisante entre srcNode et rootNode.
            chains.Add(new CustomIKChain(srcNode, rootNode.transform, targetNode));
            
            // TODO-2 : Pour parcourir tous les transform d'un arbre d'Unity vous pouvez faire une fonction récursive
            // ou utiliser GetComponentInChildren comme ceci :
            // foreach (Transform tr in gameObject.GetComponentsInChildren<Transform>())

            
            // TODO-2 : Dans le cas où il y a plusieurs chaines, fusionne les IKJoint entre chaque articulation.

            createChains = false;
        }
    }

    void Update()
    {
        if (createChains)
            Start();

        if (Input.GetKeyDown(KeyCode.I))
        {
            IKOneStep(true);
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Chains count="+chains.Count);
            foreach (CustomIKChain ch in chains)
                ch.Check();
        }
    }


    void IKOneStep(bool down)
    {
        int j;

        for (j = 0; j < nb_ite; ++j)
        {
            // TODO : IK Backward (remontée), appeler la fonction Backward de IKChain 
            // sur toutes les chaines cinématiques.
            foreach (var ch in chains)
            {
                ch.Backward();
            }

            // TODO : appliquer les positions des IKJoint aux transform en appelant ToTransform de IKChain
            foreach (var ch in chains)
            {
                ch.ToTransform();
            }

            // IK Forward (descente), appeler la fonction Forward de IKChain 
            // sur toutes les chaines cinématiques.
            foreach (var ch in chains)
            {
                ch.Forward();
            }
                      
            // TODO : appliquer les positions des IKJoint aux transform en appelant ToTransform de IKChain
            foreach (var ch in chains)
            {
                ch.ToTransform();
            }
        }



    }


}