Pokedex

Le projet Pokedex est une application web Blazor WebAssembly qui permet aux utilisateurs d'explorer les Pokémon, y compris les légendaires, et de gérer leurs Pokémon favoris.

Fonctionnalités

Liste de Pokémon : Affiche une liste de Pokémon récupérée via l'API externe PokeAPI.
Pokémon Légendaires Aléatoires : Permet aux utilisateurs d'afficher un nom de Pokémon légendaire aléatoire à chaque clic sur un bouton.
Gestion des Favoris : Les utilisateurs peuvent ajouter des Pokémon à leurs favoris et les visualiser séparément.

Technologies Utilisées

Blazor WebAssembly : Pour le développement côté client en utilisant C# et .NET.
PokeAPI : Une API RESTful utilisée pour récupérer des informations sur les Pokémon.
Blazored LocalStorage : Pour la persistance des favoris côté client dans le stockage local du navigateur.

Dépendances

Blazored.LocalStorage : Utilisé pour stocker et récupérer les favoris du Pokémon.
System.Net.Http.Json : Pour faire des requêtes HTTP et recevoir des réponses au format JSON.
Moq : Utilisé pour les mock objects dans les tests unitaires.
bUnit : Un framework de test pour les composants Blazor.

Structure du Projet

Pages/ : Contient les composants Razor pour les différentes pages de l'application.
Models/ : Définit les modèles de données utilisés dans l'application.
Util/ : Contient des services utilitaires comme PokeClient pour les appels API et FavoriteService pour la gestion des favoris.
wwwroot/img : Dossier pour les ressources statiques, comme les images.

Configuration et Exécution

Prérequis : Avoir .NET 6.0 (ou supérieur) installé sur votre machine.
Clonage du projet : Clonez le dépôt sur votre machine locale.
Installation des dépendances : Exécutez dotnet restore pour installer toutes les dépendances nécessaires.
Lancement de l'application : Exécutez dotnet run dans le dossier du projet pour démarrer l'application. Accédez à http://localhost:5000/ (ou au port spécifié) dans votre navigateur.

Tests

Les tests unitaires sont réalisés avec xUnit, Moq, et bUnit pour tester à la fois la logique métier et les composants UI.

Exécution des tests : Exécutez dotnet test pour lancer tous les tests unitaires du projet.