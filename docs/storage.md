# Stockage des Données

Les données sont stockées en mémoire à l’aide de dictionnaires :

Dictionary<Guid, Product>
Dictionary<Guid, Customer>
Dictionary<Guid, Order>

Ce choix permet :
- De simplifier le projet
- D’éviter une base de données
- De se concentrer sur le Domain Driven Design

⚠ Les données sont perdues à l’arrêt de l’application.