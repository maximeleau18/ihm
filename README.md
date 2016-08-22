# Projet Pokemon UWP
Une fois le projet démarré, vous arriverez sur le menu principal vous proposant de :
    
    1. Démarrer une nouvelle partie (Online)
    2. Continuer une partie (Online)
    
Ainsi si vous optez pour le premier choix vous pourrez commencer une toute nouvelle partie en choisissant le personnage que vous souhaitez incarner avec les 3 pokémons qu'il possède.
Aussi, pour chaque pokémon vous pourrez consulter les 4 attaques qu'il connait. Une fois votre choix fait vous devrez 
créer un compte avec un login (unique) et un mot de passe.

Si vous souhaitez poursuivre une partie alors votre couple login / password sera exigé. Vous retrouverez alors votre personnage avec ses pokémons.

Une fois connecté, vous arriverez sur la carte. Pour débuter un combat il suffira d'ouvrir le menu de gauche et de 
cliquer sur "Combattre". A partir de ce moment deux possibilités s'offriront à vous. Soit vous souhaitez engager un combat
soit votre cherchez à rejoindre un combat existant. 
Dans le premier cas on cherchera un combat où il manque un joueur durant 30 secondes. Si aucun adversaire n'est trouvé le combat
sera annulé et vous devrez lancer une nouvelle recherche. Dans le deuxième cas l'application cherchera un combat incomplet et 
si un combat est trouvé alors le combat commencera.

Dans tous les cas ce sera au joueur ayant instancié le combat d'attaquer en premier.

Le combat se terminera lorsqu'un des deux pokémons mourra. Le dresseur possédant le pokémon vainqueur sera considéré comme 
gagnant. Il sera également possible d'abandonner le combat dans ce cas le joueur qui abandonne sera considéré comme perdant.

Le résultat du combat sera enregistré en base de données incluant le dresseur victorieux, son pokémon, le dresseur perdant, 
son pokémon, ainsi que la durée du combat exprimée en nombre de tours.

