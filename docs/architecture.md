# Architecture du Projet

Le projet suit une architecture en couches :

## Domain
Contient :
- Les entités métier (Product, Order, Customer, customer)
- Les règles métier
- Les interfaces des repositories
- Les exceptions métier

👉 Aucune dépendance technique.

## Application
Contient :
- Les DTO
- Les services applicatifs
- La logique d’orchestration

👉 Fait le lien entre l’API et le Domain.

## Infrastructure
Contient :
- L’implémentation des repositories
- Le stockage en mémoire (Dictionary)

👉 Simule une base de données.

## API
Expose les endpoints REST.

## Tests
Tests unitaires des règles métier et des services.