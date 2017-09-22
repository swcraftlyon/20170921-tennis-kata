# Mob programming session on September 21st 2017: Tennis kata in FSharp

NB: French description at the end.

## Setting up environment

This code can used on any OS with [dotnet sdk 2.0](https://www.microsoft.com/net/core). Use `dotnet build` to build and `dotnet test` to run tests.

Use [VSCode](https://code.visualstudio.com/) for example to edit code, with [ionide](http://ionide.io/) plugin for F# support.

You can add FiraCode font to have ligatures (i.e some characters are combined to draw cool symbols).

## About the session

We started with a discussion around [the domain](https://github.com/emilybache/Tennis-Refactoring-Kata) and tried to identify use cases.

We used "baby steps"/"TDD as you mean it" (without being explicit about it). We started with the simplest case: from Love/Love, Player1 scores. Types with union cases/discriminated unions emerge with Love and Fifteen. Then we continued with Player1 scoring other points, till we reached the case of winning the Game, that makes appear a new discriminated union for the Game Score. At this point, we talked about using types to [make illegal states unrepresentable](http://fsharpforfunandprofit.com/posts/designing-with-types-making-illegal-states-unrepresentable). We used a lot pattern matching to solve different cases.

Union cases/discriminated unions, records/data type (immutables) and pattern matching we used are key concept of functionnal programming.

Note we stopped without having refactored the Forty case. At the end of the session, we still can represent a game score that does not exist: Forty/Forty (already represented by Deuce)...to be continued.

The subject was inspired by [this blog post by Mark Seemann](http://blog.ploeh.dk/2016/02/10/types-properties-software-designing-with-types/). You could [read more with Property Based Testing](http://blog.ploeh.dk/2016/02/11/types-properties-software-state-transition-properties). 

## [French] A propos de la session

On a commencé par une discussion sur [le domaine](https://github.com/emilybache/Tennis-Refactoring-Kata), puis nous avons identifié les cas d'utilisation.

Nous avons adopté une approche "baby steps"/"TDD as you mean it" (sans vraiment l'expliciter), c'est-à-dire qu'on a commencé par le cas le plus simple: à partir de Love/Love, le joueur 1 gagne le point. On a commencé à utiliser des types "union cases/discriminated unions" pour représenter Love et Fifteen. On a continué avec le joueur 1 gagnant des points, jusqu'à atteindre le cas du jeu gagné, ce qui a fait apparaître un nouveau "union case/discriminated union". Nous avons alors parlé de définir des [types rendant impossible de représenter un état illégal](http://fsharpforfunandprofit.com/posts/designing-with-types-making-illegal-states-unrepresentable). Nous avons aussi beaucoup utilisé le "pattern matching" pour résoudre les différents cas.

Les "Union cases/discriminated unions", "records/data type" (immutables) and "pattern matching" sont des concepts clés en programmation fonctionnelle.

A noter que nous nous sommes arrêtés sans retravailler le cas "Forty". A la fin de la session, nous pouvions toujours représenter a score qui ne peut exister: Forty/Forty (déjà représenté par Deuce)...à continuer donc.

Le sujet a été inspiré par le [blog de Mark Seemann](http://blog.ploeh.dk/2016/02/10/types-properties-software-designing-with-types/). Vous pouvez [lire aussi une solution utilisant le Property Based Testing](http://blog.ploeh.dk/2016/02/11/types-properties-software-state-transition-properties). 
