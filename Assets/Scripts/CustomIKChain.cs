using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomIKChain
{
    // Quand la chaine comporte une cible pour la racine. 
    // Ce sera le cas que pour la chaine comportant le root de l'arbre.
    private CustomIKJoint rootTarget;

    // Quand la chaine à une cible à atteindre, 
    // ce ne sera pas forcément le cas pour toutes les chaines.
    private CustomIKJoint endTarget;

    // Toutes articulations (CustomIKJoint) triées de la racine vers la feuille. N articulations.
    private List<CustomIKJoint> joints = new List<CustomIKJoint>();

    // Contraintes pour chaque articulation : la longueur (à modifier pour 
    // ajouter des contraintes sur les angles). N-1 contraintes.
    private List<float> constraints = new List<float>();


    // Un cylndre entre chaque articulation (Joint). N-1 cylindres.
    //private List<GameObject> cylinders = new List<GameObject>();    



    // Créer la chaine d'IK en partant du noeud endNode et en remontant jusqu'au noeud plus haut, ou jusqu'à la racine
    public CustomIKChain(Transform _endNode, Transform _rootTarget = null, Transform _endTarget = null)
    {
        Debug.Log("=== IKChain::createChain: ===");
        // TODO : construire la chaine allant de _endNode vers _rootTarget en remontant dans l'arbre. 
        // Chaque Transform dans Unity a accès à son parent 'tr.parent'

        if (_endTarget != null)
            endTarget = new CustomIKJoint(_endTarget);

        if (_rootTarget != null)
            rootTarget = new CustomIKJoint(_rootTarget);

        Transform currentNode = _endNode;
        Transform end = _rootTarget;        
        while(currentNode != end)
        {
            //constraint
            constraints.Insert(0, Vector3.Distance(currentNode.position, currentNode.parent.position));

            //joint
            joints.Insert(0, new CustomIKJoint(currentNode));

            currentNode = currentNode.parent;
        }

        joints.Insert(0, new CustomIKJoint(currentNode));
        
    }


    public void Merge(CustomIKChain j)
    {
        // TODO-2 : fusionne les noeuds carrefour quand il y a plusieurs chaines cinématiques
        // Dans le cas d'une unique chaine, ne rien faire pour l'instant.

        // si le premier courant est egal au premier de j, le courant recupere j
        if (First().name == j.Last().name){
            joints[0] = j.Last();
        }
        // pareil pour le dernier
        if (Last().GetHashCode() == j.First().GetHashCode())
            joints[joints.Count - 1] = j.First();
    }


    public CustomIKJoint First()
    {
        return joints[0];
    }
    public CustomIKJoint Last()
    {
        return joints[joints.Count - 1];
    }

    public void Backward()
    {
        // TODO : une passe remontée de FABRIK. Placer le noeud N-1 sur la cible, 
        // puis on remonte du noeud N-2 au noeud 0 de la liste 
        // en résolvant les contrainte avec la fonction Solve de CustomIKJoint.
        if (endTarget != null)
            Last().SetPosition(endTarget.position);
        for(int i = joints.Count - 2; i >= 0; i--)
        {
            joints[i].Solve(joints[i + 1], constraints[i]);
        }
    }

    public void Forward()
    {
        // TODO : une passe descendante de FABRIK. Placer le noeud 0 sur son origine puis on descend.
        // Codez et deboguez déjà Backward avant d'écrire celle-ci.
        if (rootTarget != null)
            First().SetPosition(rootTarget.position);
        for (int i = 1; i < joints.Count; i++)
        {
            joints[i].Solve(joints[i - 1], constraints[i - 1]);
        }
    }

    public void ToTransform()
    {
        // TODO : pour tous les noeuds de la liste appliquer la position au transform : voir ToTransform de CustomIKJoint
        foreach (var j in joints)
        {
            j.ToTransform();
        }
    }

    public void Check()
    {
        // TODO : des Debug.Log pour afficher le contenu de la chaine (ne sert que pour le debug)
        for(int i = 0; i < constraints.Count; i++)
        {
            Debug.Log("Joint " + i + " has constraint " + constraints[i]);
        }
    }

}
