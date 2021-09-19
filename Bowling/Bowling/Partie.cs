using System;
using System.Collections.Generic;

namespace Bowling
{
    public class Partie
    {
        /*
         * On a un objet Round, cet objet round garde en mémoire le nombre de quilles tombées durant le round. Si le nombre de quille est égale à -1, cela veut dire que l'on n'a pas encore faire tomber les quilles pour se lancer.
         * Après avoir enregistré le nombre de quilles tombées pour le lancer, on regarde dans quel type de round on se trouve. Si 10 quilles sont tombées au premier lancée, on a fait un strike, si 10 quilles sont tombées au total dans le round, on a fait un spare.
         * On extrait le round 10 de la logique normal car c'est un round normal où on fait tomber les quilles 2 fois si on ne fait pas de round special, et 3 fois si on fait un spare ou un strike.
         */

        private List<Round> listeDeLaPartie = new List<Round>();
        private Round currentRound;
        public Partie()
        {
            for(int i = 0; i<10; i++)
            {
                listeDeLaPartie.Add(new Round { numeroDuRound = i});
            }
            currentRound = listeDeLaPartie[0];
        }

        public Partie Lancer(int quillesTombees)
        {
            if (currentRound.numeroDuRound!=9) //On est sur un round classique (pas le numéro 10)
            {
                if(currentRound.quillePremierLancer == -1) //On est sur le premier lancée
                {
                    currentRound.quillePremierLancer = quillesTombees;

                    if (currentRound.quillePremierLancer == 10) //On vérifie si un strike a été fait, si oui on passe au round suivant directement
                    {
                        currentRound.typeDeRound = EnumTypeRound.Strike;
                        currentRound.quilleDeuxiemeLancer = 0;
                        currentRound.isRoundOver = true;
                    }

                }
                else if (currentRound.quilleDeuxiemeLancer == -1) //On est sur le deuxieme lancée
                {
                    currentRound.quilleDeuxiemeLancer = quillesTombees;
                    currentRound.isRoundOver = true;

                    if (currentRound.scoreDuRound == 10) //On vérifie si un spare a été fait
                    {
                        currentRound.typeDeRound = EnumTypeRound.Spare;
                    }
                    else //Cas round classique, pas de spare ou de strike
                    {
                        currentRound.typeDeRound = EnumTypeRound.Normal;
                    }
                }
            }
            else if (currentRound.numeroDuRound == 9) //Cas spécial round 10
            {
                if (currentRound.quillePremierLancer == -1) //Premier lancé du round 10
                {
                    currentRound.quillePremierLancer = quillesTombees;
                    if (quillesTombees == 10)
                    {
                        currentRound.typeDeRound = EnumTypeRound.Strike;
                    }
                }
                else if (currentRound.quilleDeuxiemeLancer == -1) //Deuxieme lancé du round 10
                {
                    currentRound.quilleDeuxiemeLancer = quillesTombees;
                    if(currentRound.typeDeRound != EnumTypeRound.Strike)
                    {
                        if(currentRound.scoreDuRound == 10)
                        {
                            currentRound.typeDeRound = EnumTypeRound.Spare;
                        }
                        else
                        {
                            currentRound.typeDeRound = EnumTypeRound.Normal;
                            currentRound.isRoundOver = true;
                        }
                    }
                }
                else if(currentRound.typeDeRound != EnumTypeRound.Normal) // Cas unique du round 10, on joue une troisieme fois si on a fait un spare ou un strike durant ce round 
                {
                    currentRound.quilleTroisiemeLancer = quillesTombees;
                    currentRound.isRoundOver = true;
                    currentRound.typeDeRound = EnumTypeRound.Normal; //On le passe en round normal pour calculer le score plus facilement
                }
            }

            if (currentRound.isRoundOver && currentRound.numeroDuRound != 9) //On passe au round suivant
            {
                currentRound = listeDeLaPartie[currentRound.numeroDuRound + 1];
            }

            return this;
        }

        public int CalculerScore()
        {
            int score = 0;
            for(int i = 0; i<listeDeLaPartie.Count; i++)
            {
                currentRound = listeDeLaPartie[i];

                if(currentRound.typeDeRound == EnumTypeRound.Normal) //Calcul de score classique pour se round
                {
                    score += currentRound.scoreDuRound;
                }
                else if(currentRound.typeDeRound == EnumTypeRound.Spare)
                {
                    score += currentRound.scoreDuRound + listeDeLaPartie[currentRound.numeroDuRound + 1].quillePremierLancer; //Cas où on a fait un spare, on ajoute les quilles tombées lors du lancé suivant
                }
                else if(currentRound.typeDeRound == EnumTypeRound.Strike) //Cas de strike, on recupère les 2 lancés suivant
                {
                    if (listeDeLaPartie[currentRound.numeroDuRound + 1].typeDeRound == EnumTypeRound.Strike) //On vérifie que le round suivant est le cas d'un strike ou non
                    {
                        //Si oui on récupère les 2 premiers lancés des 2 rounds suivant
                        score += currentRound.scoreDuRound + listeDeLaPartie[currentRound.numeroDuRound + 1].quillePremierLancer + listeDeLaPartie[currentRound.numeroDuRound + 2].quillePremierLancer;
                    }
                    else
                    {
                        //Si non on récupère le score du round suivant
                        score += currentRound.scoreDuRound + listeDeLaPartie[currentRound.numeroDuRound + 1].quillePremierLancer + listeDeLaPartie[currentRound.numeroDuRound + 1].quilleDeuxiemeLancer;
                    } 
                }

            }

            return score;
        }
    }
}
