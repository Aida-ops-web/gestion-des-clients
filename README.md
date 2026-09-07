# gestion-des-clients
Application de Facturation — VB.NET

Application de gestion commerciale développée en VB.NET dans le cadre d'un projet scolaire, avec une base de données Access.

🎯 Objectif

Permettre la gestion complète du cycle de facturation d'une entreprise : clients, produits, commandes et factures, avec calcul automatique du total, de la TVA et des remises.

🛠️ Technologies
Domaine	Outil
Langage / Framework	VB.NET
Base de données	Microsoft Access
Modélisation	Merise (MCD, MLD, MTD)
Édition de factures	Assistant "État" (Report) d'Access
✨ Fonctionnalités
Authentification : formulaire de connexion (login/mot de passe) avant l'accès au menu principal
Gestion des clients, produits et commandes via des formulaires dédiés
Formulaire Commande avec :
Sélection du produit via liste déroulante
Affichage du détail (code produit, désignation, quantité) dans un DataGridView
Boutons ValiderCommande, RechercheCommande, ModifierCommande, SupprimerCommande, AjouterProduit
Bouton NouvelleCommande pour réinitialiser le formulaire
Facturation avec calcul automatique du total, d'une TVA fixe à 18 % et des remises
Édition de la facture générée via l'assistant État d'Access
🗂️ Modélisation de la base de données

Base de données conçue selon la méthode Merise :

MCD (Modèle Conceptuel de Données)
MLD (Modèle Logique de Données)
MTD (Modèle de Traitement des Données)

Tables principales : Client, Produit, Commande, Facture.

📄 Livrables
Code source de l'application VB.NET
Base de données Access
Notice / mode d'emploi de l'application
Schémas MCD / MLD / MTD
👤 Auteur

Aïda Diop — Projet réalisé dans le cadre de la formation en Génie Informatique, UGB Saint-Louis.
