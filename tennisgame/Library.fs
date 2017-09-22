namespace Tennis

module Game =
    type Player = Player1 | Player2
    type PlayerScore = Love | Fifteen | Thirty | Forty
    type PlayerScoreData = {
        Player1 : PlayerScore
        Player2 : PlayerScore
    }
    type Score = 
        | PlayerScores of PlayerScoreData 
        | Game of Player
        | Deuce

    let scorePlayer score = 
        match score with 
        | Love -> Fifteen
        | Fifteen -> Thirty
        | Thirty -> Forty
    let score player currentScore =
        match currentScore with
        | PlayerScores scores ->
            match scores.Player1, scores.Player2, player with 
            | Thirty, Forty, Player1 -> Deuce
            | Forty, Thirty, Player2 -> Deuce
            | Forty, _, Player1 -> Game Player1
            | next, _, Player1 -> PlayerScores { scores with Player1 = scorePlayer next } 
            | _, next, Player2 -> PlayerScores { scores with Player2 = scorePlayer next }        
        

module GameShould =
    open Xunit
    open Swensen.Unquote
    open Game

    [<Fact>]
    let ``Given Love/Love, when Player 1 scores, then score is Fifteen/Love`` () =
        let initialScore = { Player1 = Love; Player2 = Love } |> PlayerScores
        test <@ score Player1 initialScore = PlayerScores { Player1 = Fifteen; Player2 = Love } @> 

    [<Fact>]
    let ``Given Fifteen/Love, when Player 1 scores, then score is Thirty/Love`` () =
        let initialScore = { Player1 = Fifteen; Player2 = Love } |> PlayerScores
        test <@ score Player1 initialScore = PlayerScores { Player1 = Thirty; Player2 = Love } @> 

    [<Fact>]
    let ``Given Thirty/Love, when Player 1 scores, then score is Forty/Love`` () =
        let initialScore = { Player1 = Thirty; Player2 = Love } |> PlayerScores
        test <@ score Player1 initialScore = PlayerScores { Player1 = Forty; Player2 = Love } @> 

    [<Fact>]
    let ``Given Forty/Love, when Player 1 scores, then score is Game/Player1`` () =
        let initialScore = PlayerScores { Player1 = Forty; Player2 = Love }
        test <@ score Player1 initialScore = Game Player1 @> 

    [<Fact>]
    let ``Given Love/Love, when Player 2 scores, then score is Love/Fifteen`` () =
        let initialScore = PlayerScores { Player1 = Love; Player2 = Love }
        test <@ score Player2 initialScore = PlayerScores { Player1 = Love; Player2 = Fifteen } @> 

    [<Fact>]
    let ``Given Thirty/Forty, when Player 1 scores, then score is Deuce`` () =
        let initialScore = PlayerScores { Player1 = Thirty; Player2 = Forty }
        test <@ score Player1 initialScore = Deuce @> 

    [<Fact>]
    let ``Given Forty/Thirty, when Player 2 scores, then score is Deuce`` () =
        let initialScore = PlayerScores { Player1 = Forty; Player2 = Thirty }
        test <@ score Player2 initialScore = Deuce @> 

