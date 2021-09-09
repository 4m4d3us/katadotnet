# Kata Bowling



Le but de ce kata est de calculer le score d'une partie de bowling.

Lors du calcule du score, on considérera que :

- Le nombre de quille tombée est valide pour chaque lancé

- La partie est finie avec un nombre correct de lancé

- On ne calculera pas les scores intermédiaires

  

### Les règles sont les suivantes :

- Une partie est composée de 10 tours
- Il y a 10 quilles à faire tomber
- Il y a un maximum de 2 lancés par tours
- Si toutes les quilles sont tombées lors du premier lancé, c'est un **STRIKE** et le tour s'achève.
- Si toutes les quilles sont tombées lors du second lancé, c'est un **SPARE**
- Le score d'un tour correspond au nombre de quilles tombées auquel s'ajoutera un bonus en cas de **STRIKE** ou de **SPARE**
- le bonus de **STRIKE** correspond au nombre totale de quilles tombées lors des 2 lancés suivants
- le bonus de **SPARE** correspond au nombre totale de quilles tombées lors du lancé suivant
- En cas de **STRIKE** ou de **SPARE** lors du dernier tour, il sera jouer le nombre de lancés nécessaires au calcul du score
- Le score final équivaut à la somme des scores de chaque tour



2 tests unitaires sont fournis validant 2 parties.

Pour lancer les tests en invite de commande (dans le répertoire de la solution) :

`dotnet test`
