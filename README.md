Pokedex

Le projet Pokedex est une application web Blazor WebAssembly qui permet aux utilisateurs d'explorer les Pok�mon, y compris les l�gendaires, et de g�rer leurs Pok�mon favoris.

Fonctionnalit�s

Liste de Pok�mon : Affiche une liste de Pok�mon r�cup�r�e via l'API externe PokeAPI.
Pok�mon L�gendaires Al�atoires : Permet aux utilisateurs d'afficher un nom de Pok�mon l�gendaire al�atoire � chaque clic sur un bouton.
Gestion des Favoris : Les utilisateurs peuvent ajouter des Pok�mon � leurs favoris et les visualiser s�par�ment.

Technologies Utilis�es

Blazor WebAssembly : Pour le d�veloppement c�t� client en utilisant C# et .NET.
PokeAPI : Une API RESTful utilis�e pour r�cup�rer des informations sur les Pok�mon.
Blazored LocalStorage : Pour la persistance des favoris c�t� client dans le stockage local du navigateur.

D�pendances

Blazored.LocalStorage : Utilis� pour stocker et r�cup�rer les favoris du Pok�mon.
System.Net.Http.Json : Pour faire des requ�tes HTTP et recevoir des r�ponses au format JSON.
Moq : Utilis� pour les mock objects dans les tests unitaires.
bUnit : Un framework de test pour les composants Blazor.

Structure du Projet

Pages/ : Contient les composants Razor pour les diff�rentes pages de l'application.
Models/ : D�finit les mod�les de donn�es utilis�s dans l'application.
Util/ : Contient des services utilitaires comme PokeClient pour les appels API et FavoriteService pour la gestion des favoris.
wwwroot/img : Dossier pour les ressources statiques, comme les images.

Configuration et Ex�cution

Pr�requis : Avoir .NET 6.0 (ou sup�rieur) install� sur votre machine.
Clonage du projet : Clonez le d�p�t sur votre machine locale.
Installation des d�pendances : Ex�cutez dotnet restore pour installer toutes les d�pendances n�cessaires.
Lancement de l'application : Ex�cutez dotnet run dans le dossier du projet pour d�marrer l'application. Acc�dez � http://localhost:5000/ (ou au port sp�cifi�) dans votre navigateur.

Tests

Les tests unitaires sont r�alis�s avec xUnit, Moq, et bUnit pour tester � la fois la logique m�tier et les composants UI.

Ex�cution des tests : Ex�cutez dotnet test pour lancer tous les tests unitaires du projet.